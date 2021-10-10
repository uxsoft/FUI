module FUI.Avalonia.Popup

open Avalonia
open Avalonia.Controls
open Avalonia.Controls.Primitives
open Avalonia.Controls.Primitives.PopupPositioning
open FUI.Avalonia.Control

type PopupBuilder<'t when 't :> Popup and 't : equality>() =
    inherit ControlBuilder<'t>()

    /// obj | ObservableValue<obj>
    [<CustomOperation("child")>] 
    member _.child<'t, 'c when 't :> Track and 'c :> obj>(x: Types.AvaloniaNode<'t>, value: 'c) =
        Types.dependencyProperty x Popup.ChildProperty value

    /// bool | ObservableValue<bool>
    [<CustomOperation("isOpen")>] 
    member _.isOpen<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x Popup.IsOpenProperty, value
        
    /// bool | ObservableValue<bool>
    [<CustomOperation("isLightDismissEnabled")>] 
    member _.isLightDismissEnabled<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x Popup.IsLightDismissEnabledProperty value
        
    /// bool | ObservableValue<bool>
    [<CustomOperation("isTopmost")>] 
    member _.isTopmost<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x Popup.TopmostProperty value
    
    /// PopupAnchor | ObservableValue<PopupAnchor>
    [<CustomOperation("placementAnchor")>] 
    member _.placementAnchor<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x Popup.PlacementModeProperty value
    
    /// PopupPositionerConstraintAdjustment | ObservableValue<PopupPositionerConstraintAdjustment>
    [<CustomOperation("placementConstraintAdjustment")>] 
    member _.placementConstraintAdjustment<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x Popup.PlacementConstraintAdjustmentProperty value

    /// PopupGravity | ObservableValue<PopupGravity>
    [<CustomOperation("placementGravity")>] 
    member _.placementGravity<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x Popup.PlacementGravityProperty value

    /// Rect | ObservableValue<Rect>
    [<CustomOperation("placementRect")>] 
    member _.placementRect<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x Popup.PlacementRectProperty value

    /// PlacementMode | ObservableValue<PlacementMode>
    [<CustomOperation("placementMode")>] 
    member _.placementMode<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x Popup.PlacementModeProperty value
        
    /// Control | ObservableValue<Control>
    [<CustomOperation("placementTarget")>] 
    member _.placementTarget<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x Popup.PlacementTargetProperty value
    
    /// double | ObservableValue<double>
    [<CustomOperation("verticalOffset")>] 
    member _.verticalOffset<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x Popup.VerticalOffsetProperty value
        
    /// double | ObservableValue<double>
    [<CustomOperation("horizontalOffset")>] 
    member _.horizontalOffset<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x Popup.HorizontalOffsetProperty value

    /// bool | ObservableValue<bool>
    [<CustomOperation("windowManagerAddShadowHint")>] 
    member _.windowManagerAddShadowHint<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x Popup.WindowManagerAddShadowHintProperty value