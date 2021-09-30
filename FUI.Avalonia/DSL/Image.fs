module FUI.Avalonia.Image

open Avalonia.Controls
open FUI.Avalonia.Control
open Avalonia.Media
open Avalonia.Media.Imaging

type ImageBuilder<'t when 't :> Image and 't : equality>() =
    inherit ControlBuilder<'t>()
    
    [<CustomOperation("source")>]
    member _.source<'t>(x: Types.AvaloniaNode<'t>, value: IBitmap) =
        Types.dependencyProperty x Image.SourceProperty value
        
    [<CustomOperation("stretch")>]
    member _.stretch<'t>(x: Types.AvaloniaNode<'t>, value: Stretch) =
        Types.dependencyProperty x Image.StretchProperty value