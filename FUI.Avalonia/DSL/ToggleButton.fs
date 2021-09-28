module Avalonia.FuncUI.Experiments.DSL.ToggleButton

open System
open Avalonia.Controls.Primitives
open Avalonia.FuncUI.Experiments.DSL.Button
open FUI.UiBuilder
open Avalonia.Interactivity
open Avalonia.FuncUI.Builder
 
type ToggleButtonBuilder<'t when 't :> ToggleButton>() =
    inherit ButtonBuilder<'t>()
    
    [<CustomOperation("isThreeState")>] 
    member _.isThreeState<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(ToggleButton.IsThreeStateProperty, value, ValueNone) ]
        
    [<CustomOperation("isChecked")>] 
    member _.isChecked<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<Nullable<bool>>(ToggleButton.IsCheckedProperty, Nullable value, ValueNone) ]
        
    [<CustomOperation("onChecked")>] 
    member _.onChecked<'t>(x: Node<_, _>, func: RoutedEventArgs -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<RoutedEventArgs>(ToggleButton.CheckedEvent, func) ]
        
    [<CustomOperation("onUnchecked")>] 
    member _.onUnchecked<'t>(x: Node<_, _>, func: RoutedEventArgs -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<RoutedEventArgs>(ToggleButton.UncheckedEvent, func) ]

    [<CustomOperation("onIndeterminate")>] 
    member _.onIndeterminate<'t>(x: Node<_, _>, func : RoutedEventArgs -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<RoutedEventArgs>(ToggleButton.IndeterminateEvent, func) ]