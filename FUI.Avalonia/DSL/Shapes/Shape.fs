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
    member _.fill<'t>(x: Types.AvaloniaNode<'t>, brush: IBrush) =
        Types.dependencyProperty x<IBrush>(Shape.FillProperty, brush, ValueNone) ]
    
    [<CustomOperation("stretch")>] 
    member _.stretch<'t>(x: Types.AvaloniaNode<'t>, value: Stretch) =
        Types.dependencyProperty x<Stretch>(Shape.StretchProperty, value, ValueNone) ]
        
    [<CustomOperation("stroke")>] 
    member _.stroke<'t>(x: Types.AvaloniaNode<'t>, brush: IBrush) =
        Types.dependencyProperty x<IBrush>(Shape.StrokeProperty, brush, ValueNone) ]
        
    [<CustomOperation("strokeThickness")>] 
    member _.strokeThickness<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x<double>(Shape.StrokeThicknessProperty, value, ValueNone) ]
        
    [<CustomOperation("strokeDashArray")>] 
    member _.strokeDashArray<'t>(x: Types.AvaloniaNode<'t>, value: AvaloniaList<double>) =
        Types.dependencyProperty x<AvaloniaList<double>>(Shape.StrokeDashArrayProperty, value, ValueNone) ]
        
    [<CustomOperation("strokeDashOffset")>] 
    member _.strokeDashOffset<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x<double>(Shape.StrokeDashOffsetProperty, value, ValueNone) ]
        
    [<CustomOperation("strokeLineCap")>] 
    member _.strokeLineCap<'t>(x: Types.AvaloniaNode<'t>, value: PenLineCap) =
        Types.dependencyProperty x<PenLineCap>(Shape.StrokeLineCapProperty, value, ValueNone) ]

    [<CustomOperation("strokeJoinCap")>] 
    member _.strokeJoinCap<'t>(x: Types.AvaloniaNode<'t>, value: PenLineJoin) =
        Types.dependencyProperty x<PenLineJoin>(Shape.StrokeJoinProperty, value, ValueNone) ]