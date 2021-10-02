module FUI.Avalonia.Types

open System
open System.Threading
open Avalonia
open Avalonia.Controls
open Avalonia.Interactivity
open FUI.UiBuilder

type PropertyMeta<'t when 't : equality> =
    { Getter: 't -> obj
      Setter: 't * obj -> unit
      DefaultValueFactory: unit -> obj }

type AttributeMeta<'t when 't : equality> =
    | Property of PropertyMeta<'t>
    | DependencyProperty of Avalonia.AvaloniaProperty
    | RoutedEvent of ('t -> CancellationTokenSource)

[<CustomEquality; NoComparison>]
type Attribute<'t when 't : equality> =
    { Name: string
      Value: obj
      Meta: AttributeMeta<'t> }
    
    override this.Equals (other: obj) : bool =
        this.Name.Equals other
            
    override this.GetHashCode () =
        this.Name.GetHashCode()
    
type AvaloniaNode<'t when 't : equality> = Node<obj, Attribute<'t>>
    
let dependencyProperty (x: AvaloniaNode<'t>) (dp: Avalonia.AvaloniaProperty) v =
    let prop = 
        { Name = dp.Name
          Value = v
          Meta = DependencyProperty dp }
    
    attr prop x
   
let property (x: AvaloniaNode<'t>) (name: string) (value: obj) (getter: 't -> obj) (setter: 't * obj -> unit) (factory: unit -> obj) =
    let prop = 
        { Name = name
          Value = value
          Meta = Property
              { Getter = getter
                Setter = setter
                DefaultValueFactory = factory } }
    attr prop x

let routedEvent<'t, 'e when 't : equality and 't :> IInteractive and 'e :> RoutedEventArgs> (x: AvaloniaNode<'t>) (routedEvent: RoutedEvent<'e>) (handler: 'e -> unit) =
    let subscribeFunc (control: 't) =
        let cts = new CancellationTokenSource()
        control
            .GetObservable(routedEvent)
            .Subscribe(handler, cts.Token)
        cts
        
    let prop = 
        { Name = routedEvent.Name
          Value = ()
          Meta = RoutedEvent subscribeFunc }
        
    attr prop x
    
let dependencyPropertyEvent<'t, 'a when 't : equality and 't :> IAvaloniaObject> (x: AvaloniaNode<'t>) (dp: AvaloniaProperty<'a>) (handler: 'a -> unit) =
    let subscribeFunc (control: 't) =
        let cts = new CancellationTokenSource()
        control
            .GetObservable(dp)
            .Subscribe(handler, cts.Token)
        cts
        
    let prop = 
        { Name = dp.Name
          Value = ()
          Meta = RoutedEvent subscribeFunc }
        
    attr prop x