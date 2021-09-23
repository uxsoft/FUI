module Avalonia.FuncUI.Experiments.DSL.Popup

open Avalonia
open Avalonia.Controls
open Avalonia.Controls.Primitives
open Avalonia.Controls.Primitives.PopupPositioning
open Avalonia.FuncUI.Builder
open FUI.UIBuilder
open Avalonia.FuncUI.Experiments.DSL.Control
open Avalonia.FuncUI.Types
open System

type PopupBuilder<'t when 't :> Popup>() =
    inherit ControlBuilder<'t>()

    [<CustomOperation("child")>] 
    member _.child<'t, 'c when 't :> Track and 'c :> obj>(x: Element, value: 'c) =
        let prop = 
            match box value with
            | :? IView as view -> AttrBuilder<'t>.CreateContentSingle(Popup.ChildProperty, Some view)
            | :? string as text -> AttrBuilder<'t>.CreateProperty<string>(Popup.ChildProperty, text, ValueNone)
            | _ -> AttrBuilder<'t>.CreateProperty<obj>(Popup.ChildProperty, value, ValueNone)
        
        x @@ [ prop ] 

    [<CustomOperation("isOpen")>] 
    member _.isOpen<'t>(x: Element, value: bool) =
        x @@ [ AttrBuilder<'t>.CreateProperty<bool>(Popup.IsOpenProperty, value, ValueNone) ]
        
    [<CustomOperation("isLightDismissEnabled")>] 
    member _.isLightDismissEnabled<'t>(x: Element, value: bool) =
        x @@ [ AttrBuilder<'t>.CreateProperty<bool>(Popup.IsLightDismissEnabledProperty, value, ValueNone) ]
        
    [<CustomOperation("topmost")>] 
    member _.topmost<'t>(x: Element, value: bool) =
        x @@ [ AttrBuilder<'t>.CreateProperty<bool>(Popup.TopmostProperty, value, ValueNone) ]

    [<CustomOperation("placementAnchor")>] 
    member _.placementAnchor<'t>(x: Element, value: PopupAnchor) =
        x @@ [ AttrBuilder<'t>.CreateProperty<PopupAnchor>(Popup.PlacementModeProperty, value, ValueNone) ]
        
    [<CustomOperation("placementConstraintAdjustment")>] 
    member _.placementConstraintAdjustment<'t>(x: Element, value: PopupPositionerConstraintAdjustment) =
        x @@ [ AttrBuilder<'t>.CreateProperty<PopupPositionerConstraintAdjustment>(Popup.PlacementConstraintAdjustmentProperty, value, ValueNone) ]

    [<CustomOperation("placementGravity")>] 
    member _.placementGravity<'t>(x: Element, value: PopupGravity) =
        x @@ [ AttrBuilder<'t>.CreateProperty<PopupGravity>(Popup.PlacementGravityProperty, value, ValueNone) ]

    [<CustomOperation("placementRect")>] 
    member _.placementRect<'t>(x: Element, value: Rect) =
        x @@ [ AttrBuilder<'t>.CreateProperty<Rect Nullable>(Popup.PlacementRectProperty, Nullable value, ValueNone) ]

    [<CustomOperation("placementMode")>] 
    member _.placementMode<'t>(x: Element, value: PlacementMode) =
        x @@ [ AttrBuilder<'t>.CreateProperty<PlacementMode>(Popup.PlacementModeProperty, value, ValueNone) ]
        
    [<CustomOperation("placementTarget")>] 
    member _.placementTarget<'t>(x: Element, value: Control) =
        x @@ [ AttrBuilder<'t>.CreateProperty<Control>(Popup.PlacementTargetProperty, value, ValueNone) ]
        
    [<CustomOperation("verticalOffset")>] 
    member _.verticalOffset<'t>(x: Element, value: double) =
        x @@ [ AttrBuilder<'t>.CreateProperty<double>(Popup.VerticalOffsetProperty, value, ValueNone) ]
        
    [<CustomOperation("horizontalOffset")>] 
    member _.horizontalOffset<'t>(x: Element, value: double) =
        x @@ [ AttrBuilder<'t>.CreateProperty<double>(Popup.HorizontalOffsetProperty, value, ValueNone) ]

    [<CustomOperation("windowManagerAddShadowHint")>] 
    member _.windowManagerAddShadowHint<'t>(x: Element, value: bool) =
        x @@ [ AttrBuilder<'t>.CreateProperty<bool>(Popup.WindowManagerAddShadowHintProperty, value, ValueNone) ]