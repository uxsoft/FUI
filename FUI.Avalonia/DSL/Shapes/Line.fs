module FUI.Avalonia.Line

open Avalonia
open Avalonia.Controls.Shapes
open Avalonia.FuncUI.Builder
open FUI.UiBuilder
open FUI.Avalonia.Shape
   
type LineBuilder<'t when 't :> Line>() =
    inherit ShapeBuilder<'t>()

    [<CustomOperation("startPoint")>] 
    member _.startPoint<'t>(x: Types.AvaloniaNode<'t>, value: Point) =
        Types.dependencyProperty x<Point>(Line.StartPointProperty, value, ValueNone) ]
        
    [<CustomOperation("endPoint")>] 
    member _.endPoint<'t>(x: Types.AvaloniaNode<'t>, value: Point) =
        Types.dependencyProperty x<Point>(Line.EndPointProperty, value, ValueNone) ]
      