module Avalonia.FuncUI.Experiments.DSL.Animatable

open Avalonia.Animation
open Avalonia.FuncUI.Builder
open FUI.UIBuilder

type AnimatableBuilder<'t when 't :> Animatable>() =
    inherit UIBuilder<'t>()
    
    [<CustomOperation("transitions")>]
    member _.transitions<'t>(x: Element, v: Transitions) =
        x @@ [ AttrBuilder<'t>.CreateProperty<Transitions>(Animatable.TransitionsProperty, v, ValueNone) ]
        
    [<CustomOperation("clock")>]
    member _.clock<'t>(x: Element, clock: IClock) =
        x @@ [ AttrBuilder<'t>.CreateProperty<IClock>(Animatable.ClockProperty, clock, ValueNone) ]