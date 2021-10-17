module FUI.Avalonia.ListBoxItem

open Avalonia.Controls
open FUI.Avalonia.ContentControl
 
type ListBoxItemBuilder<'t when 't :> ListBoxItem and 't : equality>() =
    inherit ContentControlBuilder<'t>()

    /// bool | ObservableValue<bool>
    [<CustomOperation("isSelected")>] 
    member _.isSelected<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x ListBoxItem.IsSelectedProperty value

    [<CustomOperation("onIsSelectedChanged")>] 
    member _.onIsSelectedChanged<'t, 'v>(x, func: bool -> unit) =
        Types.dependencyPropertyEvent x ListBoxItem.IsSelectedProperty func