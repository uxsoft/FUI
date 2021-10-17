module FUI.Avalonia.ToggleSwitch

open Avalonia.Controls
open Avalonia.Controls.Templates
open FUI.Avalonia.ToggleButton

type ToggleSwitchBuilder<'t when 't :> ToggleSwitch and 't : equality>() =
    inherit ToggleButtonBuilder<'t>()
    
    /// obj | ObservableValue<obj>
    [<CustomOperation("onContent")>] 
    member _.onContent<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x ToggleSwitch.OnContentProperty value
    
    /// IDataTemplate | ObservableValue<IDataTemplate>
    [<CustomOperation("onContentTemplate")>] 
    member _.onContentTemplate<'t, 'v>(x, template: 'v) =
        Types.dependencyProperty x ToggleSwitch.OnContentTemplateProperty template
    
    /// obj | ObservableValue<obj>
    [<CustomOperation("offContent")>] 
    member _.offContent<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x ToggleSwitch.OffContentProperty value

    /// IDataTemplate | ObservableValue<IDataTemplate>
    [<CustomOperation("offContentTemplate")>] 
    member _.offContentTemplate<'t, 'v>(x, template: 'v) =
        Types.dependencyProperty x ToggleSwitch.OffContentTemplateProperty template
        