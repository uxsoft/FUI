module FUI.Avalonia.ComboBox

open Avalonia.Controls
open FUI.Avalonia.SelectingItemsControl
open Avalonia.Layout
open Avalonia.Media

type ComboBoxBuilder<'t when 't :> ComboBox and 't : equality>() =
    inherit SelectingItemsControlBuilder<'t>() 
    
    [<CustomOperation("isDropDownOpen")>] 
    member _.isDropDownOpen<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x ComboBox.IsDropDownOpenProperty value
        
    [<CustomOperation("maxDropDownHeight")>] 
    member _.maxDropDownHeight<'t>(x: Types.AvaloniaNode<'t>, height: float) =
        Types.dependencyProperty x ComboBox.MaxDropDownHeightProperty height
    
    [<CustomOperation("selectionBoxItemProperty")>]     
    member _.selectionBoxItemProperty<'t>(x: Types.AvaloniaNode<'t>, value: obj) =
        Types.dependencyProperty x ComboBox.SelectionBoxItemProperty value
    
    [<CustomOperation("virtualizationMode")>] 
    member _.virtualizationMode<'t>(x: Types.AvaloniaNode<'t>, value: ItemVirtualizationMode) =
        Types.dependencyProperty x ComboBox.VirtualizationModeProperty value
    
    [<CustomOperation("placeholderText")>]         
    member _.placeholderText<'t>(x: Types.AvaloniaNode<'t>, value: string) =
        Types.dependencyProperty x ComboBox.PlaceholderTextProperty value
        
    [<CustomOperation("placeholderForeground")>] 
    member _.placeholderForeground<'t>(x: Types.AvaloniaNode<'t>, value: IBrush) =
        Types.dependencyProperty x ComboBox.PlaceholderForegroundProperty value
    
    [<CustomOperation("horizontalContentAlignment")>] 
    member _.horizontalContentAlignment<'t>(x: Types.AvaloniaNode<'t>, alignment: HorizontalAlignment) =
        Types.dependencyProperty x ComboBox.HorizontalContentAlignmentProperty alignment
     
    [<CustomOperation("verticalContentAlignment")>]    
    member _.verticalContentAlignment<'t>(x: Types.AvaloniaNode<'t>, alignment: VerticalAlignment) =
        Types.dependencyProperty x ComboBox.VerticalContentAlignmentProperty alignment