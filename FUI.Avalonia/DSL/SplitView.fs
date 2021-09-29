module FUI.Avalonia.SplitView

open Avalonia.Controls
open FUI.UiBuilder
open FUI.Avalonia.ContentControl
open Avalonia.Media
open Avalonia.FuncUI.Types
open Avalonia.FuncUI.Builder

type SplitViewBuilder<'t when 't :> SplitView>() = 
    inherit ContentControlBuilder<'t>()

    [<CustomOperation("compactPaneLengthProperty")>]
    member _.compactPaneLengthProperty<'t>(x: Types.AvaloniaNode<'t>, value: float) =
        Types.dependencyProperty x<float>(SplitView.CompactPaneLengthProperty, value, ValueNone) ]

    [<CustomOperation("displayMode")>]
    member _.displayMode<'t>(x: Types.AvaloniaNode<'t>, value: SplitViewDisplayMode) =
        Types.dependencyProperty x<SplitViewDisplayMode>(SplitView.DisplayModeProperty, value, ValueNone) ]

    [<CustomOperation("isPaneOpen")>]
    member _.isPaneOpen<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x<bool>(SplitView.IsPaneOpenProperty, value, ValueNone) ]

    [<CustomOperation("openPaneLength")>]
    member _.openPaneLength<'t>(x: Types.AvaloniaNode<'t>, value: float) =
        Types.dependencyProperty x<float>(SplitView.OpenPaneLengthProperty, value, ValueNone) ]

    [<CustomOperation("paneBackground")>]
    member _.paneBackground<'t>(x: Types.AvaloniaNode<'t>, value: IBrush) =
        Types.dependencyProperty x<IBrush>(SplitView.PaneBackgroundProperty, value, ValueNone) ]

    [<CustomOperation("panePlacement")>]
    member _.panePlacement<'t>(x: Types.AvaloniaNode<'t>, value: SplitViewPanePlacement) =
        Types.dependencyProperty x<SplitViewPanePlacement>(SplitView.PanePlacementProperty, value, ValueNone) ]

    [<CustomOperation("pane")>]
    member _.pane<'t>(x: Types.AvaloniaNode<'t>, value: IView) =
        x @@ [ AttrBuilder<'t>.CreateContentSingle(SplitView.PaneProperty, Some value) ]

    [<CustomOperation("useLightDismissOverlayMode")>]
    member _.useLightDismissOverlayMode<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x<bool>(SplitView.UseLightDismissOverlayModeProperty, value, ValueNone) ]

    [<CustomOperation("templateSettings")>]
    member _.templateSettings<'t>(x: Types.AvaloniaNode<'t>, value: SplitViewTemplateSettings) =
        Types.dependencyProperty x<SplitViewTemplateSettings>(SplitView.TemplateSettingsProperty, value, ValueNone) ]
