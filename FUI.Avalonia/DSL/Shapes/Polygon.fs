module Avalonia.FuncUI.Experiments.DSL.Polygon

open System.Collections.Generic
open Avalonia
open Avalonia.Controls.Shapes
open Avalonia.FuncUI.Builder
open FUI.UiBuilder
open Avalonia.FuncUI.Experiments.DSL.Shape
 
type PolygonBuilder<'t when 't :> Polygon>() =
    inherit ShapeBuilder<'t>()

    [<CustomOperation("points")>]
    member _.points<'t>(x: Node<_, _>, points: IList<Point>) =
        Types.dependencyProperty<IList<Point>>(Polygon.PointsProperty, points, ValueNone) ]
