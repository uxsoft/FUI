module FUI.Avalonia.StackPanel

open Avalonia.Controls
open FUI.UiBuilder
open FUI.Avalonia.Panel
open Avalonia.Layout

type StackPanelBuilder<'t when 't :> StackPanel and 't : equality>() =
    inherit PanelBuilder<'t>()
    
    /// <summary>
    /// Gets or sets the size of the spacing to place between child controls.
    /// </summary>
    [<CustomOperation("spacing")>] 
    member _.spacing<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x StackPanel.SpacingProperty value
    
    /// <summary>
    /// Gets or sets the orientation in which child controls will be laid out.
    /// </summary>
    [<CustomOperation("orientation")>] 
    member _.orientation<'t>(x: Types.AvaloniaNode<'t>, orientation: Orientation) =
        Types.dependencyProperty x StackPanel.OrientationProperty orientation