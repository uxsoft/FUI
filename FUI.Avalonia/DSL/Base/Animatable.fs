module FUI.Avalonia.Animatable

open Avalonia.Animation
open FUI.Avalonia.Types
open FUI.UiBuilder
open FUI.Avalonia

type AnimatableBuilder<'t when  't :> Animatable and 't : equality>() =
    inherit UiBuilder()
    
    [<CustomOperation("transitions")>]
    member _.transitions<'t, 'v>(x, v: Transitions) =
        Types.dependencyProperty x Animatable.TransitionsProperty v
        
    [<CustomOperation("clock")>]
    member _.clock<'t, 'v>(x, clock: IClock) =
        Types.dependencyProperty x Animatable.ClockProperty clock