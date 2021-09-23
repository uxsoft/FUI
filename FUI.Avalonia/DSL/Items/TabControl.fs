module Avalonia.FuncUI.Experiments.DSL.TabControl

open Avalonia.Controls
open Avalonia.Controls.Templates
open FUI.UIBuilder
open Avalonia.FuncUI.Experiments.DSL.SelectingItemsControl
open Avalonia.Layout
open Avalonia.FuncUI.Builder
 
type TabControlBuilder<'t when 't :> TabControl>() =
    inherit SelectingItemsControlBuilder<'t>()

    [<CustomOperation("tabStripPlacement")>]
    member _.tabStripPlacement<'t>(x: Element, placement: Dock) =
        x @@ [ AttrBuilder<'t>.CreateProperty<Dock>(TabControl.TabStripPlacementProperty, placement, ValueNone) ]
        
    [<CustomOperation("horizontalContentAlignment")>]
    member _.horizontalContentAlignment<'t>(x: Element, alignment: HorizontalAlignment) =
        x @@ [ AttrBuilder<'t>.CreateProperty<HorizontalAlignment>(TabControl.HorizontalContentAlignmentProperty, alignment, ValueNone) ]
        
    [<CustomOperation("verticalContentAlignment")>]
    member _.verticalContentAlignment<'t>(x: Element, alignment: VerticalAlignment) =
        x @@ [ AttrBuilder<'t>.CreateProperty<VerticalAlignment>(TabControl.VerticalContentAlignmentProperty, alignment, ValueNone) ]
        
    [<CustomOperation("contentTemplate")>]
    member _.contentTemplate<'t>(x: Element, value: IDataTemplate) =
        x @@ [ AttrBuilder<'t>.CreateProperty<IDataTemplate>(TabControl.ContentTemplateProperty, value, ValueNone) ]
        
    [<CustomOperation("selectedContent")>]
    member _.selectedContent<'t>(x: Element, value: obj) =
        x @@ [ AttrBuilder<'t>.CreateProperty<obj>(TabControl.ContentTemplateProperty, value, ValueNone) ]
        
    [<CustomOperation("onSelectedContentChanged")>]
    member _.onSelectedContentChanged<'t>(x: Element, func: obj -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<obj>(TabControl.SelectedContentProperty, func) ]
        
    [<CustomOperation("selectedContentTemplate")>]
    member _.selectedContentTemplate<'t>(x: Element, value: IDataTemplate) =
        x @@ [ AttrBuilder<'t>.CreateProperty<IDataTemplate>(TabControl.SelectedContentTemplateProperty, value, ValueNone) ]
        
    [<CustomOperation("onSelectedContentTemplateChanged")>]
    member _.onSelectedContentTemplateChanged<'t>(x: Element, func: IDataTemplate -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<IDataTemplate>(TabControl.SelectedContentTemplateProperty, func) ]