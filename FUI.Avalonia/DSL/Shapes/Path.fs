module FUI.Avalonia.Path

open FUI.UiBuilder
open FUI.Avalonia.Shape
open Avalonia.Media
open Avalonia.Controls.Shapes
open Avalonia.FuncUI.Builder
 
type PathBuilder<'t when 't :> Path>() =
    inherit ShapeBuilder<'t>()
    
    [<CustomOperation("data")>]
    member _.data<'t>(x: Types.AvaloniaNode<'t>, geometry: Geometry) =
        Types.dependencyProperty x<Geometry>(Path.DataProperty, geometry, ValueNone) ]