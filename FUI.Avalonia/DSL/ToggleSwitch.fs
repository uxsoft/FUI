module FUI.Avalonia.ToggleSwitch

open Avalonia.Controls
open Avalonia.Controls.Templates
open FUI.Avalonia.ToggleButton

type ToggleSwitchBuilder<'t when 't :> ToggleSwitch and 't : equality>() =
    inherit ToggleButtonBuilder<'t>()
    
    [<CustomOperation("onContent")>] 
    member _.onContent<'t>(x: Types.AvaloniaNode<'t>, value: obj) =
        Types.dependencyProperty x ToggleSwitch.OnContentProperty value
    
    [<CustomOperation("onContentTemplate")>] 
    member _.onContentTemplate<'t>(x: Types.AvaloniaNode<'t>, template: IDataTemplate) =
        Types.dependencyProperty x ToggleSwitch.OnContentTemplateProperty template
    
    [<CustomOperation("offContent")>] 
    member _.offContent<'t>(x: Types.AvaloniaNode<'t>, value: obj) =
        Types.dependencyProperty x ToggleSwitch.OffContentProperty value

    [<CustomOperation("offContentTemplate")>] 
    member _.offContentTemplate<'t>(x: Types.AvaloniaNode<'t>, template: IDataTemplate) =
        Types.dependencyProperty x ToggleSwitch.OffContentTemplateProperty template
        