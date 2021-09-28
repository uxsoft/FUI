module Avalonia.FuncUI.Experiments.DSL.TreeViewItem

open FUI.UiBuilder
open Avalonia.FuncUI.Experiments.DSL.HeaderedItemsControl

open Avalonia.Controls
open Avalonia.FuncUI.Builder
   
type TreeViewItemBuilder<'t when 't :> TreeViewItem>() =
    inherit HeaderedItemsControlBuilder<'t>()

    /// <summary>
    /// Sets a value indicating whether the item is expanded to show its children.
    /// </summary>
    member _.isExpanded<'t>(x: Node<_, _>, value: bool) =
        x @@ [AttrBuilder<'t>.CreateProperty<bool>(TreeViewItem.IsExpandedProperty, value, ValueNone) ]
    
    /// <summary>
    /// Sets the selection state of the item.
    /// </summary>
    member _.isSelected<'t>(x: Node<_, _>, value: bool ) =
        x @@ [AttrBuilder<'t>.CreateProperty<bool >(TreeViewItem.IsSelectedProperty, value, ValueNone) ]
     
    /// <summary>
    /// Sets the level/indentation of the item.
    /// </summary>
    member _.level<'t>(x: Node<_, _>, value: int) =
        x @@ [AttrBuilder<'t>.CreateProperty<int>(TreeViewItem.LevelProperty, value, ValueNone) ]