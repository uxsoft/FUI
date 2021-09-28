module Avalonia.FuncUI.Experiments.DSL.Line

open Avalonia
open Avalonia.Controls.Shapes
open Avalonia.FuncUI.Builder
open FUI.UiBuilder
open Avalonia.FuncUI.Experiments.DSL.Shape
   
type LineBuilder<'t when 't :> Line>() =
    inherit ShapeBuilder<'t>()

    [<CustomOperation("startPoint")>] 
    member _.startPoint<'t>(x: Node<_, _>, value: Point) =
        Types.dependencyProperty<Point>(Line.StartPointProperty, value, ValueNone) ]
        
    [<CustomOperation("endPoint")>] 
    member _.endPoint<'t>(x: Node<_, _>, value: Point) =
        Types.dependencyProperty<Point>(Line.EndPointProperty, value, ValueNone) ]
      