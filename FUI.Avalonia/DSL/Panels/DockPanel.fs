module FUI.Avalonia.DockPanel

open Avalonia.Controls
open FUI.Avalonia.Panel

type DockPanelBuilder<'t when 't :> DockPanel and 't : equality>() =
    inherit PanelBuilder<'t>()
    
    [<CustomOperation("lastChildFill")>]
    member _.lastChildFill<'t>(x: Types.AvaloniaNode<'t>, fill: bool) =
        Types.dependencyProperty x DockPanel.LastChildFillProperty fill