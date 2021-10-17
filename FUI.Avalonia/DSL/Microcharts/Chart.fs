module FUI.Avalonia.Microcharts.Chart

open FUI.Avalonia.Control
open Microcharts
open FUI.Avalonia.Patcher

type ChartBuilder<'t when 't :> ChartView.ChartView and 't : equality>() =
    inherit ControlBuilder<'t>()

    member this.Run x =
        this.RunWithChild<'t> x (fun control child -> control.Chart <- Some (unbox<Chart> child))