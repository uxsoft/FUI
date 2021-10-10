module FUI.Avalonia.RepeatButton

open Avalonia.Controls
open FUI.Avalonia.Button

type RepeatButtonBuilder<'t when 't :> RepeatButton and 't : equality>() =
    inherit ButtonBuilder<'t>()

    /// int | ObservableValue<int>
    [<CustomOperation("interval")>]
    member _.interval<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x RepeatButton.IntervalProperty value
    
    /// int | ObservableValue<int>
    [<CustomOperation("delay")>]
    member _.delay<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x RepeatButton.DelayProperty value