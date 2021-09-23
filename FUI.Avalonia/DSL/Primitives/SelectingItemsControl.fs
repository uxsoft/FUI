module Avalonia.FuncUI.Experiments.DSL.SelectingItemsControl

open Avalonia.Controls.Primitives
open Avalonia.Controls
open Avalonia.FuncUI.Builder
open FUI.UIBuilder
open Avalonia.FuncUI.Experiments.DSL.ItemsControl
 
type SelectingItemsControlBuilder<'t when 't :> SelectingItemsControl>() =
    inherit ItemsControlBuilder<'t>()

    [<CustomOperation("autoScrollToSelectedItem")>] 
    member _.autoScrollToSelectedItem<'t>(x: Element, value: bool) =
        x @@ [ AttrBuilder<'t>.CreateProperty<bool>(SelectingItemsControl.AutoScrollToSelectedItemProperty, value, ValueNone) ]
        
    [<CustomOperation("selectedIndex")>] 
    member _.selectedIndex<'t>(x: Element, index: int) =
        x @@ [ AttrBuilder<'t>.CreateProperty<int>(SelectingItemsControl.SelectedIndexProperty, index, ValueNone) ]
        
    [<CustomOperation("onSelectedIndexChanged")>] 
    member _.onSelectedIndexChanged<'t>(x: Element, func: int -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<int>(SelectingItemsControl.SelectedIndexProperty, func) ]
        
    [<CustomOperation("selectedItem")>] 
    member _.selectedItem<'t>(x: Element, item: obj) =
        x @@ [ AttrBuilder<'t>.CreateProperty<obj>(SelectingItemsControl.SelectedItemProperty, item, ValueNone) ]
        
    [<CustomOperation("onSelectedItemChanged")>] 
    member _.onSelectedItemChanged<'t>(x: Element, func: obj -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<obj>(SelectingItemsControl.SelectedItemProperty, func) ]
        
    [<CustomOperation("onSelectionChanged")>] 
    member _.onSelectionChanged<'t>(x: Element, func: SelectionChangedEventArgs -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<SelectionChangedEventArgs>(SelectingItemsControl.SelectionChangedEvent, func) ]