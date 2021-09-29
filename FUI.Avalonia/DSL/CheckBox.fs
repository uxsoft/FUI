module FUI.Avalonia.CheckBox

open Avalonia.Controls
open FUI.Avalonia.ToggleButton

type CheckBoxBuilder<'t when 't :> CheckBox>() = 
    inherit ToggleButtonBuilder<'t>()
