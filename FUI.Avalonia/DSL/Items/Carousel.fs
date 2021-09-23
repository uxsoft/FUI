module Avalonia.FuncUI.Experiments.DSL.Carousel

open Avalonia.Animation
open Avalonia.Controls
open FUI.UIBuilder
open Avalonia.FuncUI.Experiments.DSL.SelectingItemsControl
open Avalonia.FuncUI.Builder
 
type CarouselBuilder<'t when 't :> Carousel>() =
    inherit SelectingItemsControlBuilder<'t>()

    member _.isVirtualized<'t>(x: Element, value: bool) =
        x @@ [ AttrBuilder<'t>.CreateProperty<bool>(Carousel.IsVirtualizedProperty, value, ValueNone) ]
    
    member _.pageTransition<'t>(x: Element, transition: IPageTransition) =
        x @@ [ AttrBuilder<'t>.CreateProperty<IPageTransition>(Carousel.PageTransitionProperty, transition, ValueNone) ]