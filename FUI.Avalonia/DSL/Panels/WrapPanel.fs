module FUI.Avalonia.WrapPanel

open Avalonia.Controls
open FUI.Avalonia.Panel
open Avalonia.Layout

type WrapPanelBuilder<'t when 't :> WrapPanel and 't : equality>() =
    inherit PanelBuilder<'t>()
    
    [<CustomOperation("itemHeight")>] 
    member _.itemHeight<'t>(x: Types.AvaloniaNode<'t>, value: float) =
        Types.dependencyProperty x WrapPanel.ItemHeightProperty value

    [<CustomOperation("itemWidth")>] 
    member _.itemWidth<'t>(x: Types.AvaloniaNode<'t>, value: float) =
        Types.dependencyProperty x WrapPanel.ItemWidthProperty value
       
    [<CustomOperation("orientation")>] 
    member _.orientation<'t>(x: Types.AvaloniaNode<'t>, orientation: Orientation) =
        Types.dependencyProperty x WrapPanel.OrientationProperty orientation