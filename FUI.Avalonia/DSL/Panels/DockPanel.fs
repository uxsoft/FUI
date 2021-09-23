module Avalonia.FuncUI.Experiments.DSL.DockPanel

open Avalonia.Controls
open FUI.UIBuilder
open Avalonia.FuncUI.Experiments.DSL.Panel
open Avalonia.FuncUI.Builder

type DockPanelBuilder<'t when 't :> DockPanel>() =
    inherit PanelBuilder<'t>()
    
    [<CustomOperation("lastChildFill")>]
    member _.lastChildFill<'t>(x: Element, fill: bool) =
        x @@ [ AttrBuilder<'t>.CreateProperty<bool>(DockPanel.LastChildFillProperty, fill, ValueNone) ]