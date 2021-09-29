module FUI.Avalonia.StackPanel

open Avalonia.Controls
open FUI.UiBuilder
open FUI.Avalonia.Panel
open Avalonia.Layout
open Avalonia.FuncUI.Builder

type StackPanelBuilder<'t when 't :> StackPanel>() =
    inherit PanelBuilder<'t>()
    
    /// <summary>
    /// Gets or sets the size of the spacing to place between child controls.
    /// </summary>
    [<CustomOperation("spacing")>] 
    member _.spacing<'t>(x: Node<_, _>, value: double) =
        Types.dependencyProperty<double>(StackPanel.SpacingProperty, value, ValueNone) ]
    
    /// <summary>
    /// Gets or sets the orientation in which child controls will be laid out.
    /// </summary>
    [<CustomOperation("orientation")>] 
    member _.orientation<'t>(x: Node<_, _>, orientation: Orientation) =
        Types.dependencyProperty<Orientation>(StackPanel.OrientationProperty, orientation, ValueNone) ]