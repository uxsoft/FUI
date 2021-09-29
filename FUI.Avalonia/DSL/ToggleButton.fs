module FUI.Avalonia.ToggleButton

open System
open Avalonia.Controls.Primitives
open FUI.Avalonia.Button
open FUI.UiBuilder
open Avalonia.Interactivity
open Avalonia.FuncUI.Builder
 
type ToggleButtonBuilder<'t when 't :> ToggleButton>() =
    inherit ButtonBuilder<'t>()
    
    [<CustomOperation("isThreeState")>] 
    member _.isThreeState<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x<bool>(ToggleButton.IsThreeStateProperty, value, ValueNone) ]
        
    [<CustomOperation("isChecked")>] 
    member _.isChecked<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x<Nullable<bool>>(ToggleButton.IsCheckedProperty, Nullable value, ValueNone) ]
        
    [<CustomOperation("onChecked")>] 
    member _.onChecked<'t>(x: Types.AvaloniaNode<'t>, func: RoutedEventArgs -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<RoutedEventArgs>(ToggleButton.CheckedEvent, func) ]
        
    [<CustomOperation("onUnchecked")>] 
    member _.onUnchecked<'t>(x: Types.AvaloniaNode<'t>, func: RoutedEventArgs -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<RoutedEventArgs>(ToggleButton.UncheckedEvent, func) ]

    [<CustomOperation("onIndeterminate")>] 
    member _.onIndeterminate<'t>(x: Types.AvaloniaNode<'t>, func : RoutedEventArgs -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<RoutedEventArgs>(ToggleButton.IndeterminateEvent, func) ]