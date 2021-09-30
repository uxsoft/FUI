module FUI.Avalonia.Ellipse

open Avalonia.Controls.Shapes
open FUI.Avalonia.Shape

type EllipseBuilder<'t when 't :> Ellipse and 't : equality>() =
    inherit ShapeBuilder<'t>()
   