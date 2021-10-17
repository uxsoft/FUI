module FUI.Avalonia.Shape

open Avalonia.Collections
open FUI.UiBuilder
open FUI.Avalonia.Control
open Avalonia.Controls.Shapes
open Avalonia.Media

type ShapeBuilder<'t when 't :> Shape and 't : equality>() =
    inherit ControlBuilder<'t>()
    
    /// IBrush | ObservableValue<IBrush>
    [<CustomOperation("fill")>] 
    member _.fill<'t, 'v>(x, brush: 'v) =
        Types.dependencyProperty x Shape.FillProperty brush
    
    /// Stretch | ObservableValue<Stretch>
    [<CustomOperation("stretch")>] 
    member _.stretch<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Shape.StretchProperty value
        
    /// IBrush | ObservableValue<IBrush>
    [<CustomOperation("stroke")>] 
    member _.stroke<'t, 'v>(x, brush: 'v) =
        Types.dependencyProperty x Shape.StrokeProperty brush
        
    /// double | ObservableValue<double>
    [<CustomOperation("strokeThickness")>] 
    member _.strokeThickness<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Shape.StrokeThicknessProperty value
        
    /// AvaloniaList<double> | ObservableValue<AvaloniaList<double>>
    [<CustomOperation("strokeDashArray")>] 
    member _.strokeDashArray<'t, 'v>(x, value: AvaloniaList<double>) =
        Types.dependencyProperty x Shape.StrokeDashArrayProperty value
        
    /// double | ObservableValue<double>
    [<CustomOperation("strokeDashOffset")>] 
    member _.strokeDashOffset<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Shape.StrokeDashOffsetProperty value
        
    /// PenLineCap | ObservableValue<PenLineCap>
    [<CustomOperation("strokeLineCap")>] 
    member _.strokeLineCap<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Shape.StrokeLineCapProperty value

    /// PenLineJoin | ObservableValue<PenLineJoin>
    [<CustomOperation("strokeJoinCap")>] 
    member _.strokeJoinCap<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Shape.StrokeJoinProperty value