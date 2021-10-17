module FUI.Avalonia.ScrollBar

open Avalonia.Layout
open Avalonia.Controls.Primitives
open FUI.Avalonia.RangeBase

type ScrollBarBuilder<'t when 't :> ScrollBar and 't : equality>() =
    inherit RangeBaseBuilder<'t>()

    /// bool | ObservableValue<bool>
    [<CustomOperation("allowAutoHide")>]
    member _.allowAutoHide<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x ScrollBar.AllowAutoHideProperty value

    /// bool | ObservableValue<bool>
    [<CustomOperation("isExpanded")>]
    member _.isExpanded<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x ScrollBar.IsExpandedProperty value
    
    /// double | ObservableValue<double>
    [<CustomOperation("viewportSize")>]
    member _.viewportSize<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x ScrollBar.ViewportSizeProperty value
        
    /// ScrollBarVisibility | ObservableValue<ScrollBarVisibility>
    [<CustomOperation("visibility")>]
    member _.visibility<'t, 'v>(x, visibility: 'v) =
        Types.dependencyProperty x ScrollBar.VisibilityProperty visibility

    /// Orientation | ObservableValue<Orientation>
    [<CustomOperation("orientation")>]
    member _.orientation<'t, 'v>(x, orientation: 'v) =
        Types.dependencyProperty x ScrollBar.OrientationProperty orientation