module FUI.Avalonia.RadioButton

open Avalonia.Controls
open FUI.Avalonia.ToggleButton

type RadioButtonBuilder<'t when 't :> RadioButton and 't : equality>() =
    inherit ToggleButtonBuilder<'t>()

    member _.groupName<'t>(x: Types.AvaloniaNode<'t>, value: string) =
        Types.dependencyProperty x RadioButton.GroupNameProperty value
    