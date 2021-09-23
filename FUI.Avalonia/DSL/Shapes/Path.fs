module Avalonia.FuncUI.Experiments.DSL.Path

open FUI.UIBuilder
open Avalonia.FuncUI.Experiments.DSL.Shape
open Avalonia.Media
open Avalonia.Controls.Shapes
open Avalonia.FuncUI.Builder
 
type PathBuilder<'t when 't :> Path>() =
    inherit ShapeBuilder<'t>()
    
    [<CustomOperation("data")>]
    member _.data<'t>(x: Element, geometry: Geometry) =
        x @@ [ AttrBuilder<'t>.CreateProperty<Geometry>(Path.DataProperty, geometry, ValueNone) ]