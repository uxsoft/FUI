module Avalonia.FuncUI.Experiments.DSL.Shape

open Avalonia.Collections
open FUI.UIBuilder
open Avalonia.FuncUI.Experiments.DSL.Control
open Avalonia.Controls.Shapes
open Avalonia.Media
open Avalonia.FuncUI.Builder

type ShapeBuilder<'t when 't :> Shape>() =
    inherit ControlBuilder<'t>()
    
    [<CustomOperation("fill")>] 
    member _.fill<'t>(x: Element, brush: IBrush) =
        x @@ [ AttrBuilder<'t>.CreateProperty<IBrush>(Shape.FillProperty, brush, ValueNone) ]
    
    [<CustomOperation("stretch")>] 
    member _.stretch<'t>(x: Element, value: Stretch) =
        x @@ [ AttrBuilder<'t>.CreateProperty<Stretch>(Shape.StretchProperty, value, ValueNone) ]
        
    [<CustomOperation("stroke")>] 
    member _.stroke<'t>(x: Element, brush: IBrush) =
        x @@ [ AttrBuilder<'t>.CreateProperty<IBrush>(Shape.StrokeProperty, brush, ValueNone) ]
        
    [<CustomOperation("strokeThickness")>] 
    member _.strokeThickness<'t>(x: Element, value: double) =
        x @@ [ AttrBuilder<'t>.CreateProperty<double>(Shape.StrokeThicknessProperty, value, ValueNone) ]
        
    [<CustomOperation("strokeDashArray")>] 
    member _.strokeDashArray<'t>(x: Element, value: AvaloniaList<double>) =
        x @@ [ AttrBuilder<'t>.CreateProperty<AvaloniaList<double>>(Shape.StrokeDashArrayProperty, value, ValueNone) ]
        
    [<CustomOperation("strokeDashOffset")>] 
    member _.strokeDashOffset<'t>(x: Element, value: double) =
        x @@ [ AttrBuilder<'t>.CreateProperty<double>(Shape.StrokeDashOffsetProperty, value, ValueNone) ]
        
    [<CustomOperation("strokeLineCap")>] 
    member _.strokeLineCap<'t>(x: Element, value: PenLineCap) =
        x @@ [ AttrBuilder<'t>.CreateProperty<PenLineCap>(Shape.StrokeLineCapProperty, value, ValueNone) ]

    [<CustomOperation("strokeJoinCap")>] 
    member _.strokeJoinCap<'t>(x: Element, value: PenLineJoin) =
        x @@ [ AttrBuilder<'t>.CreateProperty<PenLineJoin>(Shape.StrokeJoinProperty, value, ValueNone) ]