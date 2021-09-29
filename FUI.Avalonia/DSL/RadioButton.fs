module FUI.Avalonia.RadioButton

open Avalonia.Controls
open FUI.UiBuilder
open FUI.Avalonia.ToggleButton
open Avalonia.FuncUI.Builder

type RadioButtonBuilder<'t when 't :> RadioButton>() =
    inherit ToggleButtonBuilder<'t>()

    member _.groupName<'t>(x: Node<_, _>, value: string) =
        Types.dependencyProperty<string>(RadioButton.GroupNameProperty, value, ValueNone) ]
    