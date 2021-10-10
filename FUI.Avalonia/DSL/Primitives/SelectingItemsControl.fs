module FUI.Avalonia.SelectingItemsControl

open Avalonia.Controls.Primitives
open Avalonia.Controls
open FUI.UiBuilder
open FUI.Avalonia.ItemsControl
 
type SelectingItemsControlBuilder<'t when 't :> SelectingItemsControl and 't : equality>() =
    inherit ItemsControlBuilder<'t>()

    /// bool | ObservableValue<bool>
    [<CustomOperation("autoScrollToSelectedItem")>] 
    member _.autoScrollToSelectedItem<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x SelectingItemsControl.AutoScrollToSelectedItemProperty value
        
    /// int | ObservableValue<int>
    [<CustomOperation("selectedIndex")>] 
    member _.selectedIndex<'t, 'v>(x: Types.AvaloniaNode<'t>, index: 'v) =
        Types.dependencyProperty x SelectingItemsControl.SelectedIndexProperty index
        
    [<CustomOperation("onSelectedIndexChanged")>] 
    member _.onSelectedIndexChanged<'t, 'v>(x: Types.AvaloniaNode<'t>, func: int -> unit) =
        Types.dependencyPropertyEvent x SelectingItemsControl.SelectedIndexProperty func
        
    /// obj | ObservableValue<obj> 
    [<CustomOperation("selectedItem")>] 
    member _.selectedItem<'t, 'v>(x: Types.AvaloniaNode<'t>, item: 'v) =
        Types.dependencyProperty x SelectingItemsControl.SelectedItemProperty item
        
    [<CustomOperation("onSelectedItemChanged")>] 
    member _.onSelectedItemChanged<'t, 'v>(x: Types.AvaloniaNode<'t>, func: obj -> unit) =
        Types.dependencyPropertyEvent x SelectingItemsControl.SelectedItemProperty func
        
    [<CustomOperation("onSelectionChanged")>] 
    member _.onSelectionChanged<'t, 'v>(x: Types.AvaloniaNode<'t>, func: SelectionChangedEventArgs -> unit) =
        Types.routedEvent x SelectingItemsControl.SelectionChangedEvent func