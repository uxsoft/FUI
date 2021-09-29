module FUI.Avalonia.Image

open Avalonia.Controls
open Avalonia.FuncUI.Builder
open FUI.UiBuilder
open FUI.Avalonia.Control
open Avalonia.Media
open Avalonia.Media.Imaging

type ImageBuilder<'t when 't :> Image>() =
    inherit ControlBuilder<'t>()
    
    [<CustomOperation("source")>]
    member _.source<'t>(x: Types.AvaloniaNode<'t>, value: IBitmap) =
        Types.dependencyProperty x<IBitmap>(Image.SourceProperty, value, ValueNone) ]
        
    [<CustomOperation("stretch")>]
    member _.stretch<'t>(x: Types.AvaloniaNode<'t>, value: Stretch) =
        Types.dependencyProperty x<Stretch>(Image.StretchProperty, value, ValueNone) ]