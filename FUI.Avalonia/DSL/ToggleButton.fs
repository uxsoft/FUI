module FUI.Avalonia.ToggleButton

open System
open Avalonia.Controls.Primitives
open FUI.Avalonia.Button
open Avalonia.Interactivity
 
type ToggleButtonBuilder<'t when 't :> ToggleButton and 't : equality>() =
    inherit ButtonBuilder<'t>()
    
    [<CustomOperation("isThreeState")>] 
    member _.isThreeState<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x ToggleButton.IsThreeStateProperty value
        
    [<CustomOperation("isChecked")>] 
    member _.isChecked<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x ToggleButton.IsCheckedProperty (Nullable value)
        
    [<CustomOperation("onChecked")>] 
    member _.onChecked<'t>(x: Types.AvaloniaNode<'t>, func: RoutedEventArgs -> unit) =
        Types.routedEvent x ToggleButton.CheckedEvent func
        
    [<CustomOperation("onUnchecked")>] 
    member _.onUnchecked<'t>(x: Types.AvaloniaNode<'t>, func: RoutedEventArgs -> unit) =
        Types.routedEvent x ToggleButton.UncheckedEvent func

    [<CustomOperation("onIndeterminate")>] 
    member _.onIndeterminate<'t>(x: Types.AvaloniaNode<'t>, func : RoutedEventArgs -> unit) =
        Types.routedEvent x ToggleButton.IndeterminateEvent func