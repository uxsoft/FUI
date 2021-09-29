module FUI.Avalonia.InputElement

open FUI.UiBuilder
open FUI.Avalonia.Layoutable
open Avalonia.Interactivity
open FUI.Avalonia
open Avalonia.Input

type InputElementBuilder<'t when 't :> InputElement>() =
    inherit LayoutableBuilder<'t>()
    
    [<CustomOperation("focusable")>]
    member _.focusable<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty InputElement.FocusableProperty value
        
    [<CustomOperation("isEnabled")>]
    member _.isEnabled<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty InputElement.IsEnabledProperty value

    [<CustomOperation("cursor")>]
    member _.cursor<'t>(x: Node<_, _>, cursor: Cursor) =
        Types.dependencyProperty InputElement.CursorProperty cursor
  
    [<CustomOperation("isHitTestVisible")>]
    member _.isHitTestVisible<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty InputElement.IsHitTestVisibleProperty value
        
    [<CustomOperation("onGotFocus")>]
    member _.onGotFocus<'t>(x: Node<_, _>, func: GotFocusEventArgs -> unit) =
        Types.routedEvent InputElement.GotFocusEvent func
        
    [<CustomOperation("onLostFocus")>]
    member _.onLostFocus<'t>(x: Node<_, _>, func: RoutedEventArgs -> unit) =
        Types.routedEvent InputElement.LostFocusEvent func
        
    [<CustomOperation("onKeyDown")>]
    member _.onKeyDown<'t>(x: Node<_, _>, func: KeyEventArgs -> unit) =
        Types.routedEvent InputElement.KeyDownEvent func
        
    [<CustomOperation("onKeyUp")>]
    member _.onKeyUp<'t>(x: Node<_, _>, func: KeyEventArgs -> unit) =
        Types.routedEvent InputElement.KeyUpEvent func
        
    [<CustomOperation("onTextInput")>]
    member _.onTextInput<'t>(x: Node<_, _>, func: TextInputEventArgs -> unit) =
        Types.routedEvent InputElement.TextInputEvent func
        
    [<CustomOperation("onPointerEnter")>]
    member _.onPointerEnter<'t>(x: Node<_, _>, func: PointerEventArgs -> unit) =
        Types.routedEvent InputElement.PointerEnterEvent func
        
    [<CustomOperation("onPointerLeave")>]
    member _.onPointerLeave<'t>(x: Node<_, _>, func: PointerEventArgs -> unit) =
        Types.routedEvent InputElement.PointerLeaveEvent func
        
    [<CustomOperation("onPointerMoved")>]
    member _.onPointerMoved<'t>(x: Node<_, _>, func: PointerEventArgs -> unit) =
        Types.routedEvent InputElement.PointerMovedEvent func
        
    [<CustomOperation("onPointerPressed")>]
    member _.onPointerPressed<'t>(x: Node<_, _>, func: PointerPressedEventArgs -> unit) =
        Types.routedEvent InputElement.PointerPressedEvent func
        
    [<CustomOperation("onPointerReleased")>]
    member _.onPointerReleased<'t>(x: Node<_, _>, func: PointerReleasedEventArgs -> unit) =
        Types.routedEvent InputElement.PointerReleasedEvent func
        
    [<CustomOperation("onPointerCaptureLost")>]
    member _.onPointerCaptureLost<'t>(x: Node<_, _>, func: PointerCaptureLostEventArgs -> unit) =
        Types.routedEvent InputElement.PointerCaptureLostEvent func
        
    [<CustomOperation("onPointerWheelChanged")>]
    member _.onPointerWheelChanged<'t>(x: Node<_, _>, func: PointerWheelEventArgs -> unit) =
        Types.routedEvent InputElement.PointerWheelChangedEvent func
        
    [<CustomOperation("onTapped")>]
    member _.onTapped<'t>(x: Node<_, _>, func: RoutedEventArgs -> unit) =
        Types.routedEvent InputElement.TappedEvent func
        
    [<CustomOperation("onDoubleTapped")>]
    member _.onDoubleTapped<'t>(x: Node<_, _>, func: RoutedEventArgs -> unit) =
        Types.routedEvent InputElement.DoubleTappedEvent func