module FUI.Avalonia.RangeBase

open Avalonia.Controls.Primitives
open FUI.Avalonia.TemplatedControl
 
type RangeBaseBuilder<'t when 't :> RangeBase and 't : equality>() =
    inherit TemplatedControlBuilder<'t>()

    [<CustomOperation("minimum")>] 
    member _.minimum<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x RangeBase.MinimumProperty value
            
    [<CustomOperation("maximum")>] 
    member _.maximum<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x RangeBase.MaximumProperty value
        
    [<CustomOperation("value")>] 
    member _.value<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x RangeBase.ValueProperty value

    [<CustomOperation("onValueChanged")>] 
    member _.onValueChanged<'t>(x: Types.AvaloniaNode<'t>, func: double -> unit) =
        Types.dependencyPropertyEvent x RangeBase.ValueProperty func

    [<CustomOperation("smallChange")>] 
    member _.smallChange<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x RangeBase.SmallChangeProperty value
        
    [<CustomOperation("largeChange")>] 
    member _.largeChange<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x RangeBase.LargeChangeProperty value