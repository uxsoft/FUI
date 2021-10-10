module FUI.Avalonia.RadioButton

open Avalonia.Controls
open FUI.Avalonia.ToggleButton

type RadioButtonBuilder<'t when 't :> RadioButton and 't : equality>() =
    inherit ToggleButtonBuilder<'t>()

    /// string | ObservableValue<string>
    member _.groupName<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x RadioButton.GroupNameProperty value
    