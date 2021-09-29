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
    member _.tabStripPlacement<'t>(x: Node<_, _>, placement: Dock) =
        Types.dependencyProperty<Dock>(TabControl.TabStripPlacementProperty, placement, ValueNone) ]
        
    [<CustomOperation("horizontalContentAlignment")>]
    member _.horizontalContentAlignment<'t>(x: Node<_, _>, alignment: HorizontalAlignment) =
        Types.dependencyProperty<HorizontalAlignment>(TabControl.HorizontalContentAlignmentProperty, alignment, ValueNone) ]
        
    [<CustomOperation("verticalContentAlignment")>]
    member _.verticalContentAlignment<'t>(x: Node<_, _>, alignment: VerticalAlignment) =
        Types.dependencyProperty<VerticalAlignment>(TabControl.VerticalContentAlignmentProperty, alignment, ValueNone) ]
        
    [<CustomOperation("contentTemplate")>]
    member _.contentTemplate<'t>(x: Node<_, _>, value: IDataTemplate) =
        Types.dependencyProperty<IDataTemplate>(TabControl.ContentTemplateProperty, value, ValueNone) ]
        
    [<CustomOperation("selectedContent")>]
    member _.selectedContent<'t>(x: Node<_, _>, value: obj) =
        Types.dependencyProperty<obj>(TabControl.ContentTemplateProperty, value, ValueNone) ]
        
    [<CustomOperation("onSelectedContentChanged")>]
    member _.onSelectedContentChanged<'t>(x: Node<_, _>, func: obj -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<obj>(TabControl.SelectedContentProperty, func) ]
        
    [<CustomOperation("selectedContentTemplate")>]
    member _.selectedContentTemplate<'t>(x: Node<_, _>, value: IDataTemplate) =
        Types.dependencyProperty<IDataTemplate>(TabControl.SelectedContentTemplateProperty, value, ValueNone) ]
        
    [<CustomOperation("onSelectedContentTemplateChanged")>]
    member _.onSelectedContentTemplateChanged<'t>(x: Node<_, _>, func: IDataTemplate -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<IDataTemplate>(TabControl.SelectedContentTemplateProperty, func) ]