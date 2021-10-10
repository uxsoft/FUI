module FUI.Avalonia.SplitView

open Avalonia.Controls
open FUI.Avalonia.ContentControl
open Avalonia.Media

type SplitViewBuilder<'t when 't :> SplitView and 't : equality>() = 
    inherit ContentControlBuilder<'t>()

    /// float | ObservableValue<float>
    [<CustomOperation("compactPaneLengthProperty")>]
    member _.compactPaneLengthProperty<'t, 'v>(x: Types.AvaloniaNode<'t>, value: float) =
        Types.dependencyProperty x SplitView.CompactPaneLengthProperty value

    /// SplitViewDisplayMode | ObservableValue<SplitViewDisplayMode>
    [<CustomOperation("displayMode")>]
    member _.displayMode<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x SplitView.DisplayModeProperty value

    /// bool | ObservableValue<bool>
    [<CustomOperation("isPaneOpen")>]
    member _.isPaneOpen<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x SplitView.IsPaneOpenProperty value

    /// float | ObservableValue<float>
    [<CustomOperation("openPaneLength")>]
    member _.openPaneLength<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x SplitView.OpenPaneLengthProperty value

    /// IBrush | ObservableValue<IBrush>
    [<CustomOperation("paneBackground")>]
    member _.paneBackground<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x SplitView.PaneBackgroundProperty value

    /// SplitViewPanePlacement | ObservableValue<SplitViewPanePlacement>
    [<CustomOperation("panePlacement")>]
    member _.panePlacement<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x SplitView.PanePlacementProperty value

    /// obj | ObservableValue<obj>
    [<CustomOperation("pane")>]
    member _.pane<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x SplitView.PaneProperty value

    /// bool | ObservableValue<bool>
    [<CustomOperation("useLightDismissOverlayMode")>]
    member _.useLightDismissOverlayMode<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x SplitView.UseLightDismissOverlayModeProperty value

    /// SplitViewTemplateSettings | ObservableValue<SplitViewTemplateSettings>
    [<CustomOperation("templateSettings")>]
    member _.templateSettings<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x SplitView.TemplateSettingsProperty value
