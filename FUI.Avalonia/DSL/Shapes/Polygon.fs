module Avalonia.FuncUI.Experiments.DSL.Polygon

open System.Collections.Generic
open Avalonia
open Avalonia.Controls.Shapes
open Avalonia.FuncUI.Builder
open FUI.UIBuilder
open Avalonia.FuncUI.Experiments.DSL.Shape
 
type PolygonBuilder<'t when 't :> Polygon>() =
    inherit ShapeBuilder<'t>()

    [<CustomOperation("points")>]
    member _.points<'t>(x: Element, points: IList<Point>) =
        x @@ [ AttrBuilder<'t>.CreateProperty<IList<Point>>(Polygon.PointsProperty, points, ValueNone) ]
