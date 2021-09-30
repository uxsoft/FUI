module FUI.Avalonia.SplitView

open Avalonia.Controls
open FUI.Avalonia.ContentControl
open Avalonia.Media

type SplitViewBuilder<'t when 't :> SplitView and 't : equality>() = 
    inherit ContentControlBuilder<'t>()

    [<CustomOperation("compactPaneLengthProperty")>]
    member _.compactPaneLengthProperty<'t>(x: Types.AvaloniaNode<'t>, value: float) =
        Types.dependencyProperty x SplitView.CompactPaneLengthProperty value

    [<CustomOperation("displayMode")>]
    member _.displayMode<'t>(x: Types.AvaloniaNode<'t>, value: SplitViewDisplayMode) =
        Types.dependencyProperty x SplitView.DisplayModeProperty value

    [<CustomOperation("isPaneOpen")>]
    member _.isPaneOpen<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x SplitView.IsPaneOpenProperty value

    [<CustomOperation("openPaneLength")>]
    member _.openPaneLength<'t>(x: Types.AvaloniaNode<'t>, value: float) =
        Types.dependencyProperty x SplitView.OpenPaneLengthProperty value

    [<CustomOperation("paneBackground")>]
    member _.paneBackground<'t>(x: Types.AvaloniaNode<'t>, value: IBrush) =
        Types.dependencyProperty x SplitView.PaneBackgroundProperty value

    [<CustomOperation("panePlacement")>]
    member _.panePlacement<'t>(x: Types.AvaloniaNode<'t>, value: SplitViewPanePlacement) =
        Types.dependencyProperty x SplitView.PanePlacementProperty value

    [<CustomOperation("pane")>]
    member _.pane<'t>(x: Types.AvaloniaNode<'t>, value: obj) =
        Types.dependencyProperty x SplitView.PaneProperty value

    [<CustomOperation("useLightDismissOverlayMode")>]
    member _.useLightDismissOverlayMode<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x SplitView.UseLightDismissOverlayModeProperty value

    [<CustomOperation("templateSettings")>]
    member _.templateSettings<'t>(x: Types.AvaloniaNode<'t>, value: SplitViewTemplateSettings) =
        Types.dependencyProperty x SplitView.TemplateSettingsProperty value
