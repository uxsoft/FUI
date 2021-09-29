module FUI.Avalonia.ToolTip 

open Avalonia.Controls
open FUI.Avalonia.ContentControl

type ToolTipBuilder<'t when 't :> ToolTip>() =
    inherit ContentControlBuilder<'t>()