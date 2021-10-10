module FUI.Avalonia.ViewBox

open Avalonia.Controls
open FUI.Avalonia.Decorator
open Avalonia.Media

type ViewBoxBuilder<'t when 't :> Viewbox and 't : equality>() =
    inherit DecoratorBuilder<'t>()

    /// Stretch | ObservableValue<Stretch>
    [<CustomOperation("stretch")>]
    member _.stretch<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x Viewbox.StretchProperty value
