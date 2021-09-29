module FUI.Avalonia.Slider

open Avalonia.Collections
open Avalonia.Controls
open FUI.UiBuilder
open FUI.Avalonia.RangeBase
open Avalonia.Layout
open Avalonia.FuncUI.Builder

type SliderBuilder<'t when 't :> Slider>() =
    inherit RangeBaseBuilder<'t>()

    /// <summary>
    /// Sets the orientation of a <see cref="Slider"/>.
    /// </summary>
    [<CustomOperation("orientation")>]
    member _.orientation<'t>(x: Types.AvaloniaNode<'t>, value: Orientation) =
        Types.dependencyProperty x<Orientation>(Slider.OrientationProperty, value, ValueNone) ]

    /// <summary>
    /// Sets a value that indicates whether the <see cref="Slider"/> automatically moves the <see cref="Thumb"/> to the closest tick mark.
    /// </summary>
    [<CustomOperation("isSnapToTickEnabled")>]
    member _.isSnapToTickEnabled<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x<bool>(Slider.IsSnapToTickEnabledProperty, value, ValueNone) ]

    /// <summary>
    /// Sets the interval between tick marks.
    /// </summary>
    [<CustomOperation("tickFrequency")>]
    member _.tickFrequency<'t>(x: Types.AvaloniaNode<'t>, value: float) =
        Types.dependencyProperty x<float>(Slider.TickFrequencyProperty, value, ValueNone) ]

    [<CustomOperation("tickPlacement")>]
    member _.tickPlacement<'t>(x: Types.AvaloniaNode<'t>, value: TickPlacement) =
        Types.dependencyProperty x<TickPlacement>(Slider.TickPlacementProperty, value, ValueNone) ]

    [<CustomOperation("ticks")>]
    member _.ticks<'t>(x: Types.AvaloniaNode<'t>, value: float seq) =
        Types.dependencyProperty x<float AvaloniaList>(Slider.TicksProperty, AvaloniaList value, ValueNone) ]