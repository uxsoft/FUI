module FUI.Avalonia.Polygon

open System.Collections.Generic
open Avalonia
open Avalonia.Controls.Shapes
open FUI.Avalonia.Shape
 
type PolygonBuilder<'t when 't :> Polygon and 't : equality>() =
    inherit ShapeBuilder<'t>()

    [<CustomOperation("points")>]
    member _.points<'t>(x: Types.AvaloniaNode<'t>, points: IList<Point>) =
        Types.dependencyProperty x Polygon.PointsProperty points
