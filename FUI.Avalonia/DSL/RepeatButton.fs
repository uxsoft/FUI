module FUI.Avalonia.RepeatButton

open Avalonia.Controls
open FUI.Avalonia.Button
open FUI.UiBuilder
open Avalonia.FuncUI.Builder

type RepeatButtonBuilder<'t when 't :> RepeatButton>() =
    inherit ButtonBuilder<'t>()

    /// <summary>
    /// Sets the amount of time, in milliseconds, of repeating clicks.
    /// </summary>
    [<CustomOperation("interval")>]
    member _.interval<'t>(x: Types.AvaloniaNode<'t>, value: int) =
        Types.dependencyProperty x<int>(RepeatButton.IntervalProperty, value, ValueNone) ]
    
    /// <summary>
    /// Sets the amount of time, in milliseconds, to wait before repeating begins.
    /// </summary>
    [<CustomOperation("delay")>]
    member _.delay<'t>(x: Types.AvaloniaNode<'t>, value: int) =
        Types.dependencyProperty x<int>(RepeatButton.DelayProperty, value, ValueNone) ]