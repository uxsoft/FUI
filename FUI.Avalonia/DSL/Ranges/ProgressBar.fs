module Avalonia.FuncUI.Experiments.DSL.ProgressBar

open FUI.UiBuilder
open Avalonia.FuncUI.Experiments.DSL.RangeBase
open Avalonia.Layout
open Avalonia.Controls
open Avalonia.FuncUI.Builder

type ProgressBarBuilder<'t when 't :> ProgressBar>() =
    inherit RangeBaseBuilder<'t>()

    [<CustomOperation("isIndeterminate")>]
    member _.isIndeterminate<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(ProgressBar.IsIndeterminateProperty, value, ValueNone) ]

    [<CustomOperation("orientation")>]
    member _.orientation<'t>(x: Node<_, _>, value: Orientation) =
        Types.dependencyProperty<Orientation>(ProgressBar.OrientationProperty, value, ValueNone) ]

    [<CustomOperation("showProgressText")>]
    member _.showProgressText<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(ProgressBar.ShowProgressTextProperty, value, ValueNone) ]
