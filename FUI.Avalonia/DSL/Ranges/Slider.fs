module FUI.Avalonia.Slider

open Avalonia.Collections
open Avalonia.Controls
open FUI.Avalonia.RangeBase
open Avalonia.Layout

type SliderBuilder<'t when 't :> Slider and 't : equality>() =
    inherit RangeBaseBuilder<'t>()

    /// <summary>
    /// Sets the orientation of a <see cref="Slider"/>.
    /// </summary>
    [<CustomOperation("orientation")>]
    member _.orientation<'t>(x: Types.AvaloniaNode<'t>, value: Orientation) =
        Types.dependencyProperty x Slider.OrientationProperty value

    /// <summary>
    /// Sets a value that indicates whether the <see cref="Slider"/> automatically moves the <see cref="Thumb"/> to the closest tick mark.
    /// </summary>
    [<CustomOperation("isSnapToTickEnabled")>]
    member _.isSnapToTickEnabled<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x Slider.IsSnapToTickEnabledProperty value

    /// <summary>
    /// Sets the interval between tick marks.
    /// </summary>
    [<CustomOperation("tickFrequency")>]
    member _.tickFrequency<'t>(x: Types.AvaloniaNode<'t>, value: float) =
        Types.dependencyProperty x Slider.TickFrequencyProperty value

    [<CustomOperation("tickPlacement")>]
    member _.tickPlacement<'t>(x: Types.AvaloniaNode<'t>, value: TickPlacement) =
        Types.dependencyProperty x Slider.TickPlacementProperty value

    [<CustomOperation("ticks")>]
    member _.ticks<'t>(x: Types.AvaloniaNode<'t>, value: float seq) =
        Types.dependencyProperty x Slider.TicksProperty (AvaloniaList value)