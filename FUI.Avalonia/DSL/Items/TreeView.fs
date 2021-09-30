﻿module Avalonia.FuncUI.Experiments.DSL.TreeView

    open System.Collections
    open Avalonia.Controls
    open FUI.UIBuilder
    open Avalonia.FuncUI.Experiments.DSL.ItemsControl
    open Avalonia.FuncUI.Builder

    type TreeViewBuilder<'t when 't :> TreeView>() =
        inherit ItemsControlBuilder<'t>()

        /// <summary>
        /// Sets a value indicating whether to automatically scroll to newly selected items.
        /// </summary>
        [<CustomOperation("autoScrollToSelectedItem")>] 
        member _.autoScrollToSelectedItem<'t>(x: Element, value: bool) =
            x @@ [ AttrBuilder<'t>.CreateProperty<bool>(TreeView.AutoScrollToSelectedItemProperty, value, ValueNone) ]
        
        /// <summary>
        /// Sets the selected items.
        /// </summary>
        [<CustomOperation("selectedItem")>] 
        member _.selectedItem<'t>(x: Element, value: obj) =
            x @@ [ AttrBuilder<'t>.CreateProperty<obj>(TreeView.SelectedItemProperty, value, ValueNone) ]
         
        /// <summary>
        /// Sets the selected item.
        /// </summary>
        [<CustomOperation("selectedItems")>] 
        member _.selectedItems<'t>(x: Element, value: IList) =
            x @@ [ AttrBuilder<'t>.CreateProperty<IList>(TreeView.SelectedItemsProperty, value, ValueNone) ]

        /// <summary>
        /// Sets the selection mode.
        /// </summary>
        [<CustomOperation("selectionMode")>] 
        member _.selectionMode<'t>(x: Element, value: SelectionMode) =
            x @@ [ AttrBuilder<'t>.CreateProperty<SelectionMode>(TreeView.SelectionModeProperty, value, ValueNone) ]