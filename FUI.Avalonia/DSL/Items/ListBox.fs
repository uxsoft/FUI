module FUI.Avalonia.ListBox

open System.Collections
open Avalonia.Controls
open FUI.Avalonia.SelectingItemsControl

type ListBoxBuilder<'t when 't :> ListBox and 't : equality>() =
    inherit SelectingItemsControlBuilder<'t>()

    member _.selectedItems<'t>(x: Types.AvaloniaNode<'t>, items: IList) =
        Types.dependencyProperty x ListBox.SelectedItemsProperty items

    member _.onSelectedItemsChanged<'t>(x: Types.AvaloniaNode<'t>, func: IList -> unit) =
         Types.dependencyPropertyEvent x ListBox.SelectedItemsProperty func
    
    member _.selectionMode<'t>(x: Types.AvaloniaNode<'t>, mode: SelectionMode) =
        Types.dependencyProperty x ListBox.SelectionModeProperty mode
    
    member _.virtualizationMode<'t>(x: Types.AvaloniaNode<'t>, mode: ItemVirtualizationMode) =
        Types.dependencyProperty x ListBox.VirtualizationModeProperty mode