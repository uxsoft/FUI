module FUI.Avalonia.Track

open FUI.Avalonia.Control
open Avalonia.Layout
open Avalonia.Controls.Primitives
 
type TrackBuilder<'t when 't :> Track and 't : equality>() =
    inherit ControlBuilder<'t>()
    
    [<CustomOperation("minimum")>]
    member _.minimum<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x Track.MinimumProperty value
        
    [<CustomOperation("maximum")>]
    member _.maximum<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x Track.MaximumProperty value
        
    [<CustomOperation("value")>]
    member _.value<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x Track.ValueProperty value
        
    [<CustomOperation("onValueChanged")>]
    member _.onValueChanged<'t>(x: Types.AvaloniaNode<'t>, func: double -> unit) =
        Types.dependencyPropertyEvent x Track.ValueProperty func

    [<CustomOperation("viewportSize")>]
    member _.viewportSize<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x Track.ViewportSizeProperty value
        
    [<CustomOperation("orientation")>]
    member _.orientation<'t>(x: Types.AvaloniaNode<'t>, orientation: Orientation) =
        Types.dependencyProperty x Track.OrientationProperty orientation
        
    [<CustomOperation("isDirectionReversed")>]
    member _.isDirectionReversed<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x Track.IsDirectionReversedProperty value
        
    [<CustomOperation("thumb")>] 
    member _.thumb<'t, 'c when 't :> Track and 'c :> obj>(x: Types.AvaloniaNode<'t>, value: 'c) =
        Types.dependencyProperty x Track.ThumbProperty value
    
    [<CustomOperation("ignoreThumbDragProperty")>]
    member _.ignoreThumbDragProperty<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x Track.IgnoreThumbDragProperty value
    
    [<CustomOperation("increaseButton")>] 
    member _.increaseButton<'t, 'c when 't :> Track and 'c :> obj>(x: Types.AvaloniaNode<'t>, value: 'c) =
        Types.dependencyProperty x Track.IncreaseButtonProperty value
        
    [<CustomOperation("decreaseButton")>] 
    member _.decreaseButton<'t, 'c when 't :> Track and 'c :> obj>(x: Types.AvaloniaNode<'t>, value: 'c) =
        Types.dependencyProperty x Track.DecreaseButtonProperty value