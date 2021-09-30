module FUI.Avalonia.ListBoxItem

open Avalonia.Controls
open FUI.Avalonia.ContentControl
 
type ListBoxItemBuilder<'t when 't :> ListBoxItem and 't : equality>() =
    inherit ContentControlBuilder<'t>()

    [<CustomOperation("isSelected")>] 
    member _.isSelected<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x ListBoxItem.IsSelectedProperty value

    [<CustomOperation("onIsSelectedChanged")>] 
    member _.onIsSelectedChanged<'t>(x: Types.AvaloniaNode<'t>, func: bool -> unit) =
        Types.dependencyPropertyEvent x ListBoxItem.IsSelectedProperty func