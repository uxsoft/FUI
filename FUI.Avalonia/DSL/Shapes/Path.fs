module Avalonia.FuncUI.Experiments.DSL.Path

open FUI.UiBuilder
open Avalonia.FuncUI.Experiments.DSL.Shape
open Avalonia.Media
open Avalonia.Controls.Shapes
open Avalonia.FuncUI.Builder
 
type PathBuilder<'t when 't :> Path>() =
    inherit ShapeBuilder<'t>()
    
    [<CustomOperation("data")>]
    member _.data<'t>(x: Node<_, _>, geometry: Geometry) =
        Types.dependencyProperty<Geometry>(Path.DataProperty, geometry, ValueNone) ]