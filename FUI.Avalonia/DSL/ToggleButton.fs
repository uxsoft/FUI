module FUI.Avalonia.ToggleButton

open System
open Avalonia.Controls.Primitives
open FUI.Avalonia.Button
open Avalonia.Interactivity
 
type ToggleButtonBuilder<'t when 't :> ToggleButton and 't : equality>() =
    inherit ButtonBuilder<'t>()
    
    /// bool | ObservableValue<bool>
    [<CustomOperation("isThreeState")>] 
    member _.isThreeState<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x ToggleButton.IsThreeStateProperty value
        
    /// bool | ObservableValue<bool>
    [<CustomOperation("isChecked")>] 
    member _.isChecked<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x ToggleButton.IsCheckedProperty value
        
    [<CustomOperation("onChecked")>] 
    member _.onChecked<'t, 'v>(x: Types.AvaloniaNode<'t>, func: RoutedEventArgs -> unit) =
        Types.routedEvent x ToggleButton.CheckedEvent func
        
    [<CustomOperation("onUnchecked")>] 
    member _.onUnchecked<'t, 'v>(x: Types.AvaloniaNode<'t>, func: RoutedEventArgs -> unit) =
        Types.routedEvent x ToggleButton.UncheckedEvent func

    [<CustomOperation("onIndeterminate")>] 
    member _.onIndeterminate<'t, 'v>(x: Types.AvaloniaNode<'t>, func : RoutedEventArgs -> unit) =
        Types.routedEvent x ToggleButton.IndeterminateEvent func