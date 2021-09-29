module FUI.Avalonia.Thumb

open FUI.UiBuilder
open FUI.Avalonia.TemplatedControl
open Avalonia.Input
open Avalonia.Controls.Primitives
open Avalonia.FuncUI.Builder

type ThumbBuilder<'t when 't :> Thumb>() =
    inherit TemplatedControlBuilder<'t>()

    [<CustomOperation("onDragStarted")>]
    member _.onDragStarted<'t>(x: Node<_, _>, func: VectorEventArgs -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<VectorEventArgs>(Thumb.DragStartedEvent, func) ]
        
    [<CustomOperation("onDragDelta")>]
    member _.onDragDelta<'t>(x: Node<_, _>, func: VectorEventArgs -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<VectorEventArgs>(Thumb.DragDeltaEvent, func) ]
        
    [<CustomOperation("onDragCompleted")>]
    member _.onDragCompleted<'t>(x: Node<_, _>, func: VectorEventArgs -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<VectorEventArgs>(Thumb.DragCompletedEvent, func) ]