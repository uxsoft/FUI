module FUI.Avalonia.Menu

open Avalonia.Controls
open FUI.Avalonia.MenuBase
 
type MenuBuilder<'t when 't :> Menu and 't : equality>() =
    inherit MenuBaseBuilder<'t>()
    