module FUI.Avalonia.Counter

open Avalonia.Media
open FUI
open FUI.Avalonia.Examples
open FUI.ObservableValue
open FUI.ObservableCollection
open FUI.Avalonia.DSL
open FUI.IfBuilder

type Model =
    { Counter: int var
      Items: int col
      ButtonColor: Color var }
    
let init () =
    { Counter = var 0
      Items = col [1; 2; 3]
      ButtonColor = var (FUI.Avalonia.Examples.Library.randomColor()) }
    
let view (model: Model) =
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
                if model.Items.Count > 0 then
                    model.Items.Remove (model.Items.Count - 1)
                model.Counter.Update (fun v -> v - 1)) 
            "-"
        }
        Button {
            background (model.ButtonColor |> Ov.map (SolidColorBrush))
            onClick (fun _ ->
                model.ButtonColor.Value <- Library.randomColor()
                model.Items.Clear()
                model.Counter.Update (fun _ -> 0)) 
            "reset"
        }
        
        
        let isEven = model.Counter |> Ov.map (fun i -> (i % 2) = 0)
        If isEven {
            Label { "even" }
        }
        Else isEven {
            Label { "odd" }
        }
        
        for i in model.Items do
            for j in model.Items do
            Label { $"item-{i}-{j}" }
    }
    