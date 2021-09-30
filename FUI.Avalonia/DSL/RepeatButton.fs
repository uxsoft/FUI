﻿module Avalonia.FuncUI.Experiments.DSL.RepeatButton

open Avalonia.Controls
open Avalonia.FuncUI.Experiments.DSL.Button
open FUI.UIBuilder
open Avalonia.FuncUI.Builder

type RepeatButtonBuilder<'t when 't :> RepeatButton>() =
    inherit ButtonBuilder<'t>()

    /// <summary>
    /// Sets the amount of time, in milliseconds, of repeating clicks.
    /// </summary>
    [<CustomOperation("interval")>]
    member _.interval<'t>(x: Element, value: int) =
        x @@ [ AttrBuilder<'t>.CreateProperty<int>(RepeatButton.IntervalProperty, value, ValueNone) ]
    
    /// <summary>
    /// Sets the amount of time, in milliseconds, to wait before repeating begins.
    /// </summary>
    [<CustomOperation("delay")>]
    member _.delay<'t>(x: Element, value: int) =
        x @@ [ AttrBuilder<'t>.CreateProperty<int>(RepeatButton.DelayProperty, value, ValueNone) ]