module FUI.Avalonia.WrapPanel

open Avalonia.Controls
open FUI.UiBuilder
open FUI.Avalonia.Panel
open Avalonia.Layout
open Avalonia.FuncUI.Builder

type WrapPanelBuilder<'t when 't :> WrapPanel>() =
    inherit PanelBuilder<'t>()
    
    [<CustomOperation("itemHeight")>] 
    member _.itemHeight<'t>(x: Types.AvaloniaNode<'t>, value: float) =
        Types.dependencyProperty x<float>(WrapPanel.ItemHeightProperty, value, ValueNone) ]

    [<CustomOperation("itemWidth")>] 
    member _.itemWidth<'t>(x: Types.AvaloniaNode<'t>, value: float) =
        Types.dependencyProperty x<float>(WrapPanel.ItemWidthProperty, value, ValueNone) ]
       
    [<CustomOperation("orientation")>] 
    member _.orientation<'t>(x: Types.AvaloniaNode<'t>, orientation: Orientation) =
        Types.dependencyProperty x<Orientation>(WrapPanel.OrientationProperty, orientation, ValueNone) ]