module Avalonia.FuncUI.Experiments.DSL.ScrollViewer

open Avalonia
open Avalonia.Controls
open FUI.UiBuilder
open Avalonia.FuncUI.Experiments.DSL.ContentControl
open Avalonia.FuncUI.Builder

type ScrollViewerBuilder<'t when 't :> ScrollViewer>() =
    inherit ContentControlBuilder<'t>()

    [<CustomOperation("allowAutoHide")>]
    member _.allowAutoHide<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(ScrollViewer.AllowAutoHideProperty, value, ValueNone) ]
    
    /// <summary>
    /// Sets the extent of the scrollable content.
    /// </summary>
    [<CustomOperation("extent")>]
    member _.extent<'t>(x: Node<_, _>, value: Size) =
        Types.dependencyProperty<Size>(ScrollViewer.ExtentProperty, value, ValueNone) ]

    [<CustomOperation("isExpanded")>]
    member _.isExpanded<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(ScrollViewer.IsExpandedProperty, value, ValueNone) ]

    [<CustomOperation("largeChange")>]
    member _.largeChange<'t>(x: Node<_, _>, value: Size) =
        Types.dependencyProperty<Size>(ScrollViewer.LargeChangeProperty, value, ValueNone) ]

    /// <summary>
    /// Sets the current scroll offset.
    /// </summary>
    [<CustomOperation("offset")>]
    member _.offset<'t>(x: Node<_, _>, value: Vector) =
        Types.dependencyProperty<Vector>(ScrollViewer.OffsetProperty, value, ValueNone) ]

    [<CustomOperation("onScrollChanged")>]
    member _.onScrollChanged<'t>(x: Node<_, _>, func: ScrollChangedEventArgs -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<ScrollChangedEventArgs>(ScrollViewer.ScrollChangedEvent, func) ]

    [<CustomOperation("smallChange")>]
    member _.smallChange<'t>(x: Node<_, _>, value: Size) =
        Types.dependencyProperty<Size>(ScrollViewer.SmallChangeProperty, value, ValueNone) ]

    /// <summary>
    /// Sets the size of the viewport on the scrollable content.
    /// </summary>
    [<CustomOperation("viewport")>]
    member _.viewport<'t>(x: Node<_, _>, value: Size) =
        Types.dependencyProperty<Size>(ScrollViewer.ViewportProperty, value, ValueNone) ]
        
    /// <summary>
    /// Sets the vertical scrollbar value.
    /// </summary>
    [<CustomOperation("verticalScrollBarValue")>]
    member _.verticalScrollBarValue<'t>(x: Node<_, _>, value: double) =
        Types.dependencyProperty<double>(ScrollViewer.VerticalScrollBarValueProperty, value, ValueNone) ]
        
     /// <summary>
    /// Sets the horizontal scrollbar value.
    /// </summary>
    [<CustomOperation("horizontalScrollBarValue")>]
    member _.horizontalScrollBarValue<'t>(x: Node<_, _>, value: double) =
        Types.dependencyProperty<double>(ScrollViewer.HorizontalScrollBarValueProperty, value, ValueNone) ]