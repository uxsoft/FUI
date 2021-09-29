module FUI.Avalonia.Button

open System.Windows.Input 
open Avalonia.Controls
open FUI.UiBuilder
open FUI.Avalonia.ContentControl
open Avalonia.Interactivity
open Avalonia.Input
 
type ButtonBuilder<'t when 't :> Button and 't : equality>() =
    inherit ContentControlBuilder<'t>()
    
    [<CustomOperation("clickMode")>] 
    member _.clickMode<'t>(x: Types.AvaloniaNode<'t>, value: ClickMode) =
        Types.dependencyProperty x Button.ClickModeProperty value
        
    [<CustomOperation("command")>] 
    member _.command<'t>(x: Types.AvaloniaNode<'t>, value: ICommand) =
        Types.dependencyProperty x Button.CommandProperty, value
        
    [<CustomOperation("hotKey")>] 
    member _.hotKey<'t>(x: Types.AvaloniaNode<'t>, value: KeyGesture) =
        Types.dependencyProperty x Button.HotKeyProperty, value
        
    [<CustomOperation("commandParameter")>] 
    member _.commandParameter<'t>(x: Types.AvaloniaNode<'t>, value: obj) =
        Types.dependencyProperty x Button.CommandParameterProperty, value
        
    [<CustomOperation("isDefault")>] 
    member _.isDefault<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x Button.IsDefaultProperty, value
        
    [<CustomOperation("isPressed")>] 
    member _.isPressed<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x Button.IsPressedProperty, value
        
//    [<CustomOperation("onIsPressedChanged")>] 
//    member _.onIsPressedChanged<'t>(x: Types.AvaloniaNode<'t>, func: bool -> unit) =
//        x @@ [ AttrBuilder<'t>.CreateSubscription<bool>(Button.IsPressedProperty, func) ]
        
    [<CustomOperation("onClick")>] 
    member _.onClick<'t>(x: Types.AvaloniaNode<'t>, func: RoutedEventArgs -> unit) =
        Types.routedEvent x Button.ClickEvent func