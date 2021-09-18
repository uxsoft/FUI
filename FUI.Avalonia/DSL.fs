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

// DSL

type Element =
    { Attributes: Builder.Builder<KeyValuePair<string, obj>>
      Children: Builder.Builder<obj> }
    
    member inline x.mapAttrs f =
        { x with Attributes = f x.Attributes }
    
    member inline x.attr (name: string) value =
        x.mapAttrs (Builder.appendStatic (KeyValuePair(name, value)))


type UIBuilder<'t>() =
    member inline _.Zero() =
        { Attributes = Builder.empty; Children = Builder.empty }
        
    member inline _.Delay(f) = f ()

    member inline x.Yield() = x.Zero()

    member _.Yield(attr: KeyValuePair<string, obj>) =
        { Attributes = Builder.init [ KeyValuePair(attr.Key, attr.Value) ]
          Children = Builder.empty }
            
    member _.Yield(children: obj list) =
        { Attributes = Builder.empty
          Children = Builder.init children }

    member _.Yield(child: obj) =
        if isNull child then
            { Attributes = Builder.empty
              Children = Builder.empty }
        else
            { Attributes = Builder.empty
              Children = Builder.init [ child ] }
            
    member inline x.Yield _ =
        x.Zero()

    member _.Combine(a: Element, b: Element) =
        { Attributes = Builder.append a.Attributes b.Attributes
          Children = Builder.append a.Children b.Children }

    member x.For(s: Element, f) =
        x.Combine(s, f ())
        
    member x.For(list: IReadOnlyObservableCollection<'a>, f: 'a -> Element) =
        let elements = list |> Oc.map f
        let attributes =
            elements
            |> Oc.map (fun i -> i.Attributes)
            |> Oc.map Builder.build
            |> Oc.flatten
            
        let children =
            elements
            |> Oc.map (fun i -> i.Children)
            |> Oc.map Builder.build
            |> Oc.flatten
            
        { Attributes = Builder.empty |> Builder.appendObservable attributes
          Children = Builder.empty |> Builder.appendObservable children }
            
    member x.For(list: 'a seq, f: 'a -> Element) =
        let elements = Seq.map f list
        { Attributes = elements |> Seq.map (fun i -> i.Attributes) |> Builder.concat
          Children =  elements |> Seq.map (fun i -> i.Children) |> Builder.concat }
    
    // Common Attributes
    [<CustomOperation("attr")>]
    member inline _.Attr(s: Element, n: string, v) = s.attr n v


type IfBuilder<'t>(q: IObservableValue<bool>) =
    inherit UIBuilder<'t>()
    
    member _.Run (x: Element) =
        let sourceAttributes = x.Attributes |> Builder.build
        let sourceChildren = x.Children |> Builder.build
        
        let ifAttributes = ObservableCollection([ sourceAttributes ])
        let ifChildren = ObservableCollection([ sourceChildren ])
                
        let refreshAttributes() =
            ifAttributes.Set 0 (
                if q.Value then sourceAttributes
                else Oc.empty :> IReadOnlyObservableCollection<KeyValuePair<string,obj>>)
            
        let refreshChildren() =
            ifChildren.Set 0 (
                if q.Value then sourceChildren
                else Oc.empty :> IReadOnlyObservableCollection<obj>)
        
        q.OnChanged.Add(refreshAttributes)
        q.OnChanged.Add(refreshChildren)
        refreshAttributes()
        refreshChildren()
        { Attributes = Builder.empty |> Builder.appendObservable (Oc.flatten ifAttributes)
          Children = Builder.empty |> Builder.appendObservable (Oc.flatten ifChildren) }
    
let If (q: IObservableValue<bool>) = IfBuilder q

let Else (q: IObservableValue<bool>) = IfBuilder (q |> Ov.map not)

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
