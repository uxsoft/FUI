module FUI.Avalonia.ViewBox

open Avalonia.Controls
open FUI.Avalonia.Decorator
open Avalonia.Media

type ViewBoxBuilder<'t when 't :> Viewbox and 't : equality>() =
    inherit DecoratorBuilder<'t>()

    /// <summary>
    /// Sets the stretch mode, which determines how child fits into the available space.
    /// </summary>
    [<CustomOperation("stretch")>]
    member _.stretch<'t>(x: Types.AvaloniaNode<'t>, value: Stretch) =
        Types.dependencyProperty x Viewbox.StretchProperty value
