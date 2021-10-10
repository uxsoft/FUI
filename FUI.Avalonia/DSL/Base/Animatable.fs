module FUI.Avalonia.Animatable

open Avalonia.Animation
open FUI.UiBuilder
open FUI.Avalonia

type AnimatableBuilder<'t when 't :> Animatable and 't : equality>() =
    inherit UiBuilder<'t>()
    
    [<CustomOperation("transitions")>]
    member _.transitions<'t, 'v>(x: Types.AvaloniaNode<'t>, v: Transitions) =
        Types.dependencyProperty x Animatable.TransitionsProperty v
        
    [<CustomOperation("clock")>]
    member _.clock<'t, 'v>(x: Types.AvaloniaNode<'t>, clock: IClock) =
        Types.dependencyProperty x Animatable.ClockProperty clock