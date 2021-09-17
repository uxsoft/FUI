module FUI.Avalonia.Counter

open FUI.Avalonia.Model
open FUI.Avalonia.DSL

type Model =
    { Counter: int oval }



    
let init () =
    { Counter = oval 0 }
    
let view () =
    let model = init ()
    
    StackPanel {
        TextBlock {
            let txt = (model.Counter |> State.map string)
            txt
        }
        Button {
            onClick (fun _ _ -> model.Counter.Update (fun v -> v + 1))
            "+"
        }
        Button {
            onClick (fun _ _ -> model.Counter.Update (fun v -> v - 1)) 
            "-"
        }
    }
    