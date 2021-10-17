module FUI.Tests.Avalonia.StackPanel

open Avalonia
open FUI.Avalonia.DSL
open Xunit

[<Fact>]
let ``Events Execution Order`` () =
    let slider =
        Slider {
            margin (Thickness 2.)
            maximum (float 100)
            value (float 1234)
        }
        
    let panel = 
        StackPanel {
            column 0
            row 3
            Label { $"{1234}%%" }
            Slider {
                margin (Thickness 2.)
                maximum (float 100)
                value (float 1234)
            }
        }
    ()