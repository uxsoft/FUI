module FUI.Avalonia.ContextMenu

open Avalonia.Controls
open FUI.Avalonia.MenuBase
 
type ContextMenuBuilder<'t when 't :> ContextMenu and 't : equality>() =
    inherit MenuBaseBuilder<'t>()