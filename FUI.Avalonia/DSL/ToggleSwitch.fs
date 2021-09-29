module FUI.Avalonia.ToggleSwitch

open Avalonia.Controls
open Avalonia.Controls.Templates
open FUI.UiBuilder
open FUI.Avalonia.ToggleButton
open Avalonia.FuncUI.Builder

type ToggleSwitchBuilder<'t when 't :> ToggleSwitch>() =
    inherit ToggleButtonBuilder<'t>()
    
    [<CustomOperation("onContent")>] 
    member _.onContent<'t>(x: Types.AvaloniaNode<'t>, value: obj) =
        Types.dependencyProperty x<obj>(ToggleSwitch.OnContentProperty, value, ValueNone) ]
    
    [<CustomOperation("onContentTemplate")>] 
    member _.onContentTemplate<'t>(x: Types.AvaloniaNode<'t>, template: IDataTemplate) =
        Types.dependencyProperty x<IDataTemplate>(ToggleSwitch.OnContentTemplateProperty, template, ValueNone) ]
    
    [<CustomOperation("offContent")>] 
    member _.offContent<'t>(x: Types.AvaloniaNode<'t>, value: obj) =
        Types.dependencyProperty x<obj>(ToggleSwitch.OffContentProperty, value, ValueNone) ]

    [<CustomOperation("offContentTemplate")>] 
    member _.offContentTemplate<'t>(x: Types.AvaloniaNode<'t>, template: IDataTemplate) =
        Types.dependencyProperty x<IDataTemplate>(ToggleSwitch.OffContentTemplateProperty, template, ValueNone) ]
        