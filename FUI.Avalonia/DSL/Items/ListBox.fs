module Avalonia.FuncUI.Experiments.DSL.ListBox

open System.Collections
open Avalonia.Controls
open FUI.UIBuilder
open Avalonia.FuncUI.Experiments.DSL.SelectingItemsControl
open Avalonia.FuncUI.Types
open Avalonia.FuncUI.Builder

let create (attrs: IAttr<ListBox> list): IView<ListBox> =
    ViewBuilder.Create<ListBox>(attrs)
 
type ListBoxBuilder<'t when 't :> ListBox>() =
    inherit SelectingItemsControlBuilder<'t>()

    member _.selectedItems<'t>(x: Element, items: IList) =
        x @@ [AttrBuilder<'t>.CreateProperty<IList>(ListBox.SelectedItemsProperty, items, ValueNone) ]

    member _.onSelectedItemsChanged<'t>(x: Element, func: IList -> unit) =
        x @@ [AttrBuilder<'t>.CreateSubscription<IList>(ListBox.SelectedItemsProperty, func) ]
    
    member _.selectionMode<'t>(x: Element, mode: SelectionMode) =
        x @@ [AttrBuilder<'t>.CreateProperty<SelectionMode>(ListBox.SelectionModeProperty, mode, ValueNone) ]
    
    member _.virtualizationMode<'t>(x: Element, mode: ItemVirtualizationMode) =
        x @@ [AttrBuilder<'t>.CreateProperty<ItemVirtualizationMode>(ListBox.VirtualizationModeProperty, mode, ValueNone) ]