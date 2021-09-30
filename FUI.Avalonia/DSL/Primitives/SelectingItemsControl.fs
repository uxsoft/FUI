module FUI.Avalonia.SelectingItemsControl

open Avalonia.Controls.Primitives
open Avalonia.Controls
open FUI.UiBuilder
open FUI.Avalonia.ItemsControl
 
type SelectingItemsControlBuilder<'t when 't :> SelectingItemsControl and 't : equality>() =
    inherit ItemsControlBuilder<'t>()

    [<CustomOperation("autoScrollToSelectedItem")>] 
    member _.autoScrollToSelectedItem<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x SelectingItemsControl.AutoScrollToSelectedItemProperty value
        
    [<CustomOperation("selectedIndex")>] 
    member _.selectedIndex<'t>(x: Types.AvaloniaNode<'t>, index: int) =
        Types.dependencyProperty x SelectingItemsControl.SelectedIndexProperty index
        
    [<CustomOperation("onSelectedIndexChanged")>] 
    member _.onSelectedIndexChanged<'t>(x: Types.AvaloniaNode<'t>, func: int -> unit) =
        Types.dependencyPropertyEvent x SelectingItemsControl.SelectedIndexProperty func
         
    [<CustomOperation("selectedItem")>] 
    member _.selectedItem<'t>(x: Types.AvaloniaNode<'t>, item: obj) =
        Types.dependencyProperty x SelectingItemsControl.SelectedItemProperty item
        
    [<CustomOperation("onSelectedItemChanged")>] 
    member _.onSelectedItemChanged<'t>(x: Types.AvaloniaNode<'t>, func: obj -> unit) =
        Types.dependencyPropertyEvent x SelectingItemsControl.SelectedItemProperty func
        
    [<CustomOperation("onSelectionChanged")>] 
    member _.onSelectionChanged<'t>(x: Types.AvaloniaNode<'t>, func: SelectionChangedEventArgs -> unit) =
        Types.routedEvent x SelectingItemsControl.SelectionChangedEvent func