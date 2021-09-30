﻿module FUI.Avalonia.ViewBox

open Avalonia.Controls
open FUI.UiBuilder
open FUI.Avalonia.Decorator
open Avalonia.Media
open Avalonia.FuncUI.Builder

type ViewBoxBuilder<'t when 't :> Viewbox>() =
    inherit DecoratorBuilder<'t>()

    /// <summary>
    /// Sets the stretch mode, which determines how child fits into the available space.
    /// </summary>
    [<CustomOperation("stretch")>]
    member _.stretch<'t>(x: Types.AvaloniaNode<'t>, value: Stretch) =
        Types.dependencyProperty x<Stretch>(Viewbox.StretchProperty, value, ValueNone) ]