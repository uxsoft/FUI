module FUI.Avalonia.TabStripItem

open Avalonia.Controls.Primitives
open FUI.Avalonia.ListBoxItem

type TabStripItemBuilder<'t when 't :> TabStripItem>() =
    inherit ListBoxItemBuilder<'t>()