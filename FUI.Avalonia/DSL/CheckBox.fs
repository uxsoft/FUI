module FUI.Avalonia.CheckBox

open Avalonia.Controls
open FUI.Avalonia.ToggleButton

type CheckBoxBuilder<'t when 't :> CheckBox and 't : equality>() = 
    inherit ToggleButtonBuilder<'t>()
