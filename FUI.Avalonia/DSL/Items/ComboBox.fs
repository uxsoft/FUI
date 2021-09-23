module Avalonia.FuncUI.Experiments.DSL.ComboBox

open Avalonia.Controls
open FUI.UIBuilder
open Avalonia.FuncUI.Experiments.DSL.SelectingItemsControl
open Avalonia.Layout
open Avalonia.FuncUI.Builder
open Avalonia.Media

type ComboBoxBuilder<'t when 't :> ComboBox>() =
    inherit SelectingItemsControlBuilder<'t>() 
    
    [<CustomOperation("isDropDownOpen")>] 
    member _.isDropDownOpen<'t>(x: Element, value: bool) =
        x @@ [ AttrBuilder<'t>.CreateProperty<bool>(ComboBox.IsDropDownOpenProperty, value, ValueNone) ]
        
    [<CustomOperation("maxDropDownHeight")>] 
    member _.maxDropDownHeight<'t>(x: Element, height: float) =
        x @@ [ AttrBuilder<'t>.CreateProperty<float>(ComboBox.MaxDropDownHeightProperty, height, ValueNone) ]
    
    [<CustomOperation("selectionBoxItemProperty")>]     
    member _.selectionBoxItemProperty<'t>(x: Element, value: obj) =
        x @@ [ AttrBuilder<'t>.CreateProperty<obj>(ComboBox.SelectionBoxItemProperty, value, ValueNone) ]
    
    [<CustomOperation("virtualizationMode")>] 
    member _.virtualizationMode<'t>(x: Element, value: ItemVirtualizationMode) =
        x @@ [ AttrBuilder<'t>.CreateProperty<ItemVirtualizationMode>(ComboBox.VirtualizationModeProperty, value, ValueNone) ]
    
    [<CustomOperation("placeholderText")>]         
    member _.placeholderText<'t>(x: Element, value: string) =
        x @@ [ AttrBuilder<'t>.CreateProperty<string>(ComboBox.PlaceholderTextProperty, value, ValueNone) ]
        
    [<CustomOperation("placeholderForeground")>] 
    member _.placeholderForeground<'t>(x: Element, value: IBrush) =
        x @@ [ AttrBuilder<'t>.CreateProperty<IBrush>(ComboBox.PlaceholderForegroundProperty, value, ValueNone) ]
    
    [<CustomOperation("horizontalContentAlignment")>] 
    member _.horizontalContentAlignment<'t>(x: Element, alignment: HorizontalAlignment) =
        x @@ [ AttrBuilder<'t>.CreateProperty<HorizontalAlignment>(ComboBox.HorizontalContentAlignmentProperty, alignment, ValueNone) ]
     
    [<CustomOperation("verticalContentAlignment")>]    
    member _.verticalContentAlignment<'t>(x: Element, alignment: VerticalAlignment) =
        x @@ [ AttrBuilder<'t>.CreateProperty<VerticalAlignment>(ComboBox.VerticalContentAlignmentProperty, alignment, ValueNone) ]