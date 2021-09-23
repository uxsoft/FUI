module Avalonia.FuncUI.Experiments.DSL.ListBoxItem

open Avalonia.Controls
open FUI.UIBuilder
open Avalonia.FuncUI.Experiments.DSL.ContentControl
open Avalonia.FuncUI.Builder
 
type ListBoxItemBuilder<'t when 't :> ListBoxItem>() =
    inherit ContentControlBuilder<'t>()

    [<CustomOperation("isSelected")>] 
    member _.isSelected<'t>(x: Element, value: bool) =
        x @@ [ AttrBuilder<'t>.CreateProperty<bool>(ListBoxItem.IsSelectedProperty, value, ValueNone) ]

    [<CustomOperation("onIsSelectedChanged")>] 
    member _.onIsSelectedChanged<'t>(x: Element, func: bool -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<bool>(ListBoxItem.IsSelectedProperty, func) ]