module Avalonia.FuncUI.Experiments.DSL.RadioButton

open Avalonia.Controls
open FUI.UIBuilder
open Avalonia.FuncUI.Experiments.DSL.ToggleButton
open Avalonia.FuncUI.Builder

type RadioButtonBuilder<'t when 't :> RadioButton>() =
    inherit ToggleButtonBuilder<'t>()

    member _.groupName<'t>(x: Element, value: string) =
        x @@ [ AttrBuilder<'t>.CreateProperty<string>(RadioButton.GroupNameProperty, value, ValueNone) ]
    