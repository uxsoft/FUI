module FUI.Avalonia.TabStripItem

open Avalonia.Controls.Primitives
open FUI.Avalonia.ListBoxItem

type TabStripItemBuilder<'t when 't :> TabStripItem and 't : equality>() =
    inherit ListBoxItemBuilder<'t>()