module FUI.Avalonia.ComboBox

open Avalonia.Controls
open FUI.Avalonia.SelectingItemsControl
open Avalonia.Layout
open Avalonia.Media

type ComboBoxBuilder<'t when 't :> ComboBox and 't : equality>() =
    inherit SelectingItemsControlBuilder<'t>() 
    
    /// bool | ObservableValue<bool>
    [<CustomOperation("isDropDownOpen")>] 
    member _.isDropDownOpen<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x ComboBox.IsDropDownOpenProperty value
        
    /// float | ObservableValue<float>
    [<CustomOperation("maxDropDownHeight")>] 
    member _.maxDropDownHeight<'t, 'v>(x: Types.AvaloniaNode<'t>, height: 'v) =
        Types.dependencyProperty x ComboBox.MaxDropDownHeightProperty height
    
    /// obj | ObservableValue<obj>
    [<CustomOperation("selectionBoxItemProperty")>]     
    member _.selectionBoxItemProperty<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x ComboBox.SelectionBoxItemProperty value
    
    /// ItemVirtualizationMode | ObservableValue<ItemVirtualizationMode>
    [<CustomOperation("virtualizationMode")>] 
    member _.virtualizationMode<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x ComboBox.VirtualizationModeProperty value
    
    /// string | ObservableValue<string>
    [<CustomOperation("placeholderText")>]         
    member _.placeholderText<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x ComboBox.PlaceholderTextProperty value
        
    /// IBrush | ObservableValue<IBrush>
    [<CustomOperation("placeholderForeground")>] 
    member _.placeholderForeground<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x ComboBox.PlaceholderForegroundProperty value
    
    /// HorizontalAlignment | ObservableValue<HorizontalAlignment>
    [<CustomOperation("horizontalContentAlignment")>] 
    member _.horizontalContentAlignment<'t, 'v>(x: Types.AvaloniaNode<'t>, alignment: 'v) =
        Types.dependencyProperty x ComboBox.HorizontalContentAlignmentProperty alignment
     
    /// VerticalAlignment | ObservableValue<VerticalAlignment>
    [<CustomOperation("verticalContentAlignment")>]    
    member _.verticalContentAlignment<'t, 'v>(x: Types.AvaloniaNode<'t>, alignment: 'v) =
        Types.dependencyProperty x ComboBox.VerticalContentAlignmentProperty alignment