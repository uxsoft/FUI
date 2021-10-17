module FUI.Avalonia.Window

open Avalonia.Controls
open FUI.Avalonia.Patcher

type WindowBuilder<'t when 't :> Window and 't : equality>() =
    inherit TopLevel.TopLevelBuilder<'t>()
    member inline this.Run x =            
        this.RunWithChild<'t> x (fun window child -> window.Content <- child)
        
    /// SizeToContent | ObservableValue<SizeToContent>
    [<CustomOperation("sizeToContent")>]
    member inline _.sizeToContent(x, v: 'v) =
        Types.dependencyProperty x Window.SizeToContentProperty v
    
    /// bool | ObservableValue<bool>
    [<CustomOperation("extendClientAreaToDecorationsHint")>]
    member inline _.extendClientAreaToDecorationsHint(x, v: 'v) =
        Types.dependencyProperty x Window.ExtendClientAreaToDecorationsHintProperty v

    /// ExtendClientAreaChromeHints | ObservableValue<ExtendClientAreaChromeHints>
    [<CustomOperation("extendClientAreaChromeHints")>]
    member inline _.extendClientAreaChromeHints(x, v: 'v) =
        Types.dependencyProperty x Window.ExtendClientAreaChromeHintsProperty v
    
    /// double | ObservableValue<double>
    [<CustomOperation("extendClientAreaTitleBarHeightHint")>]
    member inline _.extendClientAreaTitleBarHeightHint(x, v: 'v) =
        Types.dependencyProperty x Window.ExtendClientAreaTitleBarHeightHintProperty v

    /// bool | ObservableValue<bool>
    [<CustomOperation("isExtendedIntoWindowDecorations")>]
    member inline _.isExtendedIntoWindowDecorations(x, v: 'v) =
        Types.dependencyProperty x Window.IsExtendedIntoWindowDecorationsProperty v

    /// Thickness | ObservableValue<Thickness>
    [<CustomOperation("windowDecorationMargin")>]
    member inline _.windowDecorationMargin(x, v: 'v) =
        Types.dependencyProperty x Window.WindowDecorationMarginProperty v

    /// Thickness | ObservableValue<Thickness>
    [<CustomOperation("offScreenMargin")>]
    member inline _.offScreenMargin(x, v: 'v) =
        Types.dependencyProperty x Window.OffScreenMarginProperty v

    /// SystemDecorations | ObservableValue<SystemDecorations>
    [<CustomOperation("systemDecorations")>]
    member inline _.systemDecorations(x, v: 'v) =
        Types.dependencyProperty x Window.SystemDecorationsProperty v

    /// bool | ObservableValue<bool>
    [<CustomOperation("showActivated")>]
    member inline _.showActivated(x, v: 'v) =
        Types.dependencyProperty x Window.ShowActivatedProperty v

    /// bool | ObservableValue<bool>
    [<CustomOperation("showInTaskbar")>]
    member inline _.showInTaskbar(x, v: 'v) =
        Types.dependencyProperty x Window.ShowInTaskbarProperty v

    /// WindowState | ObservableValue<WindowState>
    [<CustomOperation("windowState")>]
    member inline _.windowState(x, v: 'v) =
        Types.dependencyProperty x Window.WindowStateProperty v

    /// string | ObservableValue<string>
    [<CustomOperation("title")>]
    member inline _.title(x, v: 'v) =
        Types.dependencyProperty x Window.TitleProperty v

    /// WindowIcon | ObservableValue<WindowIcon>
    [<CustomOperation("icon")>]
    member inline _.icon(x, v: 'v) =
        Types.dependencyProperty x Window.IconProperty v

    /// WindowStartupLocation | ObservableValue<WindowStartupLocation>
    [<CustomOperation("windowStartupLocation")>]
    member inline _.windowStartupLocation(x, v: 'v) =
        Types.dependencyProperty x Window.WindowStartupLocationProperty v

    /// bool | ObservableValue<bool>
    [<CustomOperation("canResize")>]
    member inline _.canResize(x, v: 'v) =
        Types.dependencyProperty x Window.CanResizeProperty v

    [<CustomOperation("onWindowClosed")>]
    member inline _.onWindowClosed(x, handler) =
        Types.observableEvent x Window.WindowClosedEvent.Raised (nameof Window.WindowClosedEvent) handler
        
    [<CustomOperation("onWindowOpened")>]
    member inline _.onWindowOpened(x, handler) =
        Types.observableEvent x Window.WindowOpenedEvent.Raised (nameof Window.WindowOpenedEvent) handler
