module FUI.Avalonia.Button

open System.Windows.Input 
open Avalonia.Controls
open FUI.UiBuilder
open FUI.Avalonia.ContentControl
open Avalonia.Interactivity
open Avalonia.Input
 
type ButtonBuilder<'t when 't :> Button and 't : equality>() =
    inherit ContentControlBuilder<'t>()
    
    /// ClickMode | ObservableValue<ClickMode>
    [<CustomOperation("clickMode")>] 
    member _.clickMode<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x Button.ClickModeProperty value
        
    /// ICommand | ObservableValue<ICommand>
    [<CustomOperation("command")>] 
    member _.command<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x Button.CommandProperty, value
        
    /// KeyGesture | ObservableValue<KeyGesture>
    [<CustomOperation("hotKey")>] 
    member _.hotKey<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x Button.HotKeyProperty, value
        
    /// obj | ObservableValue<obj>
    [<CustomOperation("commandParameter")>] 
    member _.commandParameter<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x Button.CommandParameterProperty, value
        
    /// bool | ObservableValue<bool>
    [<CustomOperation("isDefault")>] 
    member _.isDefault<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x Button.IsDefaultProperty, value
        
    /// bool | ObservableValue<bool>
    [<CustomOperation("isPressed")>] 
    member _.isPressed<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x Button.IsPressedProperty, value
        
//    [<CustomOperation("onIsPressedChanged")>] 
//    member _.onIsPressedChanged<'t, 'v>(x: Types.AvaloniaNode<'t>, func: bool -> unit) =
//        x @@ [ AttrBuilder<'t>.CreateSubscription<bool>(Button.IsPressedProperty, func) ]
        
    [<CustomOperation("onClick")>] 
    member _.onClick<'t, 'v>(x: Types.AvaloniaNode<'t>, func: RoutedEventArgs -> unit) =
        Types.routedEvent x Button.ClickEvent func