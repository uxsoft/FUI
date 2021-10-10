module FUI.Avalonia.Line

open Avalonia
open Avalonia.Controls.Shapes
open FUI.Avalonia.Shape
   
type LineBuilder<'t when 't :> Line and 't : equality>() =
    inherit ShapeBuilder<'t>()

    /// Point | ObservableValue<Point>
    [<CustomOperation("startPoint")>] 
    member _.startPoint<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x Line.StartPointProperty value
        
    /// Point | ObservableValue<Point>
    [<CustomOperation("endPoint")>] 
    member _.endPoint<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x Line.EndPointProperty value
      