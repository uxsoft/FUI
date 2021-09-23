module Avalonia.FuncUI.Experiments.DSL.SplitView

open Avalonia.Controls
open FUI.UIBuilder
open Avalonia.FuncUI.Experiments.DSL.ContentControl
open Avalonia.Media
open Avalonia.FuncUI.Types
open Avalonia.FuncUI.Builder

type SplitViewBuilder<'t when 't :> SplitView>() = 
    inherit ContentControlBuilder<'t>()

    [<CustomOperation("compactPaneLengthProperty")>]
    member _.compactPaneLengthProperty<'t>(x: Element, value: float) =
        x @@ [ AttrBuilder<'t>.CreateProperty<float>(SplitView.CompactPaneLengthProperty, value, ValueNone) ]

    [<CustomOperation("displayMode")>]
    member _.displayMode<'t>(x: Element, value: SplitViewDisplayMode) =
        x @@ [ AttrBuilder<'t>.CreateProperty<SplitViewDisplayMode>(SplitView.DisplayModeProperty, value, ValueNone) ]

    [<CustomOperation("isPaneOpen")>]
    member _.isPaneOpen<'t>(x: Element, value: bool) =
        x @@ [ AttrBuilder<'t>.CreateProperty<bool>(SplitView.IsPaneOpenProperty, value, ValueNone) ]

    [<CustomOperation("openPaneLength")>]
    member _.openPaneLength<'t>(x: Element, value: float) =
        x @@ [ AttrBuilder<'t>.CreateProperty<float>(SplitView.OpenPaneLengthProperty, value, ValueNone) ]

    [<CustomOperation("paneBackground")>]
    member _.paneBackground<'t>(x: Element, value: IBrush) =
        x @@ [ AttrBuilder<'t>.CreateProperty<IBrush>(SplitView.PaneBackgroundProperty, value, ValueNone) ]

    [<CustomOperation("panePlacement")>]
    member _.panePlacement<'t>(x: Element, value: SplitViewPanePlacement) =
        x @@ [ AttrBuilder<'t>.CreateProperty<SplitViewPanePlacement>(SplitView.PanePlacementProperty, value, ValueNone) ]

    [<CustomOperation("pane")>]
    member _.pane<'t>(x: Element, value: IView) =
        x @@ [ AttrBuilder<'t>.CreateContentSingle(SplitView.PaneProperty, Some value) ]

    [<CustomOperation("useLightDismissOverlayMode")>]
    member _.useLightDismissOverlayMode<'t>(x: Element, value: bool) =
        x @@ [ AttrBuilder<'t>.CreateProperty<bool>(SplitView.UseLightDismissOverlayModeProperty, value, ValueNone) ]

    [<CustomOperation("templateSettings")>]
    member _.templateSettings<'t>(x: Element, value: SplitViewTemplateSettings) =
        x @@ [ AttrBuilder<'t>.CreateProperty<SplitViewTemplateSettings>(SplitView.TemplateSettingsProperty, value, ValueNone) ]
