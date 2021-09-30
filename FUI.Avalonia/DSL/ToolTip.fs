module FUI.Avalonia.ToolTip 

open Avalonia.Controls
open FUI.Avalonia.ContentControl

type ToolTipBuilder<'t when 't :> ToolTip and 't : equality>() =
    inherit ContentControlBuilder<'t>()