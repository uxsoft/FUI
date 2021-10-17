module FUI.Avalonia.WrapPanel

open Avalonia.Controls
open FUI.Avalonia.Panel
open Avalonia.Layout

type WrapPanelBuilder<'t when 't :> WrapPanel and 't : equality>() =
    inherit PanelBuilder<'t>()
    
    /// float | ObservableValue<float>
    [<CustomOperation("itemHeight")>] 
    member _.itemHeight<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x WrapPanel.ItemHeightProperty value

    /// float | ObservableValue<float>
    [<CustomOperation("itemWidth")>] 
    member _.itemWidth<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x WrapPanel.ItemWidthProperty value
       
    /// Orientation | ObservableValue<Orientation>
    [<CustomOperation("orientation")>] 
    member _.orientation<'t, 'v>(x, orientation: 'v) =
        Types.dependencyProperty x WrapPanel.OrientationProperty orientation