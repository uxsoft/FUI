module Avalonia.FuncUI.Experiments.DSL.TabItem

open Avalonia.Controls
open FUI.UiBuilder
open Avalonia.FuncUI.Experiments.DSL.HeaderedContentControl
open Avalonia.FuncUI.Builder
 
type TabItemBuilder<'t when 't :> TabItem>() =
    inherit HeaderedContentControlBuilder<'t>()

    [<CustomOperation("tabStripPlacement")>] 
    member _.tabStripPlacement<'t>(x: Node<_, _>, placement: Dock) =
        Types.dependencyProperty<Dock>(TabItem.TabStripPlacementProperty, placement, ValueNone) ]
    
    [<CustomOperation("isSelected")>] 
    member _.isSelected<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(TabItem.IsSelectedProperty, value, ValueNone) ]
        
    [<CustomOperation("onIsSelectedChanged")>] 
    member _.onIsSelectedChanged<'t>(x: Node<_, _>, func: bool -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<bool>(TabItem.IsSelectedProperty, func) ]