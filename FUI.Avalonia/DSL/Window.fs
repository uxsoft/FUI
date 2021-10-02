module FUI.Avalonia.Window

open Avalonia
open Avalonia.Controls
open Avalonia.Platform
open FUI.Avalonia.Patcher

type WindowBuilder<'t when 't :> Window and 't : equality>() =
    inherit TopLevel.TopLevelBuilder<'t>()
    member inline this.Run x =            
        this.RunWithChild x (fun window child -> window.Content <- child)
        
    [<CustomOperation("SizeToContent")>]
    member inline _.sizeToContent(x: Types.AvaloniaNode<'t>, v: SizeToContent) =
        Types.dependencyProperty x Window.SizeToContentProperty v
    
    [<CustomOperation("extendClientAreaToDecorationsHint")>]
    member inline _.extendClientAreaToDecorationsHint(x: Types.AvaloniaNode<'t>, v: bool) =
        Types.dependencyProperty x Window.ExtendClientAreaToDecorationsHintProperty v

    [<CustomOperation("ExtendClientAreaChromeHintsProperty")>]
    member inline _.ExtendClientAreaChromeHintsProperty(x: Types.AvaloniaNode<'t>, v: ExtendClientAreaChromeHints) =
        Types.dependencyProperty x Window.ExtendClientAreaChromeHintsProperty v
    
    [<CustomOperation("extendClientAreaTitleBarHeightHint")>]
    member inline _.extendClientAreaTitleBarHeightHint(x: Types.AvaloniaNode<'t>, v: double) =
        Types.dependencyProperty x Window.ExtendClientAreaTitleBarHeightHintProperty v

    [<CustomOperation("isExtendedIntoWindowDecorations")>]
    member inline _.isExtendedIntoWindowDecorations(x: Types.AvaloniaNode<'t>, v: bool) =
        Types.dependencyProperty x Window.IsExtendedIntoWindowDecorationsProperty v

    [<CustomOperation("windowDecorationMargin")>]
    member inline _.windowDecorationMargin(x: Types.AvaloniaNode<'t>, v: Thickness) =
        Types.dependencyProperty x Window.WindowDecorationMarginProperty v

    [<CustomOperation("offScreenMargin")>]
    member inline _.offScreenMargin(x: Types.AvaloniaNode<'t>, v: Thickness) =
        Types.dependencyProperty x Window.OffScreenMarginProperty v

    [<CustomOperation("systemDecorations")>]
    member inline _.systemDecorations(x: Types.AvaloniaNode<'t>, v: SystemDecorations) =
        Types.dependencyProperty x Window.SystemDecorationsProperty v

    [<CustomOperation("showActivated")>]
    member inline _.showActivated(x: Types.AvaloniaNode<'t>, v: bool) =
        Types.dependencyProperty x Window.ShowActivatedProperty v

    [<CustomOperation("showInTaskbar")>]
    member inline _.showInTaskbar(x: Types.AvaloniaNode<'t>, v: bool) =
        Types.dependencyProperty x Window.ShowInTaskbarProperty v

    [<CustomOperation("windowState")>]
    member inline _.windowState(x: Types.AvaloniaNode<'t>, v: WindowState) =
        Types.dependencyProperty x Window.WindowStateProperty v

    [<CustomOperation("title")>]
    member inline _.title(x: Types.AvaloniaNode<'t>, v: string) =
        Types.dependencyProperty x Window.TitleProperty v

    [<CustomOperation("icon")>]
    member inline _.icon(x: Types.AvaloniaNode<'t>, v: WindowIcon) =
        Types.dependencyProperty x Window.IconProperty v

    [<CustomOperation("windowStartupLocation")>]
    member inline _.windowStartupLocation(x: Types.AvaloniaNode<'t>, v: WindowStartupLocation) =
        Types.dependencyProperty x Window.WindowStartupLocationProperty v

    [<CustomOperation("canResize")>]
    member inline _.canResize(x: Types.AvaloniaNode<'t>, v: bool) =
        Types.dependencyProperty x Window.CanResizeProperty v

//    [<CustomOperation("WindowClosedEvent")>]
//    member inline _.WindowClosedEvent(x: Types.AvaloniaNode<'t>, v: string) =
//        Types.routedEvent x Window.WindowClosedEvent v
//        
//    [<CustomOperation("onWindowOpened")>]
//    member inline _.onWindowOpened(x: Types.AvaloniaNode<'t>, v: string) =
//        Types.routedEvent x Window.WindowOpenedEvent v
