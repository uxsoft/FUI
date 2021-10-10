module FUI.Avalonia.Polygon

open System.Collections.Generic
open Avalonia
open Avalonia.Controls.Shapes
open FUI.Avalonia.Shape
 
type PolygonBuilder<'t when 't :> Polygon and 't : equality>() =
    inherit ShapeBuilder<'t>()

    /// IList<Point> | ObservableValue<IList<Point>>
    [<CustomOperation("points")>]
    member _.points<'t, 'v>(x: Types.AvaloniaNode<'t>, points: 'v) =
        Types.dependencyProperty x Polygon.PointsProperty points
