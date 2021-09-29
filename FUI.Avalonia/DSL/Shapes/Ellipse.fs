module FUI.Avalonia.Ellipse

open Avalonia.Controls.Shapes
open FUI.Avalonia.Shape

type EllipseBuilder<'t when 't :> Ellipse>() =
    inherit ShapeBuilder<'t>()
   