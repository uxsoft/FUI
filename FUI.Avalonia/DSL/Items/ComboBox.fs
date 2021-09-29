module FUI.Avalonia.ComboBox

open Avalonia.Controls
open FUI.UiBuilder
open FUI.Avalonia.SelectingItemsControl
open Avalonia.Layout
open Avalonia.FuncUI.Builder
open Avalonia.Media

type ComboBoxBuilder<'t when 't :> ComboBox>() =
    inherit SelectingItemsControlBuilder<'t>() 
    
    [<CustomOperation("isDropDownOpen")>] 
    member _.isDropDownOpen<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x<bool>(ComboBox.IsDropDownOpenProperty, value, ValueNone) ]
        
    [<CustomOperation("maxDropDownHeight")>] 
    member _.maxDropDownHeight<'t>(x: Types.AvaloniaNode<'t>, height: float) =
        Types.dependencyProperty x<float>(ComboBox.MaxDropDownHeightProperty, height, ValueNone) ]
    
    [<CustomOperation("selectionBoxItemProperty")>]     
    member _.selectionBoxItemProperty<'t>(x: Types.AvaloniaNode<'t>, value: obj) =
        Types.dependencyProperty x<obj>(ComboBox.SelectionBoxItemProperty, value, ValueNone) ]
    
    [<CustomOperation("virtualizationMode")>] 
    member _.virtualizationMode<'t>(x: Types.AvaloniaNode<'t>, value: ItemVirtualizationMode) =
        Types.dependencyProperty x<ItemVirtualizationMode>(ComboBox.VirtualizationModeProperty, value, ValueNone) ]
    
    [<CustomOperation("placeholderText")>]         
    member _.placeholderText<'t>(x: Types.AvaloniaNode<'t>, value: string) =
        Types.dependencyProperty x<string>(ComboBox.PlaceholderTextProperty, value, ValueNone) ]
        
    [<CustomOperation("placeholderForeground")>] 
    member _.placeholderForeground<'t>(x: Types.AvaloniaNode<'t>, value: IBrush) =
        Types.dependencyProperty x<IBrush>(ComboBox.PlaceholderForegroundProperty, value, ValueNone) ]
    
    [<CustomOperation("horizontalContentAlignment")>] 
    member _.horizontalContentAlignment<'t>(x: Types.AvaloniaNode<'t>, alignment: HorizontalAlignment) =
        Types.dependencyProperty x<HorizontalAlignment>(ComboBox.HorizontalContentAlignmentProperty, alignment, ValueNone) ]
     
    [<CustomOperation("verticalContentAlignment")>]    
    member _.verticalContentAlignment<'t>(x: Types.AvaloniaNode<'t>, alignment: VerticalAlignment) =
        Types.dependencyProperty x<VerticalAlignment>(ComboBox.VerticalContentAlignmentProperty, alignment, ValueNone) ]