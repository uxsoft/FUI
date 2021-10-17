namespace FUI.Avalonia.TickBar

open Avalonia
open Avalonia.Collections
open Avalonia.Controls
open FUI.Avalonia
open FUI.Avalonia.Control
open Avalonia.Media
open Avalonia.Layout
 
type TickBarBuilder<'t when 't :> TickBar and 't : equality>() =
    inherit ControlBuilder<'t>()
    
    /// IBrush | ObservableValue<IBrush>
    [<CustomOperation("fill")>] 
    member _.fill<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TickBar.FillProperty value

    /// bool | ObservableValue<bool>
    [<CustomOperation("isDirectionReversed")>] 
    member _.isDirectionReversed<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TickBar.IsDirectionReversedProperty value

    /// float | ObservableValue<float>
    [<CustomOperation("maximum")>] 
    member _.maximum<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TickBar.MaximumProperty value

    /// float | ObservableValue<float>
    [<CustomOperation("minimum")>] 
    member _.minimum<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TickBar.MinimumProperty value

    /// Orientation | ObservableValue<Orientation>
    [<CustomOperation("orientation")>] 
    member _.orientation<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TickBar.OrientationProperty value

    /// TickBarPlacement | ObservableValue<TickBarPlacement>
    [<CustomOperation("placement")>] 
    member _.placement<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TickBar.PlacementProperty value

    /// Rect | ObservableValue<Rect>
    [<CustomOperation("reservedSpace")>] 
    member _.reservedSpace<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TickBar.ReservedSpaceProperty value

    /// float | ObservableValue<float>
    [<CustomOperation("tickFrequency")>] 
    member _.tickFrequency<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TickBar.TickFrequencyProperty value

    /// float seq | ObservableValue<float seq>
    [<CustomOperation("ticks")>] 
    member _.ticks<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TickBar.TicksProperty (AvaloniaList value)
