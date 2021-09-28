module Avalonia.FuncUI.Experiments.DSL.Polyline

open System.Collections.Generic
open Avalonia
open Avalonia.Controls.Shapes
open Avalonia.FuncUI.Builder
open FUI.UiBuilder
open Avalonia.FuncUI.Experiments.DSL.Shape

 
type PolylineBuilder<'t when 't :> Polyline>() =
    inherit ShapeBuilder<'t>()

    [<CustomOperation("points")>]
    member _.points<'t>(x: Node<_, _>, points: IList<Point>) =
        Types.dependencyProperty<IList<Point>>(Polyline.PointsProperty, points, ValueNone) ]