module FUI.Avalonia.Carousel

open Avalonia.Animation
open Avalonia.Controls
open FUI.Avalonia.SelectingItemsControl
 
type CarouselBuilder<'t when 't :> Carousel and 't : equality>() =
    inherit SelectingItemsControlBuilder<'t>()

    /// bool | ObservableValue<bool>
    member _.isVirtualized<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x Carousel.IsVirtualizedProperty value
    
    /// IPageTransition | ObservableValue<IPageTransition>
    member _.pageTransition<'t, 'v>(x: Types.AvaloniaNode<'t>, transition: 'v) =
        Types.dependencyProperty x Carousel.PageTransitionProperty transition