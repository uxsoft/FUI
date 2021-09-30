module FUI.Avalonia.TreeViewItem

open FUI.Avalonia.HeaderedItemsControl
open Avalonia.Controls
   
type TreeViewItemBuilder<'t when 't :> TreeViewItem and 't : equality>() =
    inherit HeaderedItemsControlBuilder<'t>()

    /// <summary>
    /// Sets a value indicating whether the item is expanded to show its children.
    /// </summary>
    member _.isExpanded<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x TreeViewItem.IsExpandedProperty value
    
    /// <summary>
    /// Sets the selection state of the item.
    /// </summary>
    member _.isSelected<'t>(x: Types.AvaloniaNode<'t>, value: bool ) =
        Types.dependencyProperty x TreeViewItem.IsSelectedProperty value
     
    /// <summary>
    /// Sets the level/indentation of the item.
    /// </summary>
    member _.level<'t>(x: Types.AvaloniaNode<'t>, value: int) =
        Types.dependencyProperty x TreeViewItem.LevelProperty value