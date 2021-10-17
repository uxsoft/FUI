module FUI.Avalonia.Thumb

open FUI.UiBuilder
open FUI.Avalonia.TemplatedControl
open Avalonia.Input
open Avalonia.Controls.Primitives

type ThumbBuilder<'t when 't :> Thumb and 't : equality>() =
    inherit TemplatedControlBuilder<'t>()

    [<CustomOperation("onDragStarted")>]
    member _.onDragStarted<'t, 'v>(x, func: VectorEventArgs -> unit) =
        Types.routedEvent x Thumb.DragStartedEvent func
        
    [<CustomOperation("onDragDelta")>]
    member _.onDragDelta<'t, 'v>(x, func: VectorEventArgs -> unit) =
        Types.routedEvent x Thumb.DragDeltaEvent func
        
    [<CustomOperation("onDragCompleted")>]
    member _.onDragCompleted<'t, 'v>(x, func: VectorEventArgs -> unit) =
        Types.routedEvent x Thumb.DragCompletedEvent func