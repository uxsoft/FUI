module FUI.Avalonia.MenuBase

open Avalonia.Controls
open FUI.UiBuilder
open FUI.Avalonia.SelectingItemsControl
open Avalonia.Interactivity
open Avalonia.FuncUI.Builder
 
type MenuBaseBuilder<'t when 't :> MenuBase>() =
    inherit SelectingItemsControlBuilder<'t>()
        
    member _.onMenuOpened<'t>(x: Types.AvaloniaNode<'t>, func: RoutedEventArgs -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription(MenuBase.MenuOpenedEvent, func) ]
        
    member _.onMenuClosed<'t>(x: Types.AvaloniaNode<'t>, func: RoutedEventArgs -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription(MenuBase.MenuClosedEvent, func) ]