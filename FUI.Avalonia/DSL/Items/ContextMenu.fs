module FUI.Avalonia.ContextMenu

open Avalonia.Controls
open FUI.Avalonia.MenuBase
 
type ContextMenuBuilder<'t when 't :> ContextMenu>() =
    inherit MenuBaseBuilder<'t>()