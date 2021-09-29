module FUI.Avalonia.TreeViewItem

open FUI.UiBuilder
open FUI.Avalonia.HeaderedItemsControl

open Avalonia.Controls
open Avalonia.FuncUI.Builder
   
type TreeViewItemBuilder<'t when 't :> TreeViewItem>() =
    inherit HeaderedItemsControlBuilder<'t>()

    /// <summary>
    /// Sets a value indicating whether the item is expanded to show its children.
    /// </summary>
    member _.isExpanded<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        x @@ [AttrBuilder<'t>.CreateProperty<bool>(TreeViewItem.IsExpandedProperty, value, ValueNone) ]
    
    /// <summary>
    /// Sets the selection state of the item.
    /// </summary>
    member _.isSelected<'t>(x: Types.AvaloniaNode<'t>, value: bool ) =
        x @@ [AttrBuilder<'t>.CreateProperty<bool >(TreeViewItem.IsSelectedProperty, value, ValueNone) ]
     
    /// <summary>
    /// Sets the level/indentation of the item.
    /// </summary>
    member _.level<'t>(x: Types.AvaloniaNode<'t>, value: int) =
        x @@ [AttrBuilder<'t>.CreateProperty<int>(TreeViewItem.LevelProperty, value, ValueNone) ]