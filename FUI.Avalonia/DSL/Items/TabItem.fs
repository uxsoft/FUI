module FUI.Avalonia.TabItem

open Avalonia.Controls
open FUI.Avalonia.HeaderedContentControl
 
type TabItemBuilder<'t when 't :> TabItem and 't : equality>() =
    inherit HeaderedContentControlBuilder<'t>()

    /// Dock | ObservableValue<Dock>
    [<CustomOperation("tabStripPlacement")>] 
    member _.tabStripPlacement<'t, 'v>(x, placement: 'v) =
        Types.dependencyProperty x TabItem.TabStripPlacementProperty placement
    
    /// bool | ObservableValue<bool>
    [<CustomOperation("isSelected")>] 
    member _.isSelected<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TabItem.IsSelectedProperty value
        
    [<CustomOperation("onIsSelectedChanged")>] 
    member _.onIsSelectedChanged<'t, 'v>(x, func: bool -> unit) =
        Types.dependencyPropertyEvent x TabItem.IsSelectedProperty func