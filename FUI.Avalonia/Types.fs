module FUI.Avalonia.Types

open System
open System.Threading
open Avalonia
open Avalonia.Interactivity
open FUI
open FUI.ObservableValue
open FUI.UiBuilder
    
[<CustomEquality; NoComparison>]
type Attribute =
    { Name: string
      Set: obj -> unit
      Clear: obj -> unit }
    
    interface IAttribute
    
    override this.Equals (other: obj) : bool =
        this.Name.Equals other
            
    override this.GetHashCode () =
        this.Name.GetHashCode()
    
let dependencyProperty (x: Node) (dp: AvaloniaProperty) v =
    let set (o: obj) =
        match box v with
        | :? IObservableValue as ov ->
            ov |> Ov.iter' (fun v -> (o :?> AvaloniaObject).SetValue(dp, v))
        | _ -> (o :?> AvaloniaObject).SetValue(dp, v)
        
    let clear (o: obj) =
        (o :?> AvaloniaObject).ClearValue(dp)
    
    let prop = 
        { Name = dp.Name
          Set = set
          Clear = clear }
    
    attr prop x
   
let property (x: Node) (name: string) (value: obj) (setter: 't * obj -> unit) (factory: unit -> obj) =
    let set (o: obj) =
        match box value with
        | :? IObservableValue as ov ->
            ov |> Ov.iter' (fun v -> setter ((o :?> 't), v))
        | _ ->  setter ((o :?> 't), value)
        
    let clear (o: obj) =
        setter ((o :?> 't), factory())
    
    let prop = 
        { Name = name
          Set = set
          Clear = clear }
    
    attr prop x

let routedEvent<'t, 'e when 't : equality and 't :> IInteractive and 'e :> RoutedEventArgs> (x: Node) (routedEvent: RoutedEvent<'e>) (handler: 'e -> unit) =
    let mutable cts = new CancellationTokenSource()
        
    let set (o: obj) =
        (o :?> IInteractive)
            .GetObservable(routedEvent)
            .Subscribe(handler, cts.Token)
        
    let clear (o: obj) =
        cts.Cancel()
        cts <- new CancellationTokenSource()
    
    let prop = 
        { Name = routedEvent.Name
          Set = set
          Clear = clear }
    
    attr prop x
    
let dependencyPropertyEvent<'t, 'a when 't : equality and 't :> IAvaloniaObject> (x: Node) (dp: AvaloniaProperty<'a>) (handler: 'a -> unit) =
    let mutable cts = new CancellationTokenSource()
        
    let set (o: obj) =
        (o :?> IAvaloniaObject)
            .GetObservable(dp)
            .Subscribe(handler, cts.Token)
        
    let clear (o: obj) =
        cts.Cancel()
        cts <- new CancellationTokenSource()
    
    let prop = 
        { Name = dp.Name
          Set = set
          Clear = clear }
    
    attr prop x
    
let observableEvent<'t, 'a when 't : equality and 't :> IAvaloniaObject> x (obs: IObservable<'a>) (name: string) (handler: 'a -> unit) =
    let mutable cts = new CancellationTokenSource()
        
    let set (o: obj) =
        obs.Subscribe(handler, cts.Token)
        
    let clear (o: obj) =
        cts.Cancel()
        cts <- new CancellationTokenSource()
    
    let prop = 
        { Name = name
          Set = set
          Clear = clear }
    
    attr prop x