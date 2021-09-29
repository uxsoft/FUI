module FUI.Avalonia.AccessText

open Avalonia.Controls.Primitives
open FUI.Avalonia.TextBlock

type AccessTextBuilder<'t when 't :> AccessText>() =
    inherit TextBlockBuilder<'t>()

