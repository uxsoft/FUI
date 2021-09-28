module Avalonia.FuncUI.Experiments.DSL.TreeView

    open System.Collections
    open Avalonia.Controls
    open FUI.UiBuilder
    open Avalonia.FuncUI.Experiments.DSL.ItemsControl
    open Avalonia.FuncUI.Builder

    type TreeViewBuilder<'t when 't :> TreeView>() =
        inherit ItemsControlBuilder<'t>()

        /// <summary>
        /// Sets a value indicating whether to automatically scroll to newly selected items.
        /// </summary>
        [<CustomOperation("autoScrollToSelectedItem")>] 
        member _.autoScrollToSelectedItem<'t>(x: Node<_, _>, value: bool) =
            Types.dependencyProperty<bool>(TreeView.AutoScrollToSelectedItemProperty, value, ValueNone) ]
        
        /// <summary>
        /// Sets the selected items.
        /// </summary>
        [<CustomOperation("selectedItem")>] 
        member _.selectedItem<'t>(x: Node<_, _>, value: obj) =
            Types.dependencyProperty<obj>(TreeView.SelectedItemProperty, value, ValueNone) ]
         
        /// <summary>
        /// Sets the selected item.
        /// </summary>
        [<CustomOperation("selectedItems")>] 
        member _.selectedItems<'t>(x: Node<_, _>, value: IList) =
            Types.dependencyProperty<IList>(TreeView.SelectedItemsProperty, value, ValueNone) ]

        /// <summary>
        /// Sets the selection mode.
        /// </summary>
        [<CustomOperation("selectionMode")>] 
        member _.selectionMode<'t>(x: Node<_, _>, value: SelectionMode) =
            Types.dependencyProperty<SelectionMode>(TreeView.SelectionModeProperty, value, ValueNone) ]