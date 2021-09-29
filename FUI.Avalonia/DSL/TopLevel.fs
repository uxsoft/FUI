module FUI.Avalonia.TopLevel

open Avalonia.Controls
open FUI.UiBuilder

type TopLevelBuilder<'t when 't :> TopLevel>() =
    inherit ContentControl.ContentControlBuilder<'t>()

//TODO toplevel builder