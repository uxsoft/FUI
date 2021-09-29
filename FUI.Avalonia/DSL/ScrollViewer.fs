module FUI.Avalonia.ScrollViewer

open Avalonia
open Avalonia.Controls
open FUI.UiBuilder
open FUI.Avalonia.ContentControl
open Avalonia.FuncUI.Builder

type ScrollViewerBuilder<'t when 't :> ScrollViewer>() =
    inherit ContentControlBuilder<'t>()

    [<CustomOperation("allowAutoHide")>]
    member _.allowAutoHide<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x<bool>(ScrollViewer.AllowAutoHideProperty, value, ValueNone) ]
    
    /// <summary>
    /// Sets the extent of the scrollable content.
    /// </summary>
    [<CustomOperation("extent")>]
    member _.extent<'t>(x: Types.AvaloniaNode<'t>, value: Size) =
        Types.dependencyProperty x<Size>(ScrollViewer.ExtentProperty, value, ValueNone) ]

    [<CustomOperation("isExpanded")>]
    member _.isExpanded<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x<bool>(ScrollViewer.IsExpandedProperty, value, ValueNone) ]

    [<CustomOperation("largeChange")>]
    member _.largeChange<'t>(x: Types.AvaloniaNode<'t>, value: Size) =
        Types.dependencyProperty x<Size>(ScrollViewer.LargeChangeProperty, value, ValueNone) ]

    /// <summary>
    /// Sets the current scroll offset.
    /// </summary>
    [<CustomOperation("offset")>]
    member _.offset<'t>(x: Types.AvaloniaNode<'t>, value: Vector) =
        Types.dependencyProperty x<Vector>(ScrollViewer.OffsetProperty, value, ValueNone) ]

    [<CustomOperation("onScrollChanged")>]
    member _.onScrollChanged<'t>(x: Types.AvaloniaNode<'t>, func: ScrollChangedEventArgs -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<ScrollChangedEventArgs>(ScrollViewer.ScrollChangedEvent, func) ]

    [<CustomOperation("smallChange")>]
    member _.smallChange<'t>(x: Types.AvaloniaNode<'t>, value: Size) =
        Types.dependencyProperty x<Size>(ScrollViewer.SmallChangeProperty, value, ValueNone) ]

    /// <summary>
    /// Sets the size of the viewport on the scrollable content.
    /// </summary>
    [<CustomOperation("viewport")>]
    member _.viewport<'t>(x: Types.AvaloniaNode<'t>, value: Size) =
        Types.dependencyProperty x<Size>(ScrollViewer.ViewportProperty, value, ValueNone) ]
        
    /// <summary>
    /// Sets the vertical scrollbar value.
    /// </summary>
    [<CustomOperation("verticalScrollBarValue")>]
    member _.verticalScrollBarValue<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x<double>(ScrollViewer.VerticalScrollBarValueProperty, value, ValueNone) ]
        
     /// <summary>
    /// Sets the horizontal scrollbar value.
    /// </summary>
    [<CustomOperation("horizontalScrollBarValue")>]
    member _.horizontalScrollBarValue<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x<double>(ScrollViewer.HorizontalScrollBarValueProperty, value, ValueNone) ]