module FUI.Avalonia.TabItem

open Avalonia.Controls
open FUI.Avalonia.HeaderedContentControl
 
type TabItemBuilder<'t when 't :> TabItem and 't : equality>() =
    inherit HeaderedContentControlBuilder<'t>()

    [<CustomOperation("tabStripPlacement")>] 
    member _.tabStripPlacement<'t>(x: Types.AvaloniaNode<'t>, placement: Dock) =
        Types.dependencyProperty x TabItem.TabStripPlacementProperty placement
    
    [<CustomOperation("isSelected")>] 
    member _.isSelected<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x TabItem.IsSelectedProperty value
        
    [<CustomOperation("onIsSelectedChanged")>] 
    member _.onIsSelectedChanged<'t>(x: Types.AvaloniaNode<'t>, func: bool -> unit) =
        Types.dependencyPropertyEvent x TabItem.IsSelectedProperty func