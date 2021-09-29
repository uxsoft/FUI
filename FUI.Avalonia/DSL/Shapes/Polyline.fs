module FUI.Avalonia.Polyline

open System.Collections.Generic
open Avalonia
open Avalonia.Controls.Shapes
open Avalonia.FuncUI.Builder
open FUI.UiBuilder
open FUI.Avalonia.Shape

 
type PolylineBuilder<'t when 't :> Polyline>() =
    inherit ShapeBuilder<'t>()

    [<CustomOperation("points")>]
    member _.points<'t>(x: Types.AvaloniaNode<'t>, points: IList<Point>) =
        Types.dependencyProperty x<IList<Point>>(Polyline.PointsProperty, points, ValueNone) ]