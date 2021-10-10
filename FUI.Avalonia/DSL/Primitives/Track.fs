module FUI.Avalonia.Track

open FUI.Avalonia.Control
open Avalonia.Layout
open Avalonia.Controls.Primitives
 
type TrackBuilder<'t when 't :> Track and 't : equality>() =
    inherit ControlBuilder<'t>()
    
    /// double | ObservableValue<double>
    [<CustomOperation("minimum")>]
    member _.minimum<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x Track.MinimumProperty value
        
    /// double | ObservableValue<double>
    [<CustomOperation("maximum")>]
    member _.maximum<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x Track.MaximumProperty value
        
    /// double | ObservableValue<double>
    [<CustomOperation("value")>]
    member _.value<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x Track.ValueProperty value
        
    [<CustomOperation("onValueChanged")>]
    member _.onValueChanged<'t, 'v>(x: Types.AvaloniaNode<'t>, func: double -> unit) =
        Types.dependencyPropertyEvent x Track.ValueProperty func

    /// double | ObservableValue<double>
    [<CustomOperation("viewportSize")>]
    member _.viewportSize<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x Track.ViewportSizeProperty value
        
    /// Orientation | ObservableValue<Orientation>
    [<CustomOperation("orientation")>]
    member _.orientation<'t, 'v>(x: Types.AvaloniaNode<'t>, orientation: 'v) =
        Types.dependencyProperty x Track.OrientationProperty orientation
        
    /// bool | ObservableValue<bool>
    [<CustomOperation("isDirectionReversed")>]
    member _.isDirectionReversed<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x Track.IsDirectionReversedProperty value
        
    /// obj | ObservableValue<obj>
    [<CustomOperation("thumb")>] 
    member _.thumb<'t, 'c when 't :> Track and 'c :> obj>(x: Types.AvaloniaNode<'t>, value: 'c) =
        Types.dependencyProperty x Track.ThumbProperty value
    
    /// bool | ObservableValue<bool>
    [<CustomOperation("ignoreThumbDragProperty")>]
    member _.ignoreThumbDragProperty<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x Track.IgnoreThumbDragProperty value
    
    /// obj | ObservableValue<obj>
    [<CustomOperation("increaseButton")>] 
    member _.increaseButton<'t, 'c when 't :> Track and 'c :> obj>(x: Types.AvaloniaNode<'t>, value: 'c) =
        Types.dependencyProperty x Track.IncreaseButtonProperty value
        
    /// obj | ObservableValue<obj>
    [<CustomOperation("decreaseButton")>] 
    member _.decreaseButton<'t, 'c when 't :> Track and 'c :> obj>(x: Types.AvaloniaNode<'t>, value: 'c) =
        Types.dependencyProperty x Track.DecreaseButtonProperty value