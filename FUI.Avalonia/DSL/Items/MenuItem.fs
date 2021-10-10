module FUI.Avalonia.MenuItem

open FUI.Avalonia.HeaderedSelectingItemsControl
open Avalonia.Input
open Avalonia.Interactivity
open System.Windows.Input
open Avalonia.Controls

type MenuItemBuilder<'t when 't :> MenuItem and 't : equality>() =
    inherit HeaderedSelectingItemsControlBuilder<'t>()
    
    /// ICommand | ObservableValue<ICommand>
    [<CustomOperation("command")>]
    member _.command<'t, 'v>(x: Types.AvaloniaNode<'t>, command: 'v) =
        Types.dependencyProperty x MenuItem.CommandProperty command
        
    /// obj | ObservableValue<obj>
    [<CustomOperation("commandParameter")>]
    member _.commandParameter<'t, 'v>(x: Types.AvaloniaNode<'t>, parameter: 'v) =
        Types.dependencyProperty x MenuItem.CommandParameterProperty parameter
    
    /// KeyGesture | ObservableValue<KeyGesture>
    [<CustomOperation("hotKey")>]
    member _.hotKey<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x MenuItem.HotKeyProperty value
    
    /// obj | ObservableValue<obj>
    [<CustomOperation("icon")>]
    member _.icon<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x MenuItem.IconProperty value

    /// KeyGesture | ObservableValue<KeyGesture>
    [<CustomOperation("inputGesture")>]
    member _.inputGesture<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x MenuItem.InputGestureProperty value
    
    /// bool | ObservableValue<bool>
    [<CustomOperation("isSelected")>]
    member _.isSelected<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x MenuItem.IsSelectedProperty value

    [<CustomOperation("onIsSelectedChanged")>]
    member _.onIsSelectedChanged<'t, 'v>(x: Types.AvaloniaNode<'t>, func: bool -> unit) =
        Types.dependencyPropertyEvent x MenuItem.IsSelectedProperty func
        
    [<CustomOperation("isSubMenuOpen")>]
    member _.isSubMenuOpen<'t, 'v>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x MenuItem.IsSubMenuOpenProperty, value
        
    [<CustomOperation("onIsSubMenuOpenChanged")>]
    member _.onIsSubMenuOpenChanged<'t, 'v>(x: Types.AvaloniaNode<'t>, func: bool -> unit) =
        Types.dependencyPropertyEvent x MenuItem.IsSubMenuOpenProperty func
        
    [<CustomOperation("onClick")>]
    member _.onClick<'t, 'v>(x: Types.AvaloniaNode<'t>, func: RoutedEventArgs -> unit) =
        Types.routedEvent x MenuItem.ClickEvent func
        
    [<CustomOperation("onPointerEnterItem")>]
    member _.onPointerEnterItem<'t, 'v>(x: Types.AvaloniaNode<'t>, func: PointerEventArgs -> unit) =
        Types.routedEvent x MenuItem.PointerEnterItemEvent func
        
    [<CustomOperation("onPointerLeaveItem")>]
    member _.onPointerLeaveItem<'t, 'v>(x: Types.AvaloniaNode<'t>, func: PointerEventArgs -> unit) =
        Types.routedEvent x MenuItem.PointerLeaveItemEvent func
        
    [<CustomOperation("onSubMenuOpened")>]
    member _.onSubMenuOpened<'t, 'v>(x: Types.AvaloniaNode<'t>, func: RoutedEventArgs -> unit) =
        Types.routedEvent x MenuItem.SubmenuOpenedEvent func