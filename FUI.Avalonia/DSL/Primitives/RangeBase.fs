module Avalonia.FuncUI.Experiments.DSL.RangeBase

open Avalonia.Controls.Primitives
open FUI.UIBuilder
open Avalonia.FuncUI.Experiments.DSL.TemplatedControl
open Avalonia.FuncUI.Builder
 
type RangeBaseBuilder<'t when 't :> RangeBase>() =
    inherit TemplatedControlBuilder<'t>()

    [<CustomOperation("minimum")>] 
    member _.minimum<'t>(x: Element, value: double) =
        x @@ [ AttrBuilder<'t>.CreateProperty<double>(RangeBase.MinimumProperty, value, ValueNone) ]
            
    [<CustomOperation("maximum")>] 
    member _.maximum<'t>(x: Element, value: double) =
        x @@ [ AttrBuilder<'t>.CreateProperty<double>(RangeBase.MaximumProperty, value, ValueNone) ]
        
    [<CustomOperation("value")>] 
    member _.value<'t>(x: Element, value: double) =
        x @@ [ AttrBuilder<'t>.CreateProperty<double>(RangeBase.ValueProperty, value, ValueNone) ]

    [<CustomOperation("onValueChanged")>] 
    member _.onValueChanged<'t>(x: Element, func: double -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<double>(RangeBase.ValueProperty, func) ]

    [<CustomOperation("smallChange")>] 
    member _.smallChange<'t>(x: Element, value: double) =
        x @@ [ AttrBuilder<'t>.CreateProperty<double>(RangeBase.SmallChangeProperty, value, ValueNone) ]
        
    [<CustomOperation("largeChange")>] 
    member _.largeChange<'t>(x: Element, value: double) =
        x @@ [ AttrBuilder<'t>.CreateProperty<double>(RangeBase.LargeChangeProperty, value, ValueNone) ]