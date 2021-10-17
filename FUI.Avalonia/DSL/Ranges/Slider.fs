module FUI.Avalonia.Slider

open Avalonia.Collections
open Avalonia.Controls
open FUI.Avalonia.RangeBase
open Avalonia.Layout

type SliderBuilder<'t when 't :> Slider and 't : equality>() =
    inherit RangeBaseBuilder<'t>()

    /// Orientation | ObservableValue<Orientation>
    [<CustomOperation("orientation")>]
    member _.orientation<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Slider.OrientationProperty value

    /// bool | ObservableValue<bool>
    [<CustomOperation("isSnapToTickEnabled")>]
    member _.isSnapToTickEnabled<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Slider.IsSnapToTickEnabledProperty value

    /// float | ObservableValue<float>
    [<CustomOperation("tickFrequency")>]
    member _.tickFrequency<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Slider.TickFrequencyProperty value

    /// TickPlacement | ObservableValue<TickPlacement>
    [<CustomOperation("tickPlacement")>]
    member _.tickPlacement<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Slider.TickPlacementProperty value

    /// float seq | ObservableValue<float seq>
    [<CustomOperation("ticks")>]
    member _.ticks<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Slider.TicksProperty (AvaloniaList value)