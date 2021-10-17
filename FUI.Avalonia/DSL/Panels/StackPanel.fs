module FUI.Avalonia.StackPanel

open Avalonia.Controls
open FUI.UiBuilder
open FUI.Avalonia.Panel
open Avalonia.Layout

type StackPanelBuilder<'t when 't :> StackPanel and 't : equality>() =
    inherit PanelBuilder<'t>()
    
    /// double | ObservableValue<double>
    [<CustomOperation("spacing")>] 
    member _.spacing<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x StackPanel.SpacingProperty value
    
    /// Orientation | ObservableValue<Orientation>
    [<CustomOperation("orientation")>] 
    member _.orientation<'t, 'v>(x, orientation: 'v) =
        Types.dependencyProperty x StackPanel.OrientationProperty orientation