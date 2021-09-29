module FUI.Avalonia.Animatable

open Avalonia.Animation
open FUI.UiBuilder
open FUI.Avalonia

type AnimatableBuilder<'t when 't :> Animatable>() =
    inherit UiBuilder<'t>()
    
    [<CustomOperation("transitions")>]
    member _.transitions<'t>(x: Node<_, _>, v: Transitions) =
        Types.dependencyProperty Animatable.TransitionsProperty v
        
    [<CustomOperation("clock")>]
    member _.clock<'t>(x: Node<_, _>, clock: IClock) =
        Types.dependencyProperty Animatable.ClockProperty clock