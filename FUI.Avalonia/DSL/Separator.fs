module FUI.Avalonia.Separator

open Avalonia.Controls
open FUI.Avalonia.TemplatedControl

type SeparatorBuilder<'t when 't :> Separator and 't : equality>() =
    inherit TemplatedControlBuilder<'t>()