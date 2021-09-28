module Avalonia.FuncUI.Experiments.DSL.Image

open Avalonia.Controls
open Avalonia.FuncUI.Builder
open FUI.UiBuilder
open Avalonia.FuncUI.Experiments.DSL.Control
open Avalonia.Media
open Avalonia.Media.Imaging

type ImageBuilder<'t when 't :> Image>() =
    inherit ControlBuilder<'t>()
    
    [<CustomOperation("source")>]
    member _.source<'t>(x: Node<_, _>, value: IBitmap) =
        Types.dependencyProperty<IBitmap>(Image.SourceProperty, value, ValueNone) ]
        
    [<CustomOperation("stretch")>]
    member _.stretch<'t>(x: Node<_, _>, value: Stretch) =
        Types.dependencyProperty<Stretch>(Image.StretchProperty, value, ValueNone) ]