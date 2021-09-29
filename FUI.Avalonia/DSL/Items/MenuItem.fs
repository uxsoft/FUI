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
    member _.command<'t>(x: Node<_, _>, command: ICommand) =
        Types.dependencyProperty<ICommand>(MenuItem.CommandProperty, command, ValueNone) ]
        
    [<CustomOperation("commandParameter")>]
    member _.commandParameter<'t>(x: Node<_, _>, parameter: obj) =
        Types.dependencyProperty<obj>(MenuItem.CommandParameterProperty, parameter, ValueNone) ]
    
    [<CustomOperation("hotKey")>]
    member _.hotKey<'t>(x: Node<_, _>, value: KeyGesture) =
        Types.dependencyProperty<KeyGesture>(MenuItem.HotKeyProperty, value, ValueNone) ]
    
    [<CustomOperation("icon")>]
    member _.icon<'t>(x: Node<_, _>, value: obj) =
        Types.dependencyProperty<obj>(MenuItem.IconProperty, value, ValueNone) ]

    [<CustomOperation("inputGesture")>]
    member _.inputGesture<'t>(x: Node<_, _>, value: KeyGesture) =
        Types.dependencyProperty<KeyGesture>(MenuItem.InputGestureProperty, value, ValueNone) ]
    
    [<CustomOperation("isSelected")>]
    member _.isSelected<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(MenuItem.IsSelectedProperty, value, ValueNone) ]

    [<CustomOperation("onIsSelectedChanged")>]
    member _.onIsSelectedChanged<'t>(x: Node<_, _>, func: bool -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<bool>(MenuItem.IsSelectedProperty, func) ]
        
    [<CustomOperation("isSubMenuOpen")>]
    member _.isSubMenuOpen<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(MenuItem.IsSubMenuOpenProperty, value, ValueNone) ]
        
    [<CustomOperation("onIsSubMenuOpenChanged")>]
    member _.onIsSubMenuOpenChanged<'t>(x: Node<_, _>, func: bool -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<bool>(MenuItem.IsSubMenuOpenProperty, func) ]
        
    [<CustomOperation("onClick")>]
    member _.onClick<'t>(x: Node<_, _>, func: RoutedEventArgs -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<RoutedEventArgs>(MenuItem.ClickEvent, func) ]
        
    [<CustomOperation("onPointerEnterItem")>]
    member _.onPointerEnterItem<'t>(x: Node<_, _>, func: PointerEventArgs -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<PointerEventArgs>(MenuItem.PointerEnterItemEvent, func) ]
        
    [<CustomOperation("onPointerLeaveItem")>]
    member _.onPointerLeaveItem<'t>(x: Node<_, _>, func: PointerEventArgs -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<PointerEventArgs>(MenuItem.PointerLeaveItemEvent, func) ]
        
    [<CustomOperation("onSubMenuOpened")>]
    member _.onSubMenuOpened<'t>(x: Node<_, _>, func: RoutedEventArgs -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<RoutedEventArgs>(MenuItem.SubmenuOpenedEvent, func) ]