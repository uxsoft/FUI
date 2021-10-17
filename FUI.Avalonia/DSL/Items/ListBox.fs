module FUI.Avalonia.ListBox

open System.Collections
open Avalonia.Controls
open FUI.Avalonia.SelectingItemsControl

type ListBoxBuilder<'t when 't :> ListBox and 't : equality>() =
    inherit SelectingItemsControlBuilder<'t>()

    /// IList | ObservableValue<IList>
    member _.selectedItems<'t, 'v>(x, items: 'v) =
        Types.dependencyProperty x ListBox.SelectedItemsProperty items

    member _.onSelectedItemsChanged<'t, 'v>(x, func: IList -> unit) =
         Types.dependencyPropertyEvent x ListBox.SelectedItemsProperty func

    /// SelectionMode | ObservableValue<SelectionMode>    
    member _.selectionMode<'t, 'v>(x, mode: 'v) =
        Types.dependencyProperty x ListBox.SelectionModeProperty mode
    
    /// ItemVirtualizationMode | ObservableValue<ItemVirtualizationMode>
    member _.virtualizationMode<'t, 'v>(x, mode: 'v) =
        Types.dependencyProperty x ListBox.VirtualizationModeProperty mode