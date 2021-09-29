module FUI.Avalonia.Separator

open Avalonia.Controls
open FUI.Avalonia.TemplatedControl

type SeparatorBuilder<'t when 't :> Separator>() =
    inherit TemplatedControlBuilder<'t>()