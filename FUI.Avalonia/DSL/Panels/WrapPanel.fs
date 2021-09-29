module FUI.Avalonia.WrapPanel

open Avalonia.Controls
open FUI.UiBuilder
open FUI.Avalonia.Panel
open Avalonia.Layout
open Avalonia.FuncUI.Builder

type WrapPanelBuilder<'t when 't :> WrapPanel>() =
    inherit PanelBuilder<'t>()
    
    [<CustomOperation("itemHeight")>] 
    member _.itemHeight<'t>(x: Node<_, _>, value: float) =
        Types.dependencyProperty<float>(WrapPanel.ItemHeightProperty, value, ValueNone) ]

    [<CustomOperation("itemWidth")>] 
    member _.itemWidth<'t>(x: Node<_, _>, value: float) =
        Types.dependencyProperty<float>(WrapPanel.ItemWidthProperty, value, ValueNone) ]
       
    [<CustomOperation("orientation")>] 
    member _.orientation<'t>(x: Node<_, _>, orientation: Orientation) =
        Types.dependencyProperty<Orientation>(WrapPanel.OrientationProperty, orientation, ValueNone) ]