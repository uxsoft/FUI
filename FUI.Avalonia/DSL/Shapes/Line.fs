module FUI.Avalonia.Line

open Avalonia
open Avalonia.Controls.Shapes
open FUI.Avalonia.Shape
   
type LineBuilder<'t when 't :> Line and 't : equality>() =
    inherit ShapeBuilder<'t>()

    [<CustomOperation("startPoint")>] 
    member _.startPoint<'t>(x: Types.AvaloniaNode<'t>, value: Point) =
        Types.dependencyProperty x Line.StartPointProperty value
        
    [<CustomOperation("endPoint")>] 
    member _.endPoint<'t>(x: Types.AvaloniaNode<'t>, value: Point) =
        Types.dependencyProperty x Line.EndPointProperty value
      