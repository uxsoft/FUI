module FUI.Ov

open FUI.ObservableValue

let iter' f (state: IObservableValue) =
    f (state.GetValue())
    state.OnChanged.Add (fun () -> f (state.GetValue()))
    
let iter f (state: IObservableValue<'t>) =
    f (state.Value)
    state.OnChanged.Add (fun () -> f state.Value)
    
let map (f: 'a -> 'b) (state: IObservableValue<'a>) =
    { new IObservableValue<'b> with        
        member this.Value with get () = f state.Value
        member this.GetValue(): obj = box (f state.Value)
        member this.OnChanged = state.OnChanged }
