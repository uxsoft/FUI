module FUI.ObservableValue

open System

type IObservableValue =
    abstract member GetValue: unit -> obj
    abstract member OnChanged: IEvent<unit>
    
type IObservableValue<'t> =
    inherit IObservableValue
    abstract member Value: 't with get

type ObservableValue<'t>(initialValue: 't) =    
    let event = Event<unit>()
    
    let mutable value = initialValue
    
    member x.Value
        with get () = value
        and set v =
            value <- v
            event.Trigger()
            
    member x.Update (mutator: 't -> 't) =
        x.Value <- mutator x.Value
    
    member x.OnChanged = event.Publish
    
    override this.Equals other =
        match other with
        | :? IObservableValue as p -> p.GetValue().Equals(this.Value)
        | _ -> false
        
    override this.GetHashCode() =
        (box this.Value).GetHashCode()
        
    interface IObservableValue<'t> with
        member this.Value with get () = this.Value
        member this.GetValue(): obj = box this.Value
        member this.OnChanged = event.Publish
        
    
type 'T var = ObservableValue<'T>