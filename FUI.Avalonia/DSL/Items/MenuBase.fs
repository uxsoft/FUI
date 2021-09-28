module Avalonia.FuncUI.Experiments.DSL.MenuBase

open Avalonia.Controls
open FUI.UIBuilder
open Avalonia.FuncUI.Experiments.DSL.SelectingItemsControl
open Avalonia.Interactivity
open Avalonia.FuncUI.Builder
 
type MenuBaseBuilder<'t when 't :> MenuBase>() =
    inherit SelectingItemsControlBuilder<'t>()
        
    member _.onMenuOpened<'t>(x: Element, func: RoutedEventArgs -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription(MenuBase.MenuOpenedEvent, func) ]
        
    member _.onMenuClosed<'t>(x: Element, func: RoutedEventArgs -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription(MenuBase.MenuClosedEvent, func) ]