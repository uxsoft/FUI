module FUI.Avalonia.Patcher

open System
open FUI
open FUI.ObservableCollection
open FUI.ObservableValue
open FUI.UiBuilder
open FUI.Avalonia.Types

let addProperty control name value (meta: PropertyMeta<_>) =
    meta.Setter(control, value)

let addDependencyProperty (control: obj) name (value: obj) (property: Avalonia.AvaloniaProperty) =
    match control with
    | :? Avalonia.AvaloniaObject as ao -> ao.SetValue(property, value)
    | _ -> printfn $"Can't set a Dependency Property on a control which doesn't derive from AvaloniaObject"
    
let addRoutedEvent control name value (meta: RoutedEventMeta<_>) =
    ()

let addAttribute control (attribute: Attribute<_>) =
    match attribute.Meta with
    | Property meta -> addProperty control attribute.Name attribute.Value meta
    | DependencyProperty meta -> addDependencyProperty control attribute.Name attribute.Value meta
    | RoutedEvent meta -> addRoutedEvent control attribute.Name attribute.Value meta
    
let removeAttribute (control) attribute =
    ()

// DSL Avalonia Platform
type UiBuilder<'t when 't : equality> with
    member _.RunWithChildren (x: AvaloniaNode<'t>) (setChildren: 't -> IReadOnlyObservableCollection<obj> -> unit) =
        try
            let control = Activator.CreateInstance<'t>()

            let attributes = x.Attributes |> Builder.build
            let children = x.Children |> Builder.build
             
            attributes
            |> Oc.iter (addAttribute control) (removeAttribute control)
                
            children
            |> setChildren control 
                 
            control 
        with e ->
            printfn $"{e}"
            reraise()
            
    member this.RunWithChild (x: AvaloniaNode<'t>) (setChild: 't -> obj -> unit) =
        let setChildren (control: 't) (children: IReadOnlyObservableCollection<obj>) =
            let set () = 
                children
                |> Seq.tryHead
                |> Option.iter (fun child ->
                    match child with
                    | :? IObservableValue as ov ->
                        Ov.iter' (setChild control) ov
                    | _ -> setChild control child)
            
            children.OnChanged.Add (fun _ -> set())
            
        this.RunWithChildren x setChildren
        
    member this.RunChildless (x: AvaloniaNode<'t>) =
        this.RunWithChildren x (fun _ _ -> ())
