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
    member _.isDropDownOpen<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(ComboBox.IsDropDownOpenProperty, value, ValueNone) ]
        
    [<CustomOperation("maxDropDownHeight")>] 
    member _.maxDropDownHeight<'t>(x: Node<_, _>, height: float) =
        Types.dependencyProperty<float>(ComboBox.MaxDropDownHeightProperty, height, ValueNone) ]
    
    [<CustomOperation("selectionBoxItemProperty")>]     
    member _.selectionBoxItemProperty<'t>(x: Node<_, _>, value: obj) =
        Types.dependencyProperty<obj>(ComboBox.SelectionBoxItemProperty, value, ValueNone) ]
    
    [<CustomOperation("virtualizationMode")>] 
    member _.virtualizationMode<'t>(x: Node<_, _>, value: ItemVirtualizationMode) =
        Types.dependencyProperty<ItemVirtualizationMode>(ComboBox.VirtualizationModeProperty, value, ValueNone) ]
    
    [<CustomOperation("placeholderText")>]         
    member _.placeholderText<'t>(x: Node<_, _>, value: string) =
        Types.dependencyProperty<string>(ComboBox.PlaceholderTextProperty, value, ValueNone) ]
        
    [<CustomOperation("placeholderForeground")>] 
    member _.placeholderForeground<'t>(x: Node<_, _>, value: IBrush) =
        Types.dependencyProperty<IBrush>(ComboBox.PlaceholderForegroundProperty, value, ValueNone) ]
    
    [<CustomOperation("horizontalContentAlignment")>] 
    member _.horizontalContentAlignment<'t>(x: Node<_, _>, alignment: HorizontalAlignment) =
        Types.dependencyProperty<HorizontalAlignment>(ComboBox.HorizontalContentAlignmentProperty, alignment, ValueNone) ]
     
    [<CustomOperation("verticalContentAlignment")>]    
    member _.verticalContentAlignment<'t>(x: Node<_, _>, alignment: VerticalAlignment) =
        Types.dependencyProperty<VerticalAlignment>(ComboBox.VerticalContentAlignmentProperty, alignment, ValueNone) ]