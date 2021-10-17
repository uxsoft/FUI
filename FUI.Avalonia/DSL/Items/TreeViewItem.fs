module FUI.Avalonia.TreeViewItem

open FUI.Avalonia.HeaderedItemsControl
open Avalonia.Controls
   
type TreeViewItemBuilder<'t when 't :> TreeViewItem and 't : equality>() =
    inherit HeaderedItemsControlBuilder<'t>()

    /// bool | ObservableValue<bool>
    member _.isExpanded<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TreeViewItem.IsExpandedProperty value

    /// bool | ObservableValue<bool>    
    member _.isSelected<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TreeViewItem.IsSelectedProperty value
     
    /// int | ObservableValue<int>
    member _.level<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TreeViewItem.LevelProperty value