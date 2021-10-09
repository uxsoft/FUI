module FUI.Avalonia.Patcher

open System
open System.Collections.Generic
open System.Threading
open FUI
open FUI.ObservableCollection
open FUI.ObservableValue
open FUI.UiBuilder
open FUI.Avalonia.Types

let bindings<'t when 't : equality> = Dictionary<'t * string, IDisposable>() 
let subscriptions<'t when 't : equality> = Dictionary<'t * string, CancellationTokenSource>() 

let addProperty control name value (meta: PropertyMeta<_>) =
    match box value with
    | :? IObservableValue as ov ->
        let binding = ov.OnChanged.Subscribe(fun v -> meta.Setter(control, ov.GetValue()))
        bindings.[(control, name)] <- binding
        meta.Setter(control, ov.GetValue())
    | _ -> 
        meta.Setter(control, value)
    
let removeProperty control name value (meta: PropertyMeta<_>) =
    let key = control, name
    if bindings.ContainsKey key then
        let _, binding = bindings.Remove key
        binding.Dispose()
       
    meta.Setter(control, meta.DefaultValueFactory())

let addDependencyProperty (control: obj) name (value: obj) (property: Avalonia.AvaloniaProperty) =
    match control with
    | :? Avalonia.AvaloniaObject as ao ->
        match box value with
        | :? IObservableValue as ov ->
            let binding = ov.OnChanged.Subscribe(fun v -> ao.SetValue(property, ov.GetValue()))
            bindings.[(control, name)] <- binding
            ao.SetValue(property, ov.GetValue())
        | _ -> 
            ao.SetValue(property, value)
    | _ -> printfn $"Can't set a Dependency Property on a control which doesn't derive from AvaloniaObject"
    
let removeDependencyProperty (control: obj) name (value: obj) (property: Avalonia.AvaloniaProperty) =
    match control with
    | :? Avalonia.AvaloniaObject as ao ->
        let key = control, name
        if bindings.ContainsKey key then
            let _, binding = bindings.Remove key
            binding.Dispose()
            
        ao.ClearValue(property)
    | _ -> printfn $"Can't unset a Dependency Property on a control which doesn't derive from AvaloniaObject"
    
let addRoutedEvent control name value (meta: 't -> CancellationTokenSource) =
    let cts = meta control
    subscriptions.Add((control, name), cts)

let removeRoutedEvent control name value (meta: 't -> CancellationTokenSource) =
    let key = control, name
    if subscriptions.ContainsKey key then
        let _, cts = subscriptions.Remove key
        cts.Cancel()

let addAttribute control (attribute: Attribute<_>) =
    match attribute.Meta with
    | Property meta -> addProperty control attribute.Name attribute.Value meta
    | DependencyProperty meta -> addDependencyProperty control attribute.Name attribute.Value meta
    | RoutedEvent meta -> addRoutedEvent control attribute.Name attribute.Value meta
    
let removeAttribute control attribute =
    match attribute.Meta with
    | Property meta -> removeProperty control attribute.Name attribute.Value meta
    | DependencyProperty meta -> removeDependencyProperty control attribute.Name attribute.Value meta
    | RoutedEvent meta -> removeRoutedEvent control attribute.Name attribute.Value meta

// DSL Avalonia Platform
type UiBuilder<'t when 't : equality> with
    member _.RunWithChildren (x: AvaloniaNode<'t>) (setChildren: 't -> IReadOnlyObservableCollection<obj> -> unit) =
        try
            let control = Activator.CreateInstance<'t>()

            let attributes = x.Attributes |> Builder.build
            let children = x.Children |> Builder.build
             
            attributes
            |> Oc.iter (addAttribute control) (removeAttribute control)
                
            setChildren control children
                 
            control 
        with e ->
            printfn $"{e}"
            reraise()
            
    member this.RunWithChild (x: AvaloniaNode<'t>) (setChild: 't -> obj -> unit) =
        let setChild (control: 't) (children: IReadOnlyObservableCollection<obj>) =
            //TODO Oc.head 
            let set () = 
                children
                |> Seq.tryHead
                |> Option.iter (fun child ->
                    match child with
                    | :? IObservableValue as ov ->
                        Ov.iter' (setChild control) ov
                    | _ -> setChild control child)
            
            set()
            children.OnChanged.Add (fun _ -> set())
            
        this.RunWithChildren x setChild
        
    member this.RunChildless (x: AvaloniaNode<'t>) =
        this.RunWithChildren x (fun _ _ -> ())
