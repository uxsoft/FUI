module FUI.Avalonia.HeaderedItemsControl


open Avalonia.Controls.Primitives
open FUI.Avalonia.ItemsControl

type HeaderedItemsControlBuilder<'t when 't :> HeaderedItemsControl and 't : equality>() =
    inherit ItemsControlBuilder<'t>()
    
    [<CustomOperation("header")>] 
    member _.header<'t, 'c when 't :> HeaderedItemsControl and 'c :> obj>(x: Types.AvaloniaNode<'t>, value: 'c) =
        Types.dependencyProperty x  HeaderedItemsControl.HeaderProperty value