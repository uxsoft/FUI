module FUI.Avalonia.Polyline

open System.Collections.Generic
open Avalonia
open Avalonia.Controls.Shapes
open FUI.Avalonia.Shape
 
type PolylineBuilder<'t when 't :> Polyline and 't : equality>() =
    inherit ShapeBuilder<'t>()

    /// IList<Point> | ObservableValue<IList<Point>>
    [<CustomOperation("points")>]
    member _.points<'t, 'v>(x, points: IList<Point>) =
        Types.dependencyProperty x Polyline.PointsProperty points