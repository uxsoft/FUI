module FUI.Avalonia.ListBox

open System.Collections
open Avalonia.Controls
open FUI.UiBuilder
open FUI.Avalonia.SelectingItemsControl
open Avalonia.FuncUI.Types
open Avalonia.FuncUI.Builder

let create (attrs: IAttr<ListBox> list): IView<ListBox> =
    ViewBuilder.Create<ListBox>(attrs)
 
type ListBoxBuilder<'t when 't :> ListBox>() =
    inherit SelectingItemsControlBuilder<'t>()

    member _.selectedItems<'t>(x: Types.AvaloniaNode<'t>, items: IList) =
        x @@ [AttrBuilder<'t>.CreateProperty<IList>(ListBox.SelectedItemsProperty, items, ValueNone) ]

    member _.onSelectedItemsChanged<'t>(x: Types.AvaloniaNode<'t>, func: IList -> unit) =
        x @@ [AttrBuilder<'t>.CreateSubscription<IList>(ListBox.SelectedItemsProperty, func) ]
    
    member _.selectionMode<'t>(x: Types.AvaloniaNode<'t>, mode: SelectionMode) =
        x @@ [AttrBuilder<'t>.CreateProperty<SelectionMode>(ListBox.SelectionModeProperty, mode, ValueNone) ]
    
    member _.virtualizationMode<'t>(x: Types.AvaloniaNode<'t>, mode: ItemVirtualizationMode) =
        x @@ [AttrBuilder<'t>.CreateProperty<ItemVirtualizationMode>(ListBox.VirtualizationModeProperty, mode, ValueNone) ]