module Avalonia.FuncUI.Experiments.DSL.Line

open Avalonia
open Avalonia.Controls.Shapes
open Avalonia.FuncUI.Builder
open FUI.UIBuilder
open Avalonia.FuncUI.Experiments.DSL.Shape
   
type LineBuilder<'t when 't :> Line>() =
    inherit ShapeBuilder<'t>()

    [<CustomOperation("startPoint")>] 
    member _.startPoint<'t>(x: Element, value: Point) =
        x @@ [ AttrBuilder<'t>.CreateProperty<Point>(Line.StartPointProperty, value, ValueNone) ]
        
    [<CustomOperation("endPoint")>] 
    member _.endPoint<'t>(x: Element, value: Point) =
        x @@ [ AttrBuilder<'t>.CreateProperty<Point>(Line.EndPointProperty, value, ValueNone) ]
      