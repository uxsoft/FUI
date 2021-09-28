module Avalonia.FuncUI.Experiments.DSL.SplitView

open Avalonia.Controls
open FUI.UiBuilder
open Avalonia.FuncUI.Experiments.DSL.ContentControl
open Avalonia.Media
open Avalonia.FuncUI.Types
open Avalonia.FuncUI.Builder

type SplitViewBuilder<'t when 't :> SplitView>() = 
    inherit ContentControlBuilder<'t>()

    [<CustomOperation("compactPaneLengthProperty")>]
    member _.compactPaneLengthProperty<'t>(x: Node<_, _>, value: float) =
        Types.dependencyProperty<float>(SplitView.CompactPaneLengthProperty, value, ValueNone) ]

    [<CustomOperation("displayMode")>]
    member _.displayMode<'t>(x: Node<_, _>, value: SplitViewDisplayMode) =
        Types.dependencyProperty<SplitViewDisplayMode>(SplitView.DisplayModeProperty, value, ValueNone) ]

    [<CustomOperation("isPaneOpen")>]
    member _.isPaneOpen<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(SplitView.IsPaneOpenProperty, value, ValueNone) ]

    [<CustomOperation("openPaneLength")>]
    member _.openPaneLength<'t>(x: Node<_, _>, value: float) =
        Types.dependencyProperty<float>(SplitView.OpenPaneLengthProperty, value, ValueNone) ]

    [<CustomOperation("paneBackground")>]
    member _.paneBackground<'t>(x: Node<_, _>, value: IBrush) =
        Types.dependencyProperty<IBrush>(SplitView.PaneBackgroundProperty, value, ValueNone) ]

    [<CustomOperation("panePlacement")>]
    member _.panePlacement<'t>(x: Node<_, _>, value: SplitViewPanePlacement) =
        Types.dependencyProperty<SplitViewPanePlacement>(SplitView.PanePlacementProperty, value, ValueNone) ]

    [<CustomOperation("pane")>]
    member _.pane<'t>(x: Node<_, _>, value: IView) =
        x @@ [ AttrBuilder<'t>.CreateContentSingle(SplitView.PaneProperty, Some value) ]

    [<CustomOperation("useLightDismissOverlayMode")>]
    member _.useLightDismissOverlayMode<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(SplitView.UseLightDismissOverlayModeProperty, value, ValueNone) ]

    [<CustomOperation("templateSettings")>]
    member _.templateSettings<'t>(x: Node<_, _>, value: SplitViewTemplateSettings) =
        Types.dependencyProperty<SplitViewTemplateSettings>(SplitView.TemplateSettingsProperty, value, ValueNone) ]
