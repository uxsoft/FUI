module FUI.Avalonia.DSL

open System
open System.Collections.Generic
open System.Reflection
open Avalonia.Controls
open Avalonia.Interactivity
open FUI.Avalonia.Model

// DSL
type Element =
    { Attributes: KeyValuePair<string, obj> list
      Children: obj list }
    
    member inline x.attr (name: string) value =
        { x with Attributes = x.Attributes @ [ KeyValuePair(name, value) ] }
        
    member inline x.get<'t> (name: string) =
        x.Attributes
        |> List.tryFind (fun p -> p.Key = name)
        |> Option.map (fun p -> p.Value :?> 't)
        
    member inline x.getOrDefault<'t> (name: string) (fallback: 't) =
        x.get<'t> name |> Option.defaultValue fallback

type UIBuilder<'t>() =
    member inline _.Zero() =
        { Attributes = []; Children = [] }
        
    member inline _.Delay(f) = f ()

    member inline x.Yield() = x.Zero()

    member _.Yield(attr: KeyValuePair<string, obj>) =
        { Attributes = [ KeyValuePair(attr.Key, attr.Value) ]; Children = [] }
            
    member _.Yield(children: obj list) =
        { Attributes = []; Children = children }

    member _.Yield(child: obj) =
        { Attributes = []; Children = [ child ] }
    member inline x.Yield _ = x.Zero()

    member _.Combine(a: Element, b: Element) =
        { Attributes = a.Attributes @ b.Attributes
          Children = a.Children @ b.Children }

    member inline x.For(s: Element, f) =
        x.Combine(s, f ())
        
    member inline x.For(list: 'a seq, f: 'a -> Element) =
        let elements = Seq.map f list
        { Attributes = elements |> Seq.map (fun i -> i.Attributes) |> List.concat
          Children =  elements |> Seq.map (fun i -> i.Children) |> List.concat }

    member inline x.For() =
        ()
    
    // Common Attributes
    [<CustomOperation("attr")>]
    member inline _.Attr(s: Element, n: string, v) = s.attr n v

// DSL Avalonia Platform
type UIBuilder<'t> with
    member _.RunAvaloniaWithChildren (x: Element) (setChildren: 't -> obj list -> unit) =
        try
            let control = Activator.CreateInstance<'t>()
            let controlType = typeof<'t>
            
            let setEvent (event: EventInfo) (action: obj) =
                match action with
                | :? Delegate as action -> event.AddEventHandler(control, action)
                | other -> printfn $"Failed to convert {other.GetType().FullName} to delegate"
            
            let setProp (prop: PropertyInfo) (value: obj) =
                match value with
                | :? IObservableValue as state -> State.iter' (fun v -> prop.SetValue(control, v)) state
                | _ -> prop.SetValue(control, value)
            
            for pair in x.Attributes do
                let event = controlType.GetEvent(pair.Key)
                let prop = controlType.GetProperty(pair.Key)
                
                match event, prop with
                | null, null -> printfn $"Property or event {pair.Key} was not found on type {controlType.FullName}"
                | event, null -> setEvent event pair.Value
                | _, prop -> setProp prop pair.Value
                    
            setChildren control (x.Children |> List.filter (isNull >> not))
                 
            control 
        with e ->
            printfn $"{e}"
            reraise()
            
    member this.RunAvaloniaWithChild (x: Element) (setChild: 't -> obj -> unit) =
        let setChildren (control: 't) (children: obj list) =
            children
            |> List.tryHead
            |> Option.iter (fun child ->
                match child with
                | :? IObservableValue as ov ->
                    State.iter' (setChild control) ov
                | _ -> setChild control child)
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
        this.RunAvaloniaWithChildren x (fun panel children ->
            children
            |> List.filter (fun i -> i :? IControl)
            |> List.map (fun i -> i :?> IControl)
            |> panel.Children.AddRange)
        
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
