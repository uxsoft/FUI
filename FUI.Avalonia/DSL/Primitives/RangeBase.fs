module FUI.Avalonia.RangeBase

open Avalonia.Controls.Primitives
open FUI.UiBuilder
open FUI.Avalonia.TemplatedControl
open Avalonia.FuncUI.Builder
 
type RangeBaseBuilder<'t when 't :> RangeBase>() =
    inherit TemplatedControlBuilder<'t>()

    [<CustomOperation("minimum")>] 
    member _.minimum<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x<double>(RangeBase.MinimumProperty, value, ValueNone) ]
            
    [<CustomOperation("maximum")>] 
    member _.maximum<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x<double>(RangeBase.MaximumProperty, value, ValueNone) ]
        
    [<CustomOperation("value")>] 
    member _.value<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x<double>(RangeBase.ValueProperty, value, ValueNone) ]

    [<CustomOperation("onValueChanged")>] 
    member _.onValueChanged<'t>(x: Types.AvaloniaNode<'t>, func: double -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<double>(RangeBase.ValueProperty, func) ]

    [<CustomOperation("smallChange")>] 
    member _.smallChange<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x<double>(RangeBase.SmallChangeProperty, value, ValueNone) ]
        
    [<CustomOperation("largeChange")>] 
    member _.largeChange<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x<double>(RangeBase.LargeChangeProperty, value, ValueNone) ]