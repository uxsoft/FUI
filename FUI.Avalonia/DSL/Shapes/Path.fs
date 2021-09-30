module FUI.Avalonia.Path

open FUI.UiBuilder
open FUI.Avalonia.Shape
open Avalonia.Media
open Avalonia.Controls.Shapes
 
type PathBuilder<'t when 't :> Path and 't : equality>() =
    inherit ShapeBuilder<'t>()
    
    [<CustomOperation("data")>]
    member _.data<'t>(x: Types.AvaloniaNode<'t>, geometry: Geometry) =
        Types.dependencyProperty x Path.DataProperty geometry