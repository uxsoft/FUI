module FUI.Avalonia.TabStrip

open Avalonia.Controls.Primitives
open FUI.Avalonia.SelectingItemsControl

type TabStripBuilder<'t when 't :> TabStrip and 't : equality>() =
    inherit SelectingItemsControlBuilder<'t>()
    