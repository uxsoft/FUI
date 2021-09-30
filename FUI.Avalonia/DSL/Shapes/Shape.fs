module FUI.Avalonia.Shape

open Avalonia.Collections
open FUI.UiBuilder
open FUI.Avalonia.Control
open Avalonia.Controls.Shapes
open Avalonia.Media

type ShapeBuilder<'t when 't :> Shape and 't : equality>() =
    inherit ControlBuilder<'t>()
    
    [<CustomOperation("fill")>] 
    member _.fill<'t>(x: Types.AvaloniaNode<'t>, brush: IBrush) =
        Types.dependencyProperty x Shape.FillProperty brush
    
    [<CustomOperation("stretch")>] 
    member _.stretch<'t>(x: Types.AvaloniaNode<'t>, value: Stretch) =
        Types.dependencyProperty x Shape.StretchProperty value
        
    [<CustomOperation("stroke")>] 
    member _.stroke<'t>(x: Types.AvaloniaNode<'t>, brush: IBrush) =
        Types.dependencyProperty x Shape.StrokeProperty brush
        
    [<CustomOperation("strokeThickness")>] 
    member _.strokeThickness<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x Shape.StrokeThicknessProperty value
        
    [<CustomOperation("strokeDashArray")>] 
    member _.strokeDashArray<'t>(x: Types.AvaloniaNode<'t>, value: AvaloniaList<double>) =
        Types.dependencyProperty x Shape.StrokeDashArrayProperty value
        
    [<CustomOperation("strokeDashOffset")>] 
    member _.strokeDashOffset<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x Shape.StrokeDashOffsetProperty value
        
    [<CustomOperation("strokeLineCap")>] 
    member _.strokeLineCap<'t>(x: Types.AvaloniaNode<'t>, value: PenLineCap) =
        Types.dependencyProperty x Shape.StrokeLineCapProperty value

    [<CustomOperation("strokeJoinCap")>] 
    member _.strokeJoinCap<'t>(x: Types.AvaloniaNode<'t>, value: PenLineJoin) =
        Types.dependencyProperty x Shape.StrokeJoinProperty value