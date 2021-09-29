namespace FUI.Avalonia.TickBar

open Avalonia
open Avalonia.Collections
open Avalonia.Controls
open FUI.UiBuilder
open FUI.Avalonia.Control
open Avalonia.Media
open Avalonia.Layout
open Avalonia.FuncUI.Builder
 
type TickBarBuilder<'t when 't :> TickBar>() =
    inherit ControlBuilder<'t>()
    
    [<CustomOperation("fill")>] 
    member _.fill<'t>(x: Types.AvaloniaNode<'t>, value: IBrush) =
        Types.dependencyProperty x<IBrush>(TickBar.FillProperty, value, ValueNone) ]

    [<CustomOperation("isDirectionReversed")>] 
    member _.isDirectionReversed<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x<bool>(TickBar.IsDirectionReversedProperty, value, ValueNone) ]

    [<CustomOperation("maximum")>] 
    member _.maximum<'t>(x: Types.AvaloniaNode<'t>, value: float) =
        Types.dependencyProperty x<float>(TickBar.MaximumProperty, value, ValueNone) ]

    [<CustomOperation("minimum")>] 
    member _.minimum<'t>(x: Types.AvaloniaNode<'t>, value: float) =
        Types.dependencyProperty x<float>(TickBar.MinimumProperty, value, ValueNone) ]

    [<CustomOperation("orientation")>] 
    member _.orientation<'t>(x: Types.AvaloniaNode<'t>, value: Orientation) =
        Types.dependencyProperty x<Orientation>(TickBar.OrientationProperty, value, ValueNone) ]

    [<CustomOperation("placement")>] 
    member _.placement<'t>(x: Types.AvaloniaNode<'t>, value: TickBarPlacement) =
        Types.dependencyProperty x<TickBarPlacement>(TickBar.PlacementProperty, value, ValueNone) ]

    [<CustomOperation("reservedSpace")>] 
    member _.reservedSpace<'t>(x: Types.AvaloniaNode<'t>, value: Rect) =
        Types.dependencyProperty x<Rect>(TickBar.ReservedSpaceProperty, value, ValueNone) ]

    [<CustomOperation("tickFrequency")>] 
    member _.tickFrequency<'t>(x: Types.AvaloniaNode<'t>, value: float) =
        Types.dependencyProperty x<float>(TickBar.TickFrequencyProperty, value, ValueNone) ]

    [<CustomOperation("ticks")>] 
    member _.ticks<'t>(x: Types.AvaloniaNode<'t>, value: float seq) =
        Types.dependencyProperty x<float AvaloniaList>(TickBar.TicksProperty, AvaloniaList value, ValueNone) ]
