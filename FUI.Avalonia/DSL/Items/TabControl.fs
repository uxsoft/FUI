module FUI.Avalonia.TabControl

open Avalonia.Controls
open Avalonia.Controls.Templates
open FUI.Avalonia.SelectingItemsControl
open Avalonia.Layout
 
type TabControlBuilder<'t when 't :> TabControl and 't : equality>() =
    inherit SelectingItemsControlBuilder<'t>()

    [<CustomOperation("tabStripPlacement")>]
    member _.tabStripPlacement<'t>(x: Types.AvaloniaNode<'t>, placement: Dock) =
        Types.dependencyProperty x TabControl.TabStripPlacementProperty placement
        
    [<CustomOperation("horizontalContentAlignment")>]
    member _.horizontalContentAlignment<'t>(x: Types.AvaloniaNode<'t>, alignment: HorizontalAlignment) =
        Types.dependencyProperty x TabControl.HorizontalContentAlignmentProperty alignment
        
    [<CustomOperation("verticalContentAlignment")>]
    member _.verticalContentAlignment<'t>(x: Types.AvaloniaNode<'t>, alignment: VerticalAlignment) =
        Types.dependencyProperty x TabControl.VerticalContentAlignmentProperty alignment
        
    [<CustomOperation("contentTemplate")>]
    member _.contentTemplate<'t>(x: Types.AvaloniaNode<'t>, value: IDataTemplate) =
        Types.dependencyProperty x TabControl.ContentTemplateProperty value
        
    [<CustomOperation("selectedContent")>]
    member _.selectedContent<'t>(x: Types.AvaloniaNode<'t>, value: obj) =
        Types.dependencyProperty x TabControl.ContentTemplateProperty value
        
    [<CustomOperation("onSelectedContentChanged")>]
    member _.onSelectedContentChanged<'t>(x: Types.AvaloniaNode<'t>, func: obj -> unit) =
        Types.dependencyPropertyEvent x TabControl.SelectedContentProperty func
        
    [<CustomOperation("selectedContentTemplate")>]
    member _.selectedContentTemplate<'t>(x: Types.AvaloniaNode<'t>, value: IDataTemplate) =
        Types.dependencyProperty x TabControl.SelectedContentTemplateProperty value
        
    [<CustomOperation("onSelectedContentTemplateChanged")>]
    member _.onSelectedContentTemplateChanged<'t>(x: Types.AvaloniaNode<'t>, func: IDataTemplate -> unit) =
        Types.dependencyPropertyEvent x TabControl.SelectedContentTemplateProperty func