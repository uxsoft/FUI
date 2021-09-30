module FUI.Avalonia.ScrollBar

open Avalonia.Layout
open Avalonia.Controls.Primitives
open FUI.Avalonia.RangeBase

type ScrollBarBuilder<'t when 't :> ScrollBar and 't : equality>() =
    inherit RangeBaseBuilder<'t>()

    [<CustomOperation("allowAutoHide")>]
    member _.allowAutoHide<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x ScrollBar.AllowAutoHideProperty value

    [<CustomOperation("isExpanded")>]
    member _.isExpanded<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x ScrollBar.IsExpandedProperty value
    
    /// <summary>
    /// Sets the amount of the scrollable content that is currently visible.
    /// </summary>
    [<CustomOperation("viewportSize")>]
    member _.viewportSize<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x ScrollBar.ViewportSizeProperty value
        
    /// <summary>
    /// Sets a value that indicates whether the scrollbar should hide itself when it is not needed.
    /// </summary>    
    [<CustomOperation("visibility")>]
    member _.visibility<'t>(x: Types.AvaloniaNode<'t>, visibility: ScrollBarVisibility) =
        Types.dependencyProperty x ScrollBar.VisibilityProperty visibility

    /// <summary>
    /// Sets the orientation of the scrollbar.
    /// </summary>
    [<CustomOperation("orientation")>]
    member _.orientation<'t>(x: Types.AvaloniaNode<'t>, orientation: Orientation) =
        Types.dependencyProperty x ScrollBar.OrientationProperty orientation