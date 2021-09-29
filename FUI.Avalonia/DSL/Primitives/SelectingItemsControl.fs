module FUI.Avalonia.SelectingItemsControl

open Avalonia.Controls.Primitives
open Avalonia.Controls
open FUI.UiBuilder
open FUI.Avalonia.ItemsControl
 
type SelectingItemsControlBuilder<'t when 't :> SelectingItemsControl>() =
    inherit ItemsControlBuilder<'t>()

    [<CustomOperation("autoScrollToSelectedItem")>] 
    member _.autoScrollToSelectedItem<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x<bool>(SelectingItemsControl.AutoScrollToSelectedItemProperty, value, ValueNone) ]
        
    [<CustomOperation("selectedIndex")>] 
    member _.selectedIndex<'t>(x: Types.AvaloniaNode<'t>, index: int) =
        Types.dependencyProperty x<int>(SelectingItemsControl.SelectedIndexProperty, index, ValueNone) ]
        
    [<CustomOperation("onSelectedIndexChanged")>] 
    member _.onSelectedIndexChanged<'t>(x: Types.AvaloniaNode<'t>, func: int -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<int>(SelectingItemsControl.SelectedIndexProperty, func) ]
        
    [<CustomOperation("selectedItem")>] 
    member _.selectedItem<'t>(x: Types.AvaloniaNode<'t>, item: obj) =
        Types.dependencyProperty x<obj>(SelectingItemsControl.SelectedItemProperty, item, ValueNone) ]
        
    [<CustomOperation("onSelectedItemChanged")>] 
    member _.onSelectedItemChanged<'t>(x: Types.AvaloniaNode<'t>, func: obj -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<obj>(SelectingItemsControl.SelectedItemProperty, func) ]
        
    [<CustomOperation("onSelectionChanged")>] 
    member _.onSelectionChanged<'t>(x: Types.AvaloniaNode<'t>, func: SelectionChangedEventArgs -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<SelectionChangedEventArgs>(SelectingItemsControl.SelectionChangedEvent, func) ]