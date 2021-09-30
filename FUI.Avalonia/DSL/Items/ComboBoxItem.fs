module FUI.Avalonia.ComboBoxItem

open Avalonia.Controls
open FUI.Avalonia.ListBoxItem

type ComboBoxItemBuilder<'t when 't :> ComboBoxItem and 't : equality>() =
    inherit ListBoxItemBuilder<'t>()