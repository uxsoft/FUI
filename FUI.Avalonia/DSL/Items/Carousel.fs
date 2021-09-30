module FUI.Avalonia.Carousel

open Avalonia.Animation
open Avalonia.Controls
open FUI.Avalonia.SelectingItemsControl
 
type CarouselBuilder<'t when 't :> Carousel and 't : equality>() =
    inherit SelectingItemsControlBuilder<'t>()

    member _.isVirtualized<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x Carousel.IsVirtualizedProperty value
    
    member _.pageTransition<'t>(x: Types.AvaloniaNode<'t>, transition: IPageTransition) =
        Types.dependencyProperty x Carousel.PageTransitionProperty transition