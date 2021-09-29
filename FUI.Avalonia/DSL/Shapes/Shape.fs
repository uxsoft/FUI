module FUI.Avalonia.Shape

open Avalonia.Collections
open FUI.UiBuilder
open FUI.Avalonia.Control
open Avalonia.Controls.Shapes
open Avalonia.Media
open Avalonia.FuncUI.Builder

type ShapeBuilder<'t when 't :> Shape>() =
    inherit ControlBuilder<'t>()
    
    [<CustomOperation("fill")>] 
    member _.fill<'t>(x: Node<_, _>, brush: IBrush) =
        Types.dependencyProperty<IBrush>(Shape.FillProperty, brush, ValueNone) ]
    
    [<CustomOperation("stretch")>] 
    member _.stretch<'t>(x: Node<_, _>, value: Stretch) =
        Types.dependencyProperty<Stretch>(Shape.StretchProperty, value, ValueNone) ]
        
    [<CustomOperation("stroke")>] 
    member _.stroke<'t>(x: Node<_, _>, brush: IBrush) =
        Types.dependencyProperty<IBrush>(Shape.StrokeProperty, brush, ValueNone) ]
        
    [<CustomOperation("strokeThickness")>] 
    member _.strokeThickness<'t>(x: Node<_, _>, value: double) =
        Types.dependencyProperty<double>(Shape.StrokeThicknessProperty, value, ValueNone) ]
        
    [<CustomOperation("strokeDashArray")>] 
    member _.strokeDashArray<'t>(x: Node<_, _>, value: AvaloniaList<double>) =
        Types.dependencyProperty<AvaloniaList<double>>(Shape.StrokeDashArrayProperty, value, ValueNone) ]
        
    [<CustomOperation("strokeDashOffset")>] 
    member _.strokeDashOffset<'t>(x: Node<_, _>, value: double) =
        Types.dependencyProperty<double>(Shape.StrokeDashOffsetProperty, value, ValueNone) ]
        
    [<CustomOperation("strokeLineCap")>] 
    member _.strokeLineCap<'t>(x: Node<_, _>, value: PenLineCap) =
        Types.dependencyProperty<PenLineCap>(Shape.StrokeLineCapProperty, value, ValueNone) ]

    [<CustomOperation("strokeJoinCap")>] 
    member _.strokeJoinCap<'t>(x: Node<_, _>, value: PenLineJoin) =
        Types.dependencyProperty<PenLineJoin>(Shape.StrokeJoinProperty, value, ValueNone) ]