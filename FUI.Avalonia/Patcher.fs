module FUI.Avalonia

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
open FUI.UiBuilder

// DSL Avalonia Platform
type UiBuilder<'t> with
    member _.RunWithChildren (x: Node<_, _>) (setChildren: 't -> IReadOnlyObservableCollection<obj> -> unit) =
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
            
    member this.RunWithChild (x: Node<_, _>) (setChild: 't -> obj -> unit) =
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
        
    member this.RunChildless (x: Node<_, _>) =
        this.RunWithChildren x (fun _ _ -> ())

// DSL Avalonia Elements

    
    



type StackPanelBuilder() =
    inherit UiBuilder<StackPanel>()
    


let StackPanel = StackPanelBuilder()
    
    
    

type TextBlockBuilder() =
    inherit UiBuilder<TextBlock>()
    member this.Run x =
        this.RunWithChild x (fun textBlock text -> textBlock.Text <- string text)
        
let TextBlock = TextBlockBuilder()


