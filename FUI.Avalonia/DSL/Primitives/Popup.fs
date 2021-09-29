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
    member _.child<'t, 'c when 't :> Track and 'c :> obj>(x: Node<_, _>, value: 'c) =
        let prop = 
            match box value with
            | :? IView as view -> AttrBuilder<'t>.CreateContentSingle(Popup.ChildProperty, Some view)
            | :? string as text -> AttrBuilder<'t>.CreateProperty<string>(Popup.ChildProperty, text, ValueNone)
            | _ -> AttrBuilder<'t>.CreateProperty<obj>(Popup.ChildProperty, value, ValueNone)
        
        x @@ [ prop ] 

    [<CustomOperation("isOpen")>] 
    member _.isOpen<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(Popup.IsOpenProperty, value, ValueNone) ]
        
    [<CustomOperation("isLightDismissEnabled")>] 
    member _.isLightDismissEnabled<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(Popup.IsLightDismissEnabledProperty, value, ValueNone) ]
        
    [<CustomOperation("topmost")>] 
    member _.topmost<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(Popup.TopmostProperty, value, ValueNone) ]

    [<CustomOperation("placementAnchor")>] 
    member _.placementAnchor<'t>(x: Node<_, _>, value: PopupAnchor) =
        Types.dependencyProperty<PopupAnchor>(Popup.PlacementModeProperty, value, ValueNone) ]
        
    [<CustomOperation("placementConstraintAdjustment")>] 
    member _.placementConstraintAdjustment<'t>(x: Node<_, _>, value: PopupPositionerConstraintAdjustment) =
        Types.dependencyProperty<PopupPositionerConstraintAdjustment>(Popup.PlacementConstraintAdjustmentProperty, value, ValueNone) ]

    [<CustomOperation("placementGravity")>] 
    member _.placementGravity<'t>(x: Node<_, _>, value: PopupGravity) =
        Types.dependencyProperty<PopupGravity>(Popup.PlacementGravityProperty, value, ValueNone) ]

    [<CustomOperation("placementRect")>] 
    member _.placementRect<'t>(x: Node<_, _>, value: Rect) =
        Types.dependencyProperty<Rect Nullable>(Popup.PlacementRectProperty, Nullable value, ValueNone) ]

    [<CustomOperation("placementMode")>] 
    member _.placementMode<'t>(x: Node<_, _>, value: PlacementMode) =
        Types.dependencyProperty<PlacementMode>(Popup.PlacementModeProperty, value, ValueNone) ]
        
    [<CustomOperation("placementTarget")>] 
    member _.placementTarget<'t>(x: Node<_, _>, value: Control) =
        Types.dependencyProperty<Control>(Popup.PlacementTargetProperty, value, ValueNone) ]
        
    [<CustomOperation("verticalOffset")>] 
    member _.verticalOffset<'t>(x: Node<_, _>, value: double) =
        Types.dependencyProperty<double>(Popup.VerticalOffsetProperty, value, ValueNone) ]
        
    [<CustomOperation("horizontalOffset")>] 
    member _.horizontalOffset<'t>(x: Node<_, _>, value: double) =
        Types.dependencyProperty<double>(Popup.HorizontalOffsetProperty, value, ValueNone) ]

    [<CustomOperation("windowManagerAddShadowHint")>] 
    member _.windowManagerAddShadowHint<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(Popup.WindowManagerAddShadowHintProperty, value, ValueNone) ]