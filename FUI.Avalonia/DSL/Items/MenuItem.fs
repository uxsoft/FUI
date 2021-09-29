module FUI.Avalonia.MenuItem

open FUI.UiBuilder
open FUI.Avalonia.HeaderedSelectingItemsControl
open Avalonia.Input
open Avalonia.Interactivity
open System.Windows.Input
open Avalonia.Controls
open Avalonia.FuncUI.Builder

type MenuItemBuilder<'t when 't :> MenuItem>() =
    inherit HeaderedSelectingItemsControlBuilder<'t>()
    
    [<CustomOperation("command")>]
    member _.command<'t>(x: Types.AvaloniaNode<'t>, command: ICommand) =
        Types.dependencyProperty x<ICommand>(MenuItem.CommandProperty, command, ValueNone) ]
        
    [<CustomOperation("commandParameter")>]
    member _.commandParameter<'t>(x: Types.AvaloniaNode<'t>, parameter: obj) =
        Types.dependencyProperty x<obj>(MenuItem.CommandParameterProperty, parameter, ValueNone) ]
    
    [<CustomOperation("hotKey")>]
    member _.hotKey<'t>(x: Types.AvaloniaNode<'t>, value: KeyGesture) =
        Types.dependencyProperty x<KeyGesture>(MenuItem.HotKeyProperty, value, ValueNone) ]
    
    [<CustomOperation("icon")>]
    member _.icon<'t>(x: Types.AvaloniaNode<'t>, value: obj) =
        Types.dependencyProperty x<obj>(MenuItem.IconProperty, value, ValueNone) ]

    [<CustomOperation("inputGesture")>]
    member _.inputGesture<'t>(x: Types.AvaloniaNode<'t>, value: KeyGesture) =
        Types.dependencyProperty x<KeyGesture>(MenuItem.InputGestureProperty, value, ValueNone) ]
    
    [<CustomOperation("isSelected")>]
    member _.isSelected<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x<bool>(MenuItem.IsSelectedProperty, value, ValueNone) ]

    [<CustomOperation("onIsSelectedChanged")>]
    member _.onIsSelectedChanged<'t>(x: Types.AvaloniaNode<'t>, func: bool -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<bool>(MenuItem.IsSelectedProperty, func) ]
        
    [<CustomOperation("isSubMenuOpen")>]
    member _.isSubMenuOpen<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x<bool>(MenuItem.IsSubMenuOpenProperty, value, ValueNone) ]
        
    [<CustomOperation("onIsSubMenuOpenChanged")>]
    member _.onIsSubMenuOpenChanged<'t>(x: Types.AvaloniaNode<'t>, func: bool -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<bool>(MenuItem.IsSubMenuOpenProperty, func) ]
        
    [<CustomOperation("onClick")>]
    member _.onClick<'t>(x: Types.AvaloniaNode<'t>, func: RoutedEventArgs -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<RoutedEventArgs>(MenuItem.ClickEvent, func) ]
        
    [<CustomOperation("onPointerEnterItem")>]
    member _.onPointerEnterItem<'t>(x: Types.AvaloniaNode<'t>, func: PointerEventArgs -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<PointerEventArgs>(MenuItem.PointerEnterItemEvent, func) ]
        
    [<CustomOperation("onPointerLeaveItem")>]
    member _.onPointerLeaveItem<'t>(x: Types.AvaloniaNode<'t>, func: PointerEventArgs -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<PointerEventArgs>(MenuItem.PointerLeaveItemEvent, func) ]
        
    [<CustomOperation("onSubMenuOpened")>]
    member _.onSubMenuOpened<'t>(x: Types.AvaloniaNode<'t>, func: RoutedEventArgs -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<RoutedEventArgs>(MenuItem.SubmenuOpenedEvent, func) ]