module FUI.Avalonia.TreeView

    open System.Collections
    open Avalonia.Controls
    open FUI.Avalonia.ItemsControl

    type TreeViewBuilder<'t when 't :> TreeView and 't : equality>() =
        inherit ItemsControlBuilder<'t>()

        /// bool | ObservableValue<bool>
        [<CustomOperation("autoScrollToSelectedItem")>] 
        member _.autoScrollToSelectedItem<'t, 'v>(x, value: 'v) =
            Types.dependencyProperty x TreeView.AutoScrollToSelectedItemProperty value
        
        /// obj | ObservableValue<obj>
        [<CustomOperation("selectedItem")>] 
        member _.selectedItem<'t, 'v>(x, value: 'v) =
            Types.dependencyProperty x TreeView.SelectedItemProperty value

        /// IList | ObservableValue<IList>         
        [<CustomOperation("selectedItems")>] 
        member _.selectedItems<'t, 'v>(x, value: 'v) =
            Types.dependencyProperty x TreeView.SelectedItemsProperty value

        /// SelectionMode | ObservableValue<SelectionMode>
        [<CustomOperation("selectionMode")>] 
        member _.selectionMode<'t, 'v>(x, value: 'v) =
            Types.dependencyProperty x TreeView.SelectionModeProperty value