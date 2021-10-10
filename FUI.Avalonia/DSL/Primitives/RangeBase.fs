module FUI.Avalonia.RangeBase

open Avalonia.Controls.Primitives
open FUI.Avalonia.TemplatedControl
 
type RangeBaseBuilder<'t when 't :> RangeBase and 't : equality>() =
    inherit TemplatedControlBuilder<'t>()

    /// double | ObservableValue<double>
    [<CustomOperation("minimum")>] 
    member _.minimum<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x RangeBase.MinimumProperty value
            
    /// double | ObservableValue<double>
    [<CustomOperation("maximum")>] 
    member _.maximum<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x RangeBase.MaximumProperty value
        
    /// double | ObservableValue<double>
    [<CustomOperation("value")>] 
    member _.value<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x RangeBase.ValueProperty value

    [<CustomOperation("onValueChanged")>] 
    member _.onValueChanged<'t, 'v>(x: Types.AvaloniaNode<'t>, func: double -> unit) =
        Types.dependencyPropertyEvent x RangeBase.ValueProperty func

    /// double | ObservableValue<double>
    [<CustomOperation("smallChange")>] 
    member _.smallChange<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x RangeBase.SmallChangeProperty value
        
    /// double | ObservableValue<double>
    [<CustomOperation("largeChange")>] 
    member _.largeChange<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x RangeBase.LargeChangeProperty value