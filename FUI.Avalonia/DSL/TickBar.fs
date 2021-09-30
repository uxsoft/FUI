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
    
    [<CustomOperation("fill")>] 
    member _.fill<'t>(x: Types.AvaloniaNode<'t>, value: IBrush) =
        Types.dependencyProperty x TickBar.FillProperty value

    [<CustomOperation("isDirectionReversed")>] 
    member _.isDirectionReversed<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x TickBar.IsDirectionReversedProperty value

    [<CustomOperation("maximum")>] 
    member _.maximum<'t>(x: Types.AvaloniaNode<'t>, value: float) =
        Types.dependencyProperty x TickBar.MaximumProperty value

    [<CustomOperation("minimum")>] 
    member _.minimum<'t>(x: Types.AvaloniaNode<'t>, value: float) =
        Types.dependencyProperty x TickBar.MinimumProperty value

    [<CustomOperation("orientation")>] 
    member _.orientation<'t>(x: Types.AvaloniaNode<'t>, value: Orientation) =
        Types.dependencyProperty x TickBar.OrientationProperty value

    [<CustomOperation("placement")>] 
    member _.placement<'t>(x: Types.AvaloniaNode<'t>, value: TickBarPlacement) =
        Types.dependencyProperty x TickBar.PlacementProperty value

    [<CustomOperation("reservedSpace")>] 
    member _.reservedSpace<'t>(x: Types.AvaloniaNode<'t>, value: Rect) =
        Types.dependencyProperty x TickBar.ReservedSpaceProperty value

    [<CustomOperation("tickFrequency")>] 
    member _.tickFrequency<'t>(x: Types.AvaloniaNode<'t>, value: float) =
        Types.dependencyProperty x TickBar.TickFrequencyProperty value

    [<CustomOperation("ticks")>] 
    member _.ticks<'t>(x: Types.AvaloniaNode<'t>, value: float seq) =
        Types.dependencyProperty x TickBar.TicksProperty (AvaloniaList value)
