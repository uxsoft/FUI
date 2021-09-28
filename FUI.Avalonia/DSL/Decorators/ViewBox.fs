module Avalonia.FuncUI.Experiments.DSL.ViewBox

open Avalonia.Controls
open FUI.UiBuilder
open Avalonia.FuncUI.Experiments.DSL.Decorator
open Avalonia.Media
open Avalonia.FuncUI.Builder

type ViewBoxBuilder<'t when 't :> Viewbox>() =
    inherit DecoratorBuilder<'t>()

    /// <summary>
    /// Sets the stretch mode, which determines how child fits into the available space.
    /// </summary>
    [<CustomOperation("stretch")>]
    member _.stretch<'t>(x: Node<_, _>, value: Stretch) =
        Types.dependencyProperty<Stretch>(Viewbox.StretchProperty, value, ValueNone) ]
