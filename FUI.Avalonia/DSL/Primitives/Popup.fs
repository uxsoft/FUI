module FUI.Avalonia.Popup

open Avalonia
open Avalonia.Controls
open Avalonia.Controls.Primitives
open Avalonia.Controls.Primitives.PopupPositioning
open Avalonia.FuncUI.Builder
open FUI.UiBuilder
open FUI.Avalonia.Control
open Avalonia.FuncUI.Types
open System

type PopupBuilder<'t when 't :> Popup>() =
    inherit ControlBuilder<'t>()

    [<CustomOperation("child")>] 
    member _.child<'t, 'c when 't :> Track and 'c :> obj>(x: Types.AvaloniaNode<'t>, value: 'c) =
        let prop = 
            match box value with
            | :? IView as view -> AttrBuilder<'t>.CreateContentSingle(Popup.ChildProperty, Some view)
            | :? string as text -> AttrBuilder<'t>.CreateProperty<string>(Popup.ChildProperty, text, ValueNone)
            | _ -> AttrBuilder<'t>.CreateProperty<obj>(Popup.ChildProperty, value, ValueNone)
        
        x @@ [ prop ] 

    [<CustomOperation("isOpen")>] 
    member _.isOpen<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x<bool>(Popup.IsOpenProperty, value, ValueNone) ]
        
    [<CustomOperation("isLightDismissEnabled")>] 
    member _.isLightDismissEnabled<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x<bool>(Popup.IsLightDismissEnabledProperty, value, ValueNone) ]
        
    [<CustomOperation("topmost")>] 
    member _.topmost<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x<bool>(Popup.TopmostProperty, value, ValueNone) ]

    [<CustomOperation("placementAnchor")>] 
    member _.placementAnchor<'t>(x: Types.AvaloniaNode<'t>, value: PopupAnchor) =
        Types.dependencyProperty x<PopupAnchor>(Popup.PlacementModeProperty, value, ValueNone) ]
        
    [<CustomOperation("placementConstraintAdjustment")>] 
    member _.placementConstraintAdjustment<'t>(x: Types.AvaloniaNode<'t>, value: PopupPositionerConstraintAdjustment) =
        Types.dependencyProperty x<PopupPositionerConstraintAdjustment>(Popup.PlacementConstraintAdjustmentProperty, value, ValueNone) ]

    [<CustomOperation("placementGravity")>] 
    member _.placementGravity<'t>(x: Types.AvaloniaNode<'t>, value: PopupGravity) =
        Types.dependencyProperty x<PopupGravity>(Popup.PlacementGravityProperty, value, ValueNone) ]

    [<CustomOperation("placementRect")>] 
    member _.placementRect<'t>(x: Types.AvaloniaNode<'t>, value: Rect) =
        Types.dependencyProperty x<Rect Nullable>(Popup.PlacementRectProperty, Nullable value, ValueNone) ]

    [<CustomOperation("placementMode")>] 
    member _.placementMode<'t>(x: Types.AvaloniaNode<'t>, value: PlacementMode) =
        Types.dependencyProperty x<PlacementMode>(Popup.PlacementModeProperty, value, ValueNone) ]
        
    [<CustomOperation("placementTarget")>] 
    member _.placementTarget<'t>(x: Types.AvaloniaNode<'t>, value: Control) =
        Types.dependencyProperty x<Control>(Popup.PlacementTargetProperty, value, ValueNone) ]
        
    [<CustomOperation("verticalOffset")>] 
    member _.verticalOffset<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x<double>(Popup.VerticalOffsetProperty, value, ValueNone) ]
        
    [<CustomOperation("horizontalOffset")>] 
    member _.horizontalOffset<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x<double>(Popup.HorizontalOffsetProperty, value, ValueNone) ]

    [<CustomOperation("windowManagerAddShadowHint")>] 
    member _.windowManagerAddShadowHint<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x<bool>(Popup.WindowManagerAddShadowHintProperty, value, ValueNone) ]