module FUI.Avalonia.ProgressBar

open FUI.Avalonia.RangeBase
open Avalonia.Layout
open Avalonia.Controls

type ProgressBarBuilder<'t when 't :> ProgressBar and 't : equality>() =
    inherit RangeBaseBuilder<'t>()

    [<CustomOperation("isIndeterminate")>]
    member _.isIndeterminate<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x ProgressBar.IsIndeterminateProperty, value

    [<CustomOperation("orientation")>]
    member _.orientation<'t>(x: Types.AvaloniaNode<'t>, value: Orientation) =
        Types.dependencyProperty x ProgressBar.OrientationProperty, value

    [<CustomOperation("showProgressText")>]
    member _.showProgressText<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x ProgressBar.ShowProgressTextProperty, value
