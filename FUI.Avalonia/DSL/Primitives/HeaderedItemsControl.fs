module FUI.Avalonia.HeaderedItemsControl


open Avalonia.Controls.Primitives
open FUI.Avalonia.ItemsControl

type HeaderedItemsControlBuilder<'t when 't :> HeaderedItemsControl and 't : equality>() =
    inherit ItemsControlBuilder<'t>()
    
    /// obj | ObservableValue<obj>
    [<CustomOperation("header")>] 
    member _.header<'t, 'v when 't :> HeaderedItemsControl>(x, value: 'v) =
        Types.dependencyProperty x  HeaderedItemsControl.HeaderProperty value