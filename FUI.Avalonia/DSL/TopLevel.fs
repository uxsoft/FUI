module FUI.Avalonia.TopLevel

open Avalonia
open Avalonia.Controls
open Avalonia.Input
open Avalonia.Media
open FUI.Avalonia.Types
open FUI.UiBuilder

type TopLevelBuilder<'t when 't :> TopLevel and 't : equality>() =
    inherit ContentControl.ContentControlBuilder<'t>()

    [<CustomOperation("clientSize")>]
    member _.clientSize(x: AvaloniaNode<'t>, v: Size) =
        Types.dependencyProperty x TopLevel.ClientSizeProperty v

    [<CustomOperation("frameSize")>]
    member _.frameSize(x: AvaloniaNode<'t>, v: Size) =
        Types.dependencyProperty x TopLevel.FrameSizeProperty v
  
    [<CustomOperation("pointerOverElement")>]
    member _.pointerOverElement(x: AvaloniaNode<'t>, v: IInputElement) =
        Types.dependencyProperty x TopLevel.PointerOverElementProperty v
  
    [<CustomOperation("transparencyLevelHint")>]
    member _.transparencyLevelHint(x: AvaloniaNode<'t>, v: WindowTransparencyLevel) =
        Types.dependencyProperty x TopLevel.TransparencyLevelHintProperty v
  
    [<CustomOperation("actualTransparencyLevel")>]
    member _.actualTransparencyLevel(x: AvaloniaNode<'t>, v: WindowTransparencyLevel) =
        Types.dependencyProperty x TopLevel.ActualTransparencyLevelProperty v
  
    [<CustomOperation("transparencyBackgroundFallback")>]
    member _.transparencyBackgroundFallback(x: AvaloniaNode<'t>, v: IBrush) =
        Types.dependencyProperty x TopLevel.TransparencyBackgroundFallbackProperty v