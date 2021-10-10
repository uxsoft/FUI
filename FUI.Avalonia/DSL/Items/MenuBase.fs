module FUI.Avalonia.MenuBase

open Avalonia.Controls
open FUI.Avalonia.SelectingItemsControl
open Avalonia.Interactivity
 
type MenuBaseBuilder<'t when 't :> MenuBase and 't : equality>() =
    inherit SelectingItemsControlBuilder<'t>()
        
    member _.onMenuOpened<'t, 'v>(x: Types.AvaloniaNode<'t>, func: RoutedEventArgs -> unit) =
        Types.routedEvent x MenuBase.MenuOpenedEvent func
        
    member _.onMenuClosed<'t, 'v>(x: Types.AvaloniaNode<'t>, func: RoutedEventArgs -> unit) =
        Types.routedEvent x MenuBase.MenuClosedEvent func