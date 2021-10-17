module FUI.Avalonia.TabControl

open Avalonia.Controls
open Avalonia.Controls.Templates
open FUI.Avalonia.SelectingItemsControl
open Avalonia.Layout
 
type TabControlBuilder<'t when 't :> TabControl and 't : equality>() =
    inherit SelectingItemsControlBuilder<'t>()

    /// Dock | ObservableValue<Dock>
    [<CustomOperation("tabStripPlacement")>]
    member _.tabStripPlacement<'t, 'v>(x, placement: 'v) =
        Types.dependencyProperty x TabControl.TabStripPlacementProperty placement
        
    /// HorizontalAlignment | ObservableValue<HorizontalAlignment>
    [<CustomOperation("horizontalContentAlignment")>]
    member _.horizontalContentAlignment<'t, 'v>(x, alignment: 'v) =
        Types.dependencyProperty x TabControl.HorizontalContentAlignmentProperty alignment
        
    /// VerticalAlignment | ObservableValue<VerticalAlignment>
    [<CustomOperation("verticalContentAlignment")>]
    member _.verticalContentAlignment<'t, 'v>(x, alignment: 'v) =
        Types.dependencyProperty x TabControl.VerticalContentAlignmentProperty alignment
        
    /// IDataTemplate | ObservableValue<IDataTemplate>
    [<CustomOperation("contentTemplate")>]
    member _.contentTemplate<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TabControl.ContentTemplateProperty value
        
    /// obj | ObservableValue<obj>
    [<CustomOperation("selectedContent")>]
    member _.selectedContent<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TabControl.ContentTemplateProperty value
        
    [<CustomOperation("onSelectedContentChanged")>]
    member _.onSelectedContentChanged<'t, 'v>(x, func: obj -> unit) =
        Types.dependencyPropertyEvent x TabControl.SelectedContentProperty func
        
    /// IDataTemplate | ObservableValue<IDataTemplate>
    [<CustomOperation("selectedContentTemplate")>]
    member _.selectedContentTemplate<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TabControl.SelectedContentTemplateProperty value
        
    [<CustomOperation("onSelectedContentTemplateChanged")>]
    member _.onSelectedContentTemplateChanged<'t, 'v>(x, func: IDataTemplate -> unit) =
        Types.dependencyPropertyEvent x TabControl.SelectedContentTemplateProperty func