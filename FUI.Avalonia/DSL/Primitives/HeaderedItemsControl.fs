module Avalonia.FuncUI.Experiments.DSL.HeaderedItemsControl


open Avalonia.Controls.Primitives
open FUI.UIBuilder
open Avalonia.FuncUI.Experiments.DSL.ItemsControl
open Avalonia.FuncUI.Types
open Avalonia.FuncUI.Builder

type HeaderedItemsControlBuilder<'t when 't :> HeaderedItemsControl>() =
    inherit ItemsControlBuilder<'t>()
    
    [<CustomOperation("header")>] 
    member _.header<'t, 'c when 't :> HeaderedItemsControl and 'c :> obj>(x: Element, value: 'c) =
        let prop = 
            match box value with
            | :? IView as view -> AttrBuilder<'t>.CreateContentSingle(HeaderedItemsControl.HeaderProperty, Some view)
            | :? string as text -> AttrBuilder<'t>.CreateProperty<string>(HeaderedItemsControl.HeaderProperty, text, ValueNone)
            | _ -> AttrBuilder<'t>.CreateProperty<obj>(HeaderedItemsControl.HeaderProperty, value, ValueNone)
        
        x @@ [ prop ]