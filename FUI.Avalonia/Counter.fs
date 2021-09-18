module FUI.Avalonia.Counter

open FUI
open FUI.ObservableValue
open FUI.ObservableCollection
open FUI.Avalonia.DSL

type Model =
    { Counter: int oval
      Items: int ocol }
    
let init () =
    { Counter = oval 0
      Items = ocol [1; 2; 3] }
    
let view () =
    let model = init ()
    
    StackPanel {
        TextBlock {
            let txt = (model.Counter |> Ov.map string)
            txt
        }
        Button {
            onClick (fun _ _ ->
                model.Items.Add model.Items.Count
                model.Counter.Update (fun v -> v + 1))
            "+"
        }
        Button {
            onClick (fun _ _ -> model.Counter.Update (fun v -> v - 1)) 
            "-"
        }
        
//        let isEven = model.Counter |> Ov.map (fun i -> (i % 2) = 0)
//        
//        If (isEven) {
//            TextBlock { "even" }
//        }
//        Else (isEven) {
//            TextBlock { "odd" }
//        }
        
//        if model.Counter |> State.map (fun i -> i > 2) then
//            TextBlock {
//                "too big!"
//            }

        for i in model.Items do
            for i in model.Items do
                TextBlock { string i }
    }
    