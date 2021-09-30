module FUI.Avalonia.ScrollViewer

open Avalonia
open Avalonia.Controls
open FUI.Avalonia.ContentControl

type ScrollViewerBuilder<'t when 't :> ScrollViewer and 't : equality>() =
    inherit ContentControlBuilder<'t>()

    [<CustomOperation("allowAutoHide")>]
    member _.allowAutoHide<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x ScrollViewer.AllowAutoHideProperty value
    
    /// <summary>
    /// Sets the extent of the scrollable content.
    /// </summary>
    [<CustomOperation("extent")>]
    member _.extent<'t>(x: Types.AvaloniaNode<'t>, value: Size) =
        Types.dependencyProperty x ScrollViewer.ExtentProperty value

    [<CustomOperation("isExpanded")>]
    member _.isExpanded<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x ScrollViewer.IsExpandedProperty value

    [<CustomOperation("largeChange")>]
    member _.largeChange<'t>(x: Types.AvaloniaNode<'t>, value: Size) =
        Types.dependencyProperty x ScrollViewer.LargeChangeProperty value

    /// <summary>
    /// Sets the current scroll offset.
    /// </summary>
    [<CustomOperation("offset")>]
    member _.offset<'t>(x: Types.AvaloniaNode<'t>, value: Vector) =
        Types.dependencyProperty x ScrollViewer.OffsetProperty value

    [<CustomOperation("onScrollChanged")>]
    member _.onScrollChanged<'t>(x: Types.AvaloniaNode<'t>, func: ScrollChangedEventArgs -> unit) =
        Types.routedEvent x ScrollViewer.ScrollChangedEvent func

    [<CustomOperation("smallChange")>]
    member _.smallChange<'t>(x: Types.AvaloniaNode<'t>, value: Size) =
        Types.dependencyProperty x ScrollViewer.SmallChangeProperty value

    /// <summary>
    /// Sets the size of the viewport on the scrollable content.
    /// </summary>
    [<CustomOperation("viewport")>]
    member _.viewport<'t>(x: Types.AvaloniaNode<'t>, value: Size) =
        Types.dependencyProperty x ScrollViewer.ViewportProperty value
        
    /// <summary>
    /// Sets the vertical scrollbar value.
    /// </summary>
    [<CustomOperation("verticalScrollBarValue")>]
    member _.verticalScrollBarValue<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x ScrollViewer.VerticalScrollBarValueProperty value
        
     /// <summary>
    /// Sets the horizontal scrollbar value.
    /// </summary>
    [<CustomOperation("horizontalScrollBarValue")>]
    member _.horizontalScrollBarValue<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x ScrollViewer.HorizontalScrollBarValueProperty value