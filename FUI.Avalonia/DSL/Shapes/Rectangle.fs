module FUI.Avalonia.Rectangle

open Avalonia.Controls.Shapes
open FUI.Avalonia.Shape

type RectangleBuilder<'t when 't :> Rectangle>() =
    inherit ShapeBuilder<'t>()