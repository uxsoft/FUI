module FUI.Avalonia.DockPanel

open Avalonia.Controls
open FUI.Avalonia.Panel

type DockPanelBuilder<'t when 't :> DockPanel and 't : equality>() =
    inherit PanelBuilder<'t>()
    
    /// bool | ObservableValue<bool>
    [<CustomOperation("lastChildFill")>]
    member _.lastChildFill<'t, 'v>(x, fill: 'v) =
        Types.dependencyProperty x DockPanel.LastChildFillProperty fill