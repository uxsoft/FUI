module Avalonia.FuncUI.Experiments.DSL.Button

open System.Windows.Input 
open Avalonia.Controls
open FUI.UiBuilder
open Avalonia.FuncUI.Experiments.DSL.ContentControl
open Avalonia.Interactivity
open Avalonia.Input
open Avalonia.FuncUI.Builder
 
type ButtonBuilder<'t when 't :> Button>() =
    inherit ContentControlBuilder<'t>()
    
    [<CustomOperation("clickMode")>] 
    member _.clickMode<'t>(x: Node<_, _>, value: ClickMode) =
        Types.dependencyProperty<ClickMode>(Button.ClickModeProperty, value, ValueNone) ]
        
    [<CustomOperation("command")>] 
    member _.command<'t>(x: Node<_, _>, value: ICommand) =
        Types.dependencyProperty<ICommand>(Button.CommandProperty, value, ValueNone) ]
        
    [<CustomOperation("hotKey")>] 
    member _.hotKey<'t>(x: Node<_, _>, value: KeyGesture) =
        Types.dependencyProperty<KeyGesture>(Button.HotKeyProperty, value, ValueNone) ]
        
    [<CustomOperation("commandParameter")>] 
    member _.commandParameter<'t>(x: Node<_, _>, value: obj) =
        Types.dependencyProperty<obj>(Button.CommandParameterProperty, value, ValueNone) ]
        
    [<CustomOperation("isDefault")>] 
    member _.isDefault<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(Button.IsDefaultProperty, value, ValueNone) ]
        
    [<CustomOperation("isPressed")>] 
    member _.isPressed<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(Button.IsPressedProperty, value, ValueNone) ]
        
    [<CustomOperation("onIsPressedChanged")>] 
    member _.onIsPressedChanged<'t>(x: Node<_, _>, func: bool -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<bool>(Button.IsPressedProperty, func) ]
        
    [<CustomOperation("onClick")>] 
    member _.onClick<'t>(x: Node<_, _>, func: RoutedEventArgs -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<RoutedEventArgs>(Button.ClickEvent, func) ]