module FUI.Avalonia.SelectingItemsControl

open Avalonia.Controls.Primitives
open Avalonia.Controls
open Avalonia.FuncUI.Builder
open FUI.UiBuilder
open FUI.Avalonia.ItemsControl
 
type SelectingItemsControlBuilder<'t when 't :> SelectingItemsControl>() =
    inherit ItemsControlBuilder<'t>()

    [<CustomOperation("autoScrollToSelectedItem")>] 
    member _.autoScrollToSelectedItem<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(SelectingItemsControl.AutoScrollToSelectedItemProperty, value, ValueNone) ]
        
    [<CustomOperation("selectedIndex")>] 
    member _.selectedIndex<'t>(x: Node<_, _>, index: int) =
        Types.dependencyProperty<int>(SelectingItemsControl.SelectedIndexProperty, index, ValueNone) ]
        
    [<CustomOperation("onSelectedIndexChanged")>] 
    member _.onSelectedIndexChanged<'t>(x: Node<_, _>, func: int -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<int>(SelectingItemsControl.SelectedIndexProperty, func) ]
        
    [<CustomOperation("selectedItem")>] 
    member _.selectedItem<'t>(x: Node<_, _>, item: obj) =
        Types.dependencyProperty<obj>(SelectingItemsControl.SelectedItemProperty, item, ValueNone) ]
        
    [<CustomOperation("onSelectedItemChanged")>] 
    member _.onSelectedItemChanged<'t>(x: Node<_, _>, func: obj -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<obj>(SelectingItemsControl.SelectedItemProperty, func) ]
        
    [<CustomOperation("onSelectionChanged")>] 
    member _.onSelectionChanged<'t>(x: Node<_, _>, func: SelectionChangedEventArgs -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<SelectionChangedEventArgs>(SelectingItemsControl.SelectionChangedEvent, func) ]