module FUI.Avalonia.DockPanel

open Avalonia.Controls
open FUI.UiBuilder
open FUI.Avalonia.Panel
open Avalonia.FuncUI.Builder

type DockPanelBuilder<'t when 't :> DockPanel>() =
    inherit PanelBuilder<'t>()
    
    [<CustomOperation("lastChildFill")>]
    member _.lastChildFill<'t>(x: Node<_, _>, fill: bool) =
        Types.dependencyProperty<bool>(DockPanel.LastChildFillProperty, fill, ValueNone) ]