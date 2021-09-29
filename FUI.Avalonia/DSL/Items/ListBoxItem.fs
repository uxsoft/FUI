module FUI.Avalonia.ListBoxItem

open Avalonia.Controls
open FUI.UiBuilder
open FUI.Avalonia.ContentControl
open Avalonia.FuncUI.Builder
 
type ListBoxItemBuilder<'t when 't :> ListBoxItem>() =
    inherit ContentControlBuilder<'t>()

    [<CustomOperation("isSelected")>] 
    member _.isSelected<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x<bool>(ListBoxItem.IsSelectedProperty, value, ValueNone) ]

    [<CustomOperation("onIsSelectedChanged")>] 
    member _.onIsSelectedChanged<'t>(x: Types.AvaloniaNode<'t>, func: bool -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<bool>(ListBoxItem.IsSelectedProperty, func) ]