module Avalonia.FuncUI.Experiments.DSL.Thumb

open FUI.UIBuilder
open Avalonia.FuncUI.Experiments.DSL.TemplatedControl
open Avalonia.Input
open Avalonia.Controls.Primitives
open Avalonia.FuncUI.Builder

type ThumbBuilder<'t when 't :> Thumb>() =
    inherit TemplatedControlBuilder<'t>()

    [<CustomOperation("onDragStarted")>]
    member _.onDragStarted<'t>(x: Element, func: VectorEventArgs -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<VectorEventArgs>(Thumb.DragStartedEvent, func) ]
        
    [<CustomOperation("onDragDelta")>]
    member _.onDragDelta<'t>(x: Element, func: VectorEventArgs -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<VectorEventArgs>(Thumb.DragDeltaEvent, func) ]
        
    [<CustomOperation("onDragCompleted")>]
    member _.onDragCompleted<'t>(x: Element, func: VectorEventArgs -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<VectorEventArgs>(Thumb.DragCompletedEvent, func) ]