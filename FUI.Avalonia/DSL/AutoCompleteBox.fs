module FUI.Avalonia.AutoCompleteBox

open System
open System.Collections
open FUI.Avalonia.TemplatedControl
open Avalonia.Controls
open Avalonia.Controls.Templates    

type AutoCompleteBoxBuilder<'t when 't :> AutoCompleteBox and 't : equality>() =
    inherit TemplatedControlBuilder<'t>()
    
    [<CustomOperation("onSelectionChanged")>] 
    member _.onSelectionChanged<'t>(x: Types.AvaloniaNode<'t>, func: SelectionChangedEventArgs -> unit) =
        Types.routedEvent x AutoCompleteBox.SelectionChangedEvent func
    
    [<CustomOperation("watermark")>] 
    member _.watermark<'t>(x: Types.AvaloniaNode<'t>, watermark: string) =
        Types.dependencyProperty x AutoCompleteBox.WatermarkProperty watermark
        
    [<CustomOperation("minimumPrefixLength")>] 
    member _.minimumPrefixLength<'t>(x: Types.AvaloniaNode<'t>, length: int) =
        Types.dependencyProperty x AutoCompleteBox.MinimumPrefixLengthProperty length
        
    [<CustomOperation("minimumPopulationDelay")>] 
    member _.minimumPopulationDelay<'t>(x: Types.AvaloniaNode<'t>, delay: TimeSpan) =
        Types.dependencyProperty x AutoCompleteBox.MinimumPopulateDelayProperty delay
        
    [<CustomOperation("maxDropDownHeight")>] 
    member _.maxDropDownHeight<'t>(x: Types.AvaloniaNode<'t>, height: float) =
        Types.dependencyProperty x AutoCompleteBox.MaxDropDownHeightProperty height
        
    [<CustomOperation("isTextCompletionEnabled")>] 
    member _.isTextCompletionEnabled<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x AutoCompleteBox.IsTextCompletionEnabledProperty value
        
    [<CustomOperation("itemTemplate")>] 
    member _.itemTemplate<'t>(x: Types.AvaloniaNode<'t>, template: IDataTemplate) =
        Types.dependencyProperty x AutoCompleteBox.ItemTemplateProperty template
        
    [<CustomOperation("isDropDownOpen")>] 
    member _.isDropDownOpen<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x AutoCompleteBox.IsDropDownOpenProperty value
        
    [<CustomOperation("selectedItem")>] 
    member _.selectedItem<'t>(x: Types.AvaloniaNode<'t>, value: obj) =
        Types.dependencyProperty x AutoCompleteBox.SelectedItemProperty value
        
    [<CustomOperation("onSelectedItemChanged")>] 
    member _.onSelectedItemChanged<'t>(x: Types.AvaloniaNode<'t>, func: obj -> unit) =
        Types.dependencyPropertyEvent x AutoCompleteBox.SelectedItemProperty func

    [<CustomOperation("text")>] 
    member _.text<'t>(x: Types.AvaloniaNode<'t>, text: string) =
        Types.dependencyProperty x AutoCompleteBox.TextProperty text
        
    [<CustomOperation("onTextChanged")>] 
    member _.onTextChanged<'t>(x: Types.AvaloniaNode<'t>, func: string -> unit) =
        Types.dependencyPropertyEvent x AutoCompleteBox.TextProperty func
        
    [<CustomOperation("searchText")>] 
    member _.searchText<'t>(x: Types.AvaloniaNode<'t>, text: string) =
        Types.dependencyProperty x AutoCompleteBox.SearchTextProperty text
        
    [<CustomOperation("onSearchTextChanged")>] 
    member _.onSearchTextChanged<'t>(x: Types.AvaloniaNode<'t>, func: string -> unit) =
        Types.dependencyPropertyEvent x AutoCompleteBox.SearchTextProperty func
        
    [<CustomOperation("filterMode")>] 
    member _.filterMode<'t>(x: Types.AvaloniaNode<'t>, mode: AutoCompleteFilterMode) =
        Types.dependencyProperty x AutoCompleteBox.FilterModeProperty mode
        
    [<CustomOperation("itemFilter")>] 
    member _.itemFilter<'t>(x: Types.AvaloniaNode<'t>, filterFunc: string * obj -> bool) =
        // TODO: implement custom comparer (value is a function)
        Types.dependencyProperty x AutoCompleteBox.ItemFilterProperty filterFunc
        
    [<CustomOperation("textFilter")>] 
    member _.textFilter<'t>(x: Types.AvaloniaNode<'t>, filter: string) =
        Types.dependencyProperty x AutoCompleteBox.TextFilterProperty filter
        
    [<CustomOperation("items")>] 
    member _.items<'t>(x: Types.AvaloniaNode<'t>, items: IEnumerable) =
        Types.dependencyProperty x AutoCompleteBox.ItemsProperty items