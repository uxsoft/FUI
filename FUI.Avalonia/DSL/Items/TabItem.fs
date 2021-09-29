module FUI.Avalonia.TabItem

open Avalonia.Controls
open FUI.UiBuilder
open FUI.Avalonia.HeaderedContentControl
open Avalonia.FuncUI.Builder
 
type TabItemBuilder<'t when 't :> TabItem>() =
    inherit HeaderedContentControlBuilder<'t>()

    [<CustomOperation("tabStripPlacement")>] 
    member _.tabStripPlacement<'t>(x: Types.AvaloniaNode<'t>, placement: Dock) =
        Types.dependencyProperty x<Dock>(TabItem.TabStripPlacementProperty, placement, ValueNone) ]
    
    [<CustomOperation("isSelected")>] 
    member _.isSelected<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x<bool>(TabItem.IsSelectedProperty, value, ValueNone) ]
        
    [<CustomOperation("onIsSelectedChanged")>] 
    member _.onIsSelectedChanged<'t>(x: Types.AvaloniaNode<'t>, func: bool -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<bool>(TabItem.IsSelectedProperty, func) ]