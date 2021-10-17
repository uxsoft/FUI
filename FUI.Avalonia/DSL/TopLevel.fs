module FUI.Avalonia.TopLevel

open Avalonia
open Avalonia.Controls
open Avalonia.Input
open Avalonia.Media
open FUI.Avalonia.Types

type TopLevelBuilder<'t when 't :> TopLevel and 't : equality>() =
    inherit ContentControl.ContentControlBuilder<'t>()

    /// Size | ObservableValue<Size>
    [<CustomOperation("clientSize")>]
    member _.clientSize(x, v: 'v) =
        Types.dependencyProperty x TopLevel.ClientSizeProperty v

    /// Size | ObservableValue<Size>
    [<CustomOperation("frameSize")>]
    member _.frameSize(x, v: 'v) =
        Types.dependencyProperty x TopLevel.FrameSizeProperty v
  
    /// IInputElement | ObservableValue<IInputElement>
    [<CustomOperation("pointerOverElement")>]
    member _.pointerOverElement(x, v: 'v) =
        Types.dependencyProperty x TopLevel.PointerOverElementProperty v
  
    /// WindowTransparencyLevel | ObservableValue<WindowTransparencyLevel>
    [<CustomOperation("transparencyLevelHint")>]
    member _.transparencyLevelHint(x, v: 'v) =
        Types.dependencyProperty x TopLevel.TransparencyLevelHintProperty v
  
    /// WindowTransparencyLevel | ObservableValue<WindowTransparencyLevel>
    [<CustomOperation("actualTransparencyLevel")>]
    member _.actualTransparencyLevel(x, v: 'v) =
        Types.dependencyProperty x TopLevel.ActualTransparencyLevelProperty v
  
    /// IBrush | ObservableValue<IBrush>
    [<CustomOperation("transparencyBackgroundFallback")>]
    member _.transparencyBackgroundFallback(x, v: 'v) =
        Types.dependencyProperty x TopLevel.TransparencyBackgroundFallbackProperty v