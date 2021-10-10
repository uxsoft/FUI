module FUI.Avalonia.Path

open FUI.UiBuilder
open FUI.Avalonia.Shape
open Avalonia.Media
open Avalonia.Controls.Shapes
 
type PathBuilder<'t when 't :> Path and 't : equality>() =
    inherit ShapeBuilder<'t>()
    
    /// Geometry | ObservableValue<Geometry>
    [<CustomOperation("data")>]
    member _.data<'t, 'v>(x: Types.AvaloniaNode<'t>, geometry: 'v) =
        Types.dependencyProperty x Path.DataProperty geometry