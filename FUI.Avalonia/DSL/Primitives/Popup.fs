module FUI.Avalonia.Popup

open Avalonia
open Avalonia.Controls
open Avalonia.Controls.Primitives
open Avalonia.Controls.Primitives.PopupPositioning
open FUI.Avalonia.Control

type PopupBuilder<'t when 't :> Popup and 't : equality>() =
    inherit ControlBuilder<'t>()

    [<CustomOperation("child")>] 
    member _.child<'t, 'c when 't :> Track and 'c :> obj>(x: Types.AvaloniaNode<'t>, value: 'c) =
        Types.dependencyProperty x Popup.ChildProperty value

    [<CustomOperation("isOpen")>] 
    member _.isOpen<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x Popup.IsOpenProperty, value
        
    [<CustomOperation("isLightDismissEnabled")>] 
    member _.isLightDismissEnabled<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x Popup.IsLightDismissEnabledProperty value
        
    [<CustomOperation("topmost")>] 
    member _.topmost<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x Popup.TopmostProperty value

    [<CustomOperation("placementAnchor")>] 
    member _.placementAnchor<'t>(x: Types.AvaloniaNode<'t>, value: PopupAnchor) =
        Types.dependencyProperty x Popup.PlacementModeProperty value
        
    [<CustomOperation("placementConstraintAdjustment")>] 
    member _.placementConstraintAdjustment<'t>(x: Types.AvaloniaNode<'t>, value: PopupPositionerConstraintAdjustment) =
        Types.dependencyProperty x Popup.PlacementConstraintAdjustmentProperty value

    [<CustomOperation("placementGravity")>] 
    member _.placementGravity<'t>(x: Types.AvaloniaNode<'t>, value: PopupGravity) =
        Types.dependencyProperty x Popup.PlacementGravityProperty value

    [<CustomOperation("placementRect")>] 
    member _.placementRect<'t>(x: Types.AvaloniaNode<'t>, value: Rect) =
        Types.dependencyProperty x Popup.PlacementRectProperty value

    [<CustomOperation("placementMode")>] 
    member _.placementMode<'t>(x: Types.AvaloniaNode<'t>, value: PlacementMode) =
        Types.dependencyProperty x Popup.PlacementModeProperty value
        
    [<CustomOperation("placementTarget")>] 
    member _.placementTarget<'t>(x: Types.AvaloniaNode<'t>, value: Control) =
        Types.dependencyProperty x Popup.PlacementTargetProperty value
        
    [<CustomOperation("verticalOffset")>] 
    member _.verticalOffset<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x Popup.VerticalOffsetProperty value
        
    [<CustomOperation("horizontalOffset")>] 
    member _.horizontalOffset<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x Popup.HorizontalOffsetProperty value

    [<CustomOperation("windowManagerAddShadowHint")>] 
    member _.windowManagerAddShadowHint<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x Popup.WindowManagerAddShadowHintProperty value