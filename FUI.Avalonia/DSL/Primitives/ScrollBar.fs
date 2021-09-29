module FUI.Avalonia.ScrollBar

open FUI.UiBuilder
open Avalonia.Layout
open Avalonia.Controls.Primitives
open Avalonia.FuncUI.Builder
open FUI.Avalonia.RangeBase

type ScrollBarBuilder<'t when 't :> ScrollBar>() =
    inherit RangeBaseBuilder<'t>()

    [<CustomOperation("allowAutoHide")>]
    member _.allowAutoHide<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(ScrollBar.AllowAutoHideProperty, value, ValueNone) ]

    [<CustomOperation("isExpanded")>]
    member _.isExpanded<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(ScrollBar.IsExpandedProperty, value, ValueNone) ]
    
    /// <summary>
    /// Sets the amount of the scrollable content that is currently visible.
    /// </summary>
    [<CustomOperation("viewportSize")>]
    member _.viewportSize<'t>(x: Node<_, _>, value: double) =
        Types.dependencyProperty<double>(ScrollBar.ViewportSizeProperty, value, ValueNone) ]
        
    /// <summary>
    /// Sets a value that indicates whether the scrollbar should hide itself when it is not needed.
    /// </summary>    
    [<CustomOperation("visibility")>]
    member _.visibility<'t>(x: Node<_, _>, visibility: ScrollBarVisibility) =
        Types.dependencyProperty<ScrollBarVisibility>(ScrollBar.VisibilityProperty, visibility, ValueNone) ]

    /// <summary>
    /// Sets the orientation of the scrollbar.
    /// </summary>
    [<CustomOperation("orientation")>]
    member _.orientation<'t>(x: Node<_, _>, orientation: Orientation) =
        Types.dependencyProperty<Orientation>(ScrollBar.OrientationProperty, orientation, ValueNone) ]