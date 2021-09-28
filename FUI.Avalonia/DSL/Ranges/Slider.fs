module Avalonia.FuncUI.Experiments.DSL.Slider

open Avalonia.Collections
open Avalonia.Controls
open FUI.UiBuilder
open Avalonia.FuncUI.Experiments.DSL.RangeBase
open Avalonia.Layout
open Avalonia.FuncUI.Builder

type SliderBuilder<'t when 't :> Slider>() =
    inherit RangeBaseBuilder<'t>()

    /// <summary>
    /// Sets the orientation of a <see cref="Slider"/>.
    /// </summary>
    [<CustomOperation("orientation")>]
    member _.orientation<'t>(x: Node<_, _>, value: Orientation) =
        Types.dependencyProperty<Orientation>(Slider.OrientationProperty, value, ValueNone) ]

    /// <summary>
    /// Sets a value that indicates whether the <see cref="Slider"/> automatically moves the <see cref="Thumb"/> to the closest tick mark.
    /// </summary>
    [<CustomOperation("isSnapToTickEnabled")>]
    member _.isSnapToTickEnabled<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(Slider.IsSnapToTickEnabledProperty, value, ValueNone) ]

    /// <summary>
    /// Sets the interval between tick marks.
    /// </summary>
    [<CustomOperation("tickFrequency")>]
    member _.tickFrequency<'t>(x: Node<_, _>, value: float) =
        Types.dependencyProperty<float>(Slider.TickFrequencyProperty, value, ValueNone) ]

    [<CustomOperation("tickPlacement")>]
    member _.tickPlacement<'t>(x: Node<_, _>, value: TickPlacement) =
        Types.dependencyProperty<TickPlacement>(Slider.TickPlacementProperty, value, ValueNone) ]

    [<CustomOperation("ticks")>]
    member _.ticks<'t>(x: Node<_, _>, value: float seq) =
        Types.dependencyProperty<float AvaloniaList>(Slider.TicksProperty, AvaloniaList value, ValueNone) ]