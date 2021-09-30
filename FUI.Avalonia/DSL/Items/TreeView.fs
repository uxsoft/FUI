module FUI.Avalonia.TreeView

    open System.Collections
    open Avalonia.Controls
    open FUI.Avalonia.ItemsControl

    type TreeViewBuilder<'t when 't :> TreeView and 't : equality>() =
        inherit ItemsControlBuilder<'t>()

        /// <summary>
        /// Sets a value indicating whether to automatically scroll to newly selected items.
        /// </summary>
        [<CustomOperation("autoScrollToSelectedItem")>] 
        member _.autoScrollToSelectedItem<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
            Types.dependencyProperty x TreeView.AutoScrollToSelectedItemProperty value
        
        /// <summary>
        /// Sets the selected items.
        /// </summary>
        [<CustomOperation("selectedItem")>] 
        member _.selectedItem<'t>(x: Types.AvaloniaNode<'t>, value: obj) =
            Types.dependencyProperty x TreeView.SelectedItemProperty value
         
        /// <summary>
        /// Sets the selected item.
        /// </summary>
        [<CustomOperation("selectedItems")>] 
        member _.selectedItems<'t>(x: Types.AvaloniaNode<'t>, value: IList) =
            Types.dependencyProperty x TreeView.SelectedItemsProperty value

        /// <summary>
        /// Sets the selection mode.
        /// </summary>
        [<CustomOperation("selectionMode")>] 
        member _.selectionMode<'t>(x: Types.AvaloniaNode<'t>, value: SelectionMode) =
            Types.dependencyProperty x TreeView.SelectionModeProperty value