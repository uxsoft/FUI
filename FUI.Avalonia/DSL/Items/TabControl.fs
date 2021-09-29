module FUI.Avalonia.TabControl

open Avalonia.Controls
open Avalonia.Controls.Templates
open FUI.UiBuilder
open FUI.Avalonia.SelectingItemsControl
open Avalonia.Layout
open Avalonia.FuncUI.Builder
 
type TabControlBuilder<'t when 't :> TabControl>() =
    inherit SelectingItemsControlBuilder<'t>()

    [<CustomOperation("tabStripPlacement")>]
    member _.tabStripPlacement<'t>(x: Types.AvaloniaNode<'t>, placement: Dock) =
        Types.dependencyProperty x<Dock>(TabControl.TabStripPlacementProperty, placement, ValueNone) ]
        
    [<CustomOperation("horizontalContentAlignment")>]
    member _.horizontalContentAlignment<'t>(x: Types.AvaloniaNode<'t>, alignment: HorizontalAlignment) =
        Types.dependencyProperty x<HorizontalAlignment>(TabControl.HorizontalContentAlignmentProperty, alignment, ValueNone) ]
        
    [<CustomOperation("verticalContentAlignment")>]
    member _.verticalContentAlignment<'t>(x: Types.AvaloniaNode<'t>, alignment: VerticalAlignment) =
        Types.dependencyProperty x<VerticalAlignment>(TabControl.VerticalContentAlignmentProperty, alignment, ValueNone) ]
        
    [<CustomOperation("contentTemplate")>]
    member _.contentTemplate<'t>(x: Types.AvaloniaNode<'t>, value: IDataTemplate) =
        Types.dependencyProperty x<IDataTemplate>(TabControl.ContentTemplateProperty, value, ValueNone) ]
        
    [<CustomOperation("selectedContent")>]
    member _.selectedContent<'t>(x: Types.AvaloniaNode<'t>, value: obj) =
        Types.dependencyProperty x<obj>(TabControl.ContentTemplateProperty, value, ValueNone) ]
        
    [<CustomOperation("onSelectedContentChanged")>]
    member _.onSelectedContentChanged<'t>(x: Types.AvaloniaNode<'t>, func: obj -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<obj>(TabControl.SelectedContentProperty, func) ]
        
    [<CustomOperation("selectedContentTemplate")>]
    member _.selectedContentTemplate<'t>(x: Types.AvaloniaNode<'t>, value: IDataTemplate) =
        Types.dependencyProperty x<IDataTemplate>(TabControl.SelectedContentTemplateProperty, value, ValueNone) ]
        
    [<CustomOperation("onSelectedContentTemplateChanged")>]
    member _.onSelectedContentTemplateChanged<'t>(x: Types.AvaloniaNode<'t>, func: IDataTemplate -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<IDataTemplate>(TabControl.SelectedContentTemplateProperty, func) ]