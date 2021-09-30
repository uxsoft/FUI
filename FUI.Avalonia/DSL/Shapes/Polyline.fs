module FUI.Avalonia.Polyline

open System.Collections.Generic
open Avalonia
open Avalonia.Controls.Shapes
open FUI.Avalonia.Shape
 
type PolylineBuilder<'t when 't :> Polyline and 't : equality>() =
    inherit ShapeBuilder<'t>()

    [<CustomOperation("points")>]
    member _.points<'t>(x: Types.AvaloniaNode<'t>, points: IList<Point>) =
        Types.dependencyProperty x Polyline.PointsProperty points