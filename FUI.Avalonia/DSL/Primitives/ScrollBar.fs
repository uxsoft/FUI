module FUI.Avalonia.ScrollBar

open FUI.UiBuilder
open Avalonia.Layout
open Avalonia.Controls.Primitives
open Avalonia.FuncUI.Builder
open FUI.Avalonia.RangeBase

type ScrollBarBuilder<'t when 't :> ScrollBar>() =
    inherit RangeBaseBuilder<'t>()

    [<CustomOperation("allowAutoHide")>]
    member _.allowAutoHide<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x<bool>(ScrollBar.AllowAutoHideProperty, value, ValueNone) ]

    [<CustomOperation("isExpanded")>]
    member _.isExpanded<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x<bool>(ScrollBar.IsExpandedProperty, value, ValueNone) ]
    
    /// <summary>
    /// Sets the amount of the scrollable content that is currently visible.
    /// </summary>
    [<CustomOperation("viewportSize")>]
    member _.viewportSize<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x<double>(ScrollBar.ViewportSizeProperty, value, ValueNone) ]
        
    /// <summary>
    /// Sets a value that indicates whether the scrollbar should hide itself when it is not needed.
    /// </summary>    
    [<CustomOperation("visibility")>]
    member _.visibility<'t>(x: Types.AvaloniaNode<'t>, visibility: ScrollBarVisibility) =
        Types.dependencyProperty x<ScrollBarVisibility>(ScrollBar.VisibilityProperty, visibility, ValueNone) ]

    /// <summary>
    /// Sets the orientation of the scrollbar.
    /// </summary>
    [<CustomOperation("orientation")>]
    member _.orientation<'t>(x: Types.AvaloniaNode<'t>, orientation: Orientation) =
        Types.dependencyProperty x<Orientation>(ScrollBar.OrientationProperty, orientation, ValueNone) ]