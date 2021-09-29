module FUI.Avalonia.Types

open System.Threading
open Avalonia.Controls
open Avalonia.Interactivity

type PropertyMeta<'t> =
    { Getter: 't -> obj
      Setter: 't * obj -> unit }
  
type EventMeta  =
    { Subcribe: 't -> }

type AttributeMeta<'t> =
    | Property of PropertyMeta<'t>
    | DependencyProperty of Avalonia.AvaloniaProperty
    | RoutedEvent of EventMeta
    
type Attribute<'t> =
    { Name: string
      Value: obj
      Meta: AttributeMeta<'t> }
    
let dependencyProperty (dp: Avalonia.AvaloniaProperty) v =
    { Name = dp.Name
      Value = v
      Meta = DependencyProperty dp }
   
let property<'t> (name: string) (value: obj) (getter: 't -> obj) (setter: 't * obj -> unit) (factory: unit -> obj) =
    { Name = name
      Value = value
      Meta = Property
          { Getter = getter
            Setter = setter } }
    
let routedEvent (routedEvent: RoutedEvent<'e>) (handler: 'e -> unit) =
    let subscribeFunc (control: IControl, _handler: 'h) =
        let cts = new CancellationTokenSource()
        control
            .GetObservable(routedEvent)
            .Subscribe(func, cts.Token)
        cts
     
    { Name = routedEvent.Name
      Value = ()
      Meta = RoutedEvent (Action<_>(subscribeFunc)) }
    
type AvaloniaNode<'t> = Node<'t, Attribute<'t>>