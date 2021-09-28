namespace Avalonia.FuncUI.Experiments.DSL.TickBar

open Avalonia
open Avalonia.Collections
open Avalonia.Controls
open FUI.UiBuilder
open Avalonia.FuncUI.Experiments.DSL.Control
open Avalonia.Media
open Avalonia.Layout
open Avalonia.FuncUI.Builder
 
type TickBarBuilder<'t when 't :> TickBar>() =
    inherit ControlBuilder<'t>()
    
    [<CustomOperation("fill")>] 
    member _.fill<'t>(x: Node<_, _>, value: IBrush) =
        Types.dependencyProperty<IBrush>(TickBar.FillProperty, value, ValueNone) ]

    [<CustomOperation("isDirectionReversed")>] 
    member _.isDirectionReversed<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(TickBar.IsDirectionReversedProperty, value, ValueNone) ]

    [<CustomOperation("maximum")>] 
    member _.maximum<'t>(x: Node<_, _>, value: float) =
        Types.dependencyProperty<float>(TickBar.MaximumProperty, value, ValueNone) ]

    [<CustomOperation("minimum")>] 
    member _.minimum<'t>(x: Node<_, _>, value: float) =
        Types.dependencyProperty<float>(TickBar.MinimumProperty, value, ValueNone) ]

    [<CustomOperation("orientation")>] 
    member _.orientation<'t>(x: Node<_, _>, value: Orientation) =
        Types.dependencyProperty<Orientation>(TickBar.OrientationProperty, value, ValueNone) ]

    [<CustomOperation("placement")>] 
    member _.placement<'t>(x: Node<_, _>, value: TickBarPlacement) =
        Types.dependencyProperty<TickBarPlacement>(TickBar.PlacementProperty, value, ValueNone) ]

    [<CustomOperation("reservedSpace")>] 
    member _.reservedSpace<'t>(x: Node<_, _>, value: Rect) =
        Types.dependencyProperty<Rect>(TickBar.ReservedSpaceProperty, value, ValueNone) ]

    [<CustomOperation("tickFrequency")>] 
    member _.tickFrequency<'t>(x: Node<_, _>, value: float) =
        Types.dependencyProperty<float>(TickBar.TickFrequencyProperty, value, ValueNone) ]

    [<CustomOperation("ticks")>] 
    member _.ticks<'t>(x: Node<_, _>, value: float seq) =
        Types.dependencyProperty<float AvaloniaList>(TickBar.TicksProperty, AvaloniaList value, ValueNone) ]
