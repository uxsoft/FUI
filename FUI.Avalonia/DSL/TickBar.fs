﻿namespace Avalonia.FuncUI.Experiments.DSL.TickBar

open Avalonia
open Avalonia.Collections
open Avalonia.Controls
open FUI.UIBuilder
open Avalonia.FuncUI.Experiments.DSL.Control
open Avalonia.Media
open Avalonia.Layout
open Avalonia.FuncUI.Builder
 
type TickBarBuilder<'t when 't :> TickBar>() =
    inherit ControlBuilder<'t>()
    
    [<CustomOperation("fill")>] 
    member _.fill<'t>(x: Element, value: IBrush) =
        x @@ [ AttrBuilder<'t>.CreateProperty<IBrush>(TickBar.FillProperty, value, ValueNone) ]

    [<CustomOperation("isDirectionReversed")>] 
    member _.isDirectionReversed<'t>(x: Element, value: bool) =
        x @@ [ AttrBuilder<'t>.CreateProperty<bool>(TickBar.IsDirectionReversedProperty, value, ValueNone) ]

    [<CustomOperation("maximum")>] 
    member _.maximum<'t>(x: Element, value: float) =
        x @@ [ AttrBuilder<'t>.CreateProperty<float>(TickBar.MaximumProperty, value, ValueNone) ]

    [<CustomOperation("minimum")>] 
    member _.minimum<'t>(x: Element, value: float) =
        x @@ [ AttrBuilder<'t>.CreateProperty<float>(TickBar.MinimumProperty, value, ValueNone) ]

    [<CustomOperation("orientation")>] 
    member _.orientation<'t>(x: Element, value: Orientation) =
        x @@ [ AttrBuilder<'t>.CreateProperty<Orientation>(TickBar.OrientationProperty, value, ValueNone) ]

    [<CustomOperation("placement")>] 
    member _.placement<'t>(x: Element, value: TickBarPlacement) =
        x @@ [ AttrBuilder<'t>.CreateProperty<TickBarPlacement>(TickBar.PlacementProperty, value, ValueNone) ]

    [<CustomOperation("reservedSpace")>] 
    member _.reservedSpace<'t>(x: Element, value: Rect) =
        x @@ [ AttrBuilder<'t>.CreateProperty<Rect>(TickBar.ReservedSpaceProperty, value, ValueNone) ]

    [<CustomOperation("tickFrequency")>] 
    member _.tickFrequency<'t>(x: Element, value: float) =
        x @@ [ AttrBuilder<'t>.CreateProperty<float>(TickBar.TickFrequencyProperty, value, ValueNone) ]

    [<CustomOperation("ticks")>] 
    member _.ticks<'t>(x: Element, value: float seq) =
        x @@ [ AttrBuilder<'t>.CreateProperty<float AvaloniaList>(TickBar.TicksProperty, AvaloniaList value, ValueNone) ]
