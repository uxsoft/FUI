module FUI.Avalonia.Canvas

open Avalonia.Controls
open FUI.Avalonia.Panel
   
type CanvasBuilder<'t when 't :> Canvas>() =
    inherit PanelBuilder<'t>()     