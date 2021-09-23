module Avalonia.FuncUI.Experiments.DSL.WrapPanel

open Avalonia.Controls
open FUI.UIBuilder
open Avalonia.FuncUI.Experiments.DSL.Panel
open Avalonia.Layout
open Avalonia.FuncUI.Builder

type WrapPanelBuilder<'t when 't :> WrapPanel>() =
    inherit PanelBuilder<'t>()
    
    [<CustomOperation("itemHeight")>] 
    member _.itemHeight<'t>(x: Element, value: float) =
        x @@ [ AttrBuilder<'t>.CreateProperty<float>(WrapPanel.ItemHeightProperty, value, ValueNone) ]

    [<CustomOperation("itemWidth")>] 
    member _.itemWidth<'t>(x: Element, value: float) =
        x @@ [ AttrBuilder<'t>.CreateProperty<float>(WrapPanel.ItemWidthProperty, value, ValueNone) ]
       
    [<CustomOperation("orientation")>] 
    member _.orientation<'t>(x: Element, orientation: Orientation) =
        x @@ [ AttrBuilder<'t>.CreateProperty<Orientation>(WrapPanel.OrientationProperty, orientation, ValueNone) ]