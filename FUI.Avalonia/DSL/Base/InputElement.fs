module FUI.Avalonia.InputElement

open FUI.UiBuilder
open FUI.Avalonia.Layoutable
open Avalonia.Interactivity
open FUI.Avalonia
open Avalonia.Input

type InputElementBuilder<'t when 't :> InputElement and 't : equality>() =
    inherit LayoutableBuilder<'t>()
    
    [<CustomOperation("focusable")>]
    member _.focusable<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x InputElement.FocusableProperty value
        
    [<CustomOperation("isEnabled")>]
    member _.isEnabled<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x InputElement.IsEnabledProperty value

    [<CustomOperation("cursor")>]
    member _.cursor<'t>(x: Types.AvaloniaNode<'t>, cursor: Cursor) =
        Types.dependencyProperty x InputElement.CursorProperty cursor
  
    [<CustomOperation("isHitTestVisible")>]
    member _.isHitTestVisible<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x InputElement.IsHitTestVisibleProperty value
        
    [<CustomOperation("onGotFocus")>]
    member _.onGotFocus<'t>(x: Types.AvaloniaNode<'t>, func: GotFocusEventArgs -> unit) =
        Types.routedEvent x InputElement.GotFocusEvent func
        
    [<CustomOperation("onLostFocus")>]
    member _.onLostFocus<'t>(x: Types.AvaloniaNode<'t>, func: RoutedEventArgs -> unit) =
        Types.routedEvent x InputElement.LostFocusEvent func
        
    [<CustomOperation("onKeyDown")>]
    member _.onKeyDown<'t>(x: Types.AvaloniaNode<'t>, func: KeyEventArgs -> unit) =
        Types.routedEvent x InputElement.KeyDownEvent func
        
    [<CustomOperation("onKeyUp")>]
    member _.onKeyUp<'t>(x: Types.AvaloniaNode<'t>, func: KeyEventArgs -> unit) =
        Types.routedEvent x InputElement.KeyUpEvent func
        
    [<CustomOperation("onTextInput")>]
    member _.onTextInput<'t>(x: Types.AvaloniaNode<'t>, func: TextInputEventArgs -> unit) =
        Types.routedEvent x InputElement.TextInputEvent func
        
    [<CustomOperation("onPointerEnter")>]
    member _.onPointerEnter<'t>(x: Types.AvaloniaNode<'t>, func: PointerEventArgs -> unit) =
        Types.routedEvent x InputElement.PointerEnterEvent func
        
    [<CustomOperation("onPointerLeave")>]
    member _.onPointerLeave<'t>(x: Types.AvaloniaNode<'t>, func: PointerEventArgs -> unit) =
        Types.routedEvent x InputElement.PointerLeaveEvent func
        
    [<CustomOperation("onPointerMoved")>]
    member _.onPointerMoved<'t>(x: Types.AvaloniaNode<'t>, func: PointerEventArgs -> unit) =
        Types.routedEvent x InputElement.PointerMovedEvent func
        
    [<CustomOperation("onPointerPressed")>]
    member _.onPointerPressed<'t>(x: Types.AvaloniaNode<'t>, func: PointerPressedEventArgs -> unit) =
        Types.routedEvent x InputElement.PointerPressedEvent func
        
    [<CustomOperation("onPointerReleased")>]
    member _.onPointerReleased<'t>(x: Types.AvaloniaNode<'t>, func: PointerReleasedEventArgs -> unit) =
        Types.routedEvent x InputElement.PointerReleasedEvent func
        
    [<CustomOperation("onPointerCaptureLost")>]
    member _.onPointerCaptureLost<'t>(x: Types.AvaloniaNode<'t>, func: PointerCaptureLostEventArgs -> unit) =
        Types.routedEvent x InputElement.PointerCaptureLostEvent func
        
    [<CustomOperation("onPointerWheelChanged")>]
    member _.onPointerWheelChanged<'t>(x: Types.AvaloniaNode<'t>, func: PointerWheelEventArgs -> unit) =
        Types.routedEvent x InputElement.PointerWheelChangedEvent func
        
    [<CustomOperation("onTapped")>]
    member _.onTapped<'t>(x: Types.AvaloniaNode<'t>, func: RoutedEventArgs -> unit) =
        Types.routedEvent x InputElement.TappedEvent func
        
    [<CustomOperation("onDoubleTapped")>]
    member _.onDoubleTapped<'t>(x: Types.AvaloniaNode<'t>, func: RoutedEventArgs -> unit) =
        Types.routedEvent x InputElement.DoubleTappedEvent func