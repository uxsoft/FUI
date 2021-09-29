module FUI.Avalonia.ToggleSwitch

open Avalonia.Controls
open Avalonia.Controls.Templates
open FUI.UiBuilder
open FUI.Avalonia.ToggleButton
open Avalonia.FuncUI.Builder

type ToggleSwitchBuilder<'t when 't :> ToggleSwitch>() =
    inherit ToggleButtonBuilder<'t>()
    
    [<CustomOperation("onContent")>] 
    member _.onContent<'t>(x: Node<_, _>, value: obj) =
        Types.dependencyProperty<obj>(ToggleSwitch.OnContentProperty, value, ValueNone) ]
    
    [<CustomOperation("onContentTemplate")>] 
    member _.onContentTemplate<'t>(x: Node<_, _>, template: IDataTemplate) =
        Types.dependencyProperty<IDataTemplate>(ToggleSwitch.OnContentTemplateProperty, template, ValueNone) ]
    
    [<CustomOperation("offContent")>] 
    member _.offContent<'t>(x: Node<_, _>, value: obj) =
        Types.dependencyProperty<obj>(ToggleSwitch.OffContentProperty, value, ValueNone) ]

    [<CustomOperation("offContentTemplate")>] 
    member _.offContentTemplate<'t>(x: Node<_, _>, template: IDataTemplate) =
        Types.dependencyProperty<IDataTemplate>(ToggleSwitch.OffContentTemplateProperty, template, ValueNone) ]
        