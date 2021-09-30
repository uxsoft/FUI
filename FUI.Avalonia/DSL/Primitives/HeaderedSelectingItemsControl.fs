module FUI.Avalonia.HeaderedSelectingItemsControl

open Avalonia.Controls.Primitives
open FUI.Avalonia.SelectingItemsControl
    
type HeaderedSelectingItemsControlBuilder<'t when 't :> HeaderedSelectingItemsControl and 't : equality>() =
    inherit SelectingItemsControlBuilder<'t>()
    
    [<CustomOperation("header")>] 
    member _.header<'t, 'c when 't :> HeaderedSelectingItemsControl and 'c :> obj>(x: Types.AvaloniaNode<'t>, value: 'c) =
        Types.dependencyProperty x HeaderedSelectingItemsControl.HeaderProperty value