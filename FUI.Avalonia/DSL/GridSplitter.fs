module FUI.Avalonia.GridSplitter

open Avalonia.Controls
open FUI.Avalonia.Thumb
 
type GridSplitterBuilder<'t when 't :> GridSplitter and 't : equality>() =
    inherit ThumbBuilder<'t>()