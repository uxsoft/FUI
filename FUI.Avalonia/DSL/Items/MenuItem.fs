module FUI.Avalonia.MenuItem

open FUI.Avalonia.HeaderedSelectingItemsControl
open Avalonia.Input
open Avalonia.Interactivity
open System.Windows.Input
open Avalonia.Controls

type MenuItemBuilder<'t when 't :> MenuItem and 't : equality>() =
    inherit HeaderedSelectingItemsControlBuilder<'t>()
    
    [<CustomOperation("command")>]
    member _.command<'t>(x: Types.AvaloniaNode<'t>, command: ICommand) =
        Types.dependencyProperty x MenuItem.CommandProperty command
        
    [<CustomOperation("commandParameter")>]
    member _.commandParameter<'t>(x: Types.AvaloniaNode<'t>, parameter: obj) =
        Types.dependencyProperty x MenuItem.CommandParameterProperty parameter
    
    [<CustomOperation("hotKey")>]
    member _.hotKey<'t>(x: Types.AvaloniaNode<'t>, value: KeyGesture) =
        Types.dependencyProperty x MenuItem.HotKeyProperty value
    
    [<CustomOperation("icon")>]
    member _.icon<'t>(x: Types.AvaloniaNode<'t>, value: obj) =
        Types.dependencyProperty x MenuItem.IconProperty value

    [<CustomOperation("inputGesture")>]
    member _.inputGesture<'t>(x: Types.AvaloniaNode<'t>, value: KeyGesture) =
        Types.dependencyProperty x MenuItem.InputGestureProperty value
    
    [<CustomOperation("isSelected")>]
    member _.isSelected<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x MenuItem.IsSelectedProperty value

    [<CustomOperation("onIsSelectedChanged")>]
    member _.onIsSelectedChanged<'t>(x: Types.AvaloniaNode<'t>, func: bool -> unit) =
        Types.dependencyPropertyEvent x MenuItem.IsSelectedProperty func
        
    [<CustomOperation("isSubMenuOpen")>]
    member _.isSubMenuOpen<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x MenuItem.IsSubMenuOpenProperty, value
        
    [<CustomOperation("onIsSubMenuOpenChanged")>]
    member _.onIsSubMenuOpenChanged<'t>(x: Types.AvaloniaNode<'t>, func: bool -> unit) =
        Types.dependencyPropertyEvent x MenuItem.IsSubMenuOpenProperty func
        
    [<CustomOperation("onClick")>]
    member _.onClick<'t>(x: Types.AvaloniaNode<'t>, func: RoutedEventArgs -> unit) =
        Types.routedEvent x MenuItem.ClickEvent func
        
    [<CustomOperation("onPointerEnterItem")>]
    member _.onPointerEnterItem<'t>(x: Types.AvaloniaNode<'t>, func: PointerEventArgs -> unit) =
        Types.routedEvent x MenuItem.PointerEnterItemEvent func
        
    [<CustomOperation("onPointerLeaveItem")>]
    member _.onPointerLeaveItem<'t>(x: Types.AvaloniaNode<'t>, func: PointerEventArgs -> unit) =
        Types.routedEvent x MenuItem.PointerLeaveItemEvent func
        
    [<CustomOperation("onSubMenuOpened")>]
    member _.onSubMenuOpened<'t>(x: Types.AvaloniaNode<'t>, func: RoutedEventArgs -> unit) =
        Types.routedEvent x MenuItem.SubmenuOpenedEvent func