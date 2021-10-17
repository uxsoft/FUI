module FUI.Avalonia.Image

open Avalonia.Controls
open FUI.Avalonia.Control
open Avalonia.Media
open Avalonia.Media.Imaging

type ImageBuilder<'t when 't :> Image and 't : equality>() =
    inherit ControlBuilder<'t>()
    
    /// IBitmap | ObservableValue<IBitmap>
    [<CustomOperation("source")>]
    member _.source<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Image.SourceProperty value
        
    /// Stretch | ObservableValue<Stretch>
    [<CustomOperation("stretch")>]
    member _.stretch<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Image.StretchProperty value