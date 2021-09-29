module FUI.Avalonia.ProgressBar

open FUI.UiBuilder
open FUI.Avalonia.RangeBase
open Avalonia.Layout
open Avalonia.Controls
open Avalonia.FuncUI.Builder

type ProgressBarBuilder<'t when 't :> ProgressBar>() =
    inherit RangeBaseBuilder<'t>()

    [<CustomOperation("isIndeterminate")>]
    member _.isIndeterminate<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x<bool>(ProgressBar.IsIndeterminateProperty, value, ValueNone) ]

    [<CustomOperation("orientation")>]
    member _.orientation<'t>(x: Types.AvaloniaNode<'t>, value: Orientation) =
        Types.dependencyProperty x<Orientation>(ProgressBar.OrientationProperty, value, ValueNone) ]

    [<CustomOperation("showProgressText")>]
    member _.showProgressText<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x<bool>(ProgressBar.ShowProgressTextProperty, value, ValueNone) ]
