module FUI.Avalonia.DSL

open System
open System.Collections.Generic
open System.Collections.ObjectModel
open System.Reflection
open Avalonia.Controls
open Avalonia.Interactivity
open FUI
open FUI.CompositeObservableCollection
open FUI.ObservableCollection
open FUI.ObservableValue
open FUI.UIBuilder

// DSL Avalonia Platform
type UIBuilder<'t> with
    member _.RunAvaloniaWithChildren (x: Element) (setChildren: 't -> IReadOnlyObservableCollection<obj> -> unit) =
        try
            let control = Activator.CreateInstance<'t>()
            let controlType = typeof<'t>
            
            let setEvent (event: EventInfo) (action: obj) =
                match action with
                | :? Delegate as action -> event.AddEventHandler(control, action)
                | other -> printfn $"Failed to convert {other.GetType().FullName} to delegate"
            
            let setProp (prop: PropertyInfo) (value: obj) =
                match value with
                | :? IObservableValue as state -> Ov.iter' (fun v -> prop.SetValue(control, v)) state
                | _ -> prop.SetValue(control, value)
            
            let attributes = x.Attributes |> Builder.build
            let children = x.Children |> Builder.build
            
            // TODO handle changes in attributes
            for pair in attributes do
                let event = controlType.GetEvent(pair.Key)
                let prop = controlType.GetProperty(pair.Key)
                
                match event, prop with
                | null, null -> printfn $"Property or event {pair.Key} was not found on type {controlType.FullName}"
                | event, null -> setEvent event pair.Value
                | _, prop -> setProp prop pair.Value
                    
            setChildren control children
                 
            control 
        with e ->
            printfn $"{e}"
            reraise()
            
    member this.RunAvaloniaWithChild (x: Element) (setChild: 't -> obj -> unit) =
        let setChildren (control: 't) (children: IReadOnlyObservableCollection<obj>) =
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
            
        this.RunAvaloniaWithChildren x setChildren
        
    member this.RunAvaloniaChildless (x: Element) =
        this.RunAvaloniaWithChildren x (fun _ _ -> ())

// DSL Avalonia Elements
type WindowBuilder() =
    inherit UIBuilder<Window>()
    member inline this.Run x =            
        this.RunAvaloniaWithChild x (fun window child -> window.Content <- child)
        
    [<CustomOperation("title")>] member inline _.Title(x: Element, v: string) = x.attr "Title" v
    [<CustomOperation("height")>] member inline _.Height(x: Element, v: float) = x.attr "Height" v
    [<CustomOperation("width")>] member inline _.Width(x: Element, v: float) = x.attr "Width" v
    
    
let Window = WindowBuilder()



type StackPanelBuilder() =
    inherit UIBuilder<StackPanel>()
    
    member this.Run x =
        this.RunAvaloniaWithChildren x (fun panel (children: IReadOnlyObservableCollection<obj>) ->
            let list = 
                children
                |> Oc.filter (fun i -> i :? IControl)
                |> Oc.map (fun i -> i :?> IControl)
            
            panel.Children.AddRange list
            list.OnChanged.Add(Change.commit panel.Children))

let StackPanel = StackPanelBuilder()
    
    
    

type TextBlockBuilder() =
    inherit UIBuilder<TextBlock>()
    member this.Run x =
        this.RunAvaloniaWithChild x (fun textBlock text -> textBlock.Text <- string text)
        
let TextBlock = TextBlockBuilder()



type ButtonBuilder() =
    inherit UIBuilder<Button>()
    member this.Run x =
        this.RunAvaloniaWithChild x (fun button child -> button.Content <- string child)
        
    [<CustomOperation("onClick")>] member inline _.onClick (x: Element, v: EventHandler<RoutedEventArgs>) = x.attr "Click" v
        
let Button = ButtonBuilder()
