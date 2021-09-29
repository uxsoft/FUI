module FUI.Avalonia.Counter

open FUI
open FUI.ObservableValue
open FUI.ObservableCollection
open FUI.Avalonia.DSL
open FUI.IfBuilder

type Model =
    { Counter: int oval
      Items: int ocol }
    
let init () =
    { Counter = oval 0
      Items = ocol [1; 2; 3] }
    
let view () =
    let model = init ()
    
    StackPanel {
        Label {
            let txt = (model.Counter |> Ov.map string)
            txt
        }
        Button {
            onClick (fun _ ->
                model.Items.Add (model.Items.Count + 1)
                model.Counter.Update (fun v -> v + 1))
            "+"
        }
        Button {
            onClick (fun _ ->
                model.Items.Remove (model.Items.Count - 1)
                model.Counter.Update (fun v -> v - 1)) 
            "-"
        }
        Button {
            onClick (fun _ ->
                model.Items.Clear()
                model.Counter.Update (fun _ -> 0)) 
            "reset"
        }
        
        
        let isEven = model.Counter |> Ov.map (fun i -> (i % 2) = 0)
        If (isEven) {
            Label { "even" }
        }
        Else (isEven) {
            Label { "odd" }
        }
        
        for i in model.Items do
            for j in model.Items do
            Label { $"item-{i}-{j}" }
    }
    