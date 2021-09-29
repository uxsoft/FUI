module FUI.Avalonia.Carousel

open Avalonia.Animation
open Avalonia.Controls
open FUI.UiBuilder
open FUI.Avalonia.SelectingItemsControl
open Avalonia.FuncUI.Builder
 
type CarouselBuilder<'t when 't :> Carousel>() =
    inherit SelectingItemsControlBuilder<'t>()

    member _.isVirtualized<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(Carousel.IsVirtualizedProperty, value, ValueNone) ]
    
    member _.pageTransition<'t>(x: Node<_, _>, transition: IPageTransition) =
        Types.dependencyProperty<IPageTransition>(Carousel.PageTransitionProperty, transition, ValueNone) ]