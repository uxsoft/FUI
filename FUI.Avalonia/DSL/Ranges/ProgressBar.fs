module FUI.Avalonia.ProgressBar

open FUI.Avalonia.RangeBase
open Avalonia.Layout
open Avalonia.Controls

type ProgressBarBuilder<'t when 't :> ProgressBar and 't : equality>() =
    inherit RangeBaseBuilder<'t>()

    /// bool | ObservableValue<bool>
    [<CustomOperation("isIndeterminate")>]
    member _.isIndeterminate<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x ProgressBar.IsIndeterminateProperty, value

    /// Orientation | ObservableValue<Orientation>
    [<CustomOperation("orientation")>]
    member _.orientation<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x ProgressBar.OrientationProperty, value

    /// bool | ObservableValue<bool>
    [<CustomOperation("showProgressText")>]
    member _.showProgressText<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x ProgressBar.ShowProgressTextProperty, value
