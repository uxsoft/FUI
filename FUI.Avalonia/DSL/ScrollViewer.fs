module FUI.Avalonia.ScrollViewer

open Avalonia
open Avalonia.Controls
open FUI.Avalonia.ContentControl

type ScrollViewerBuilder<'t when 't :> ScrollViewer and 't : equality>() =
    inherit ContentControlBuilder<'t>()

    /// bool | ObservableValue<bool>
    [<CustomOperation("allowAutoHide")>]
    member _.allowAutoHide<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x ScrollViewer.AllowAutoHideProperty value
    
    /// Size | ObservableValue<Size>
    [<CustomOperation("extent")>]
    member _.extent<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x ScrollViewer.ExtentProperty value

    /// bool | ObservableValue<bool>
    [<CustomOperation("isExpanded")>]
    member _.isExpanded<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x ScrollViewer.IsExpandedProperty value

    /// Size | ObservableValue<Size>
    [<CustomOperation("largeChange")>]
    member _.largeChange<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x ScrollViewer.LargeChangeProperty value

    /// Vector | ObservableValue<Vector>
    [<CustomOperation("offset")>]
    member _.offset<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x ScrollViewer.OffsetProperty value

    [<CustomOperation("onScrollChanged")>]
    member _.onScrollChanged<'t, 'v>(x: Types.AvaloniaNode<'t>, func: ScrollChangedEventArgs -> unit) =
        Types.routedEvent x ScrollViewer.ScrollChangedEvent func

    /// Size | ObservableValue<Size>
    [<CustomOperation("smallChange")>]
    member _.smallChange<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x ScrollViewer.SmallChangeProperty value

    /// Size | ObservableValue<Size>
    [<CustomOperation("viewport")>]
    member _.viewport<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x ScrollViewer.ViewportProperty value
        
    /// double | ObservableValue<double>
    [<CustomOperation("verticalScrollBarValue")>]
    member _.verticalScrollBarValue<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x ScrollViewer.VerticalScrollBarValueProperty value
        
    /// double | ObservableValue<double>
    [<CustomOperation("horizontalScrollBarValue")>]
    member _.horizontalScrollBarValue<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x ScrollViewer.HorizontalScrollBarValueProperty value