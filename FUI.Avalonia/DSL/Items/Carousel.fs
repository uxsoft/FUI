module FUI.Avalonia.Carousel

open Avalonia.Animation
open Avalonia.Controls
open FUI.UiBuilder
open FUI.Avalonia.SelectingItemsControl
open Avalonia.FuncUI.Builder
 
type CarouselBuilder<'t when 't :> Carousel>() =
    inherit SelectingItemsControlBuilder<'t>()

    member _.isVirtualized<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x<bool>(Carousel.IsVirtualizedProperty, value, ValueNone) ]
    
    member _.pageTransition<'t>(x: Types.AvaloniaNode<'t>, transition: IPageTransition) =
        Types.dependencyProperty x<IPageTransition>(Carousel.PageTransitionProperty, transition, ValueNone) ]