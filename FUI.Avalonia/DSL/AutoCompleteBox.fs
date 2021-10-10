module FUI.Avalonia.AutoCompleteBox

open System
open System.Collections
open FUI.Avalonia.TemplatedControl
open Avalonia.Controls
open Avalonia.Controls.Templates    

type AutoCompleteBoxBuilder<'t when 't :> AutoCompleteBox and 't : equality>() =
    inherit TemplatedControlBuilder<'t>()
    
    [<CustomOperation("onSelectionChanged")>] 
    member _.onSelectionChanged<'t, 'v>(x: Types.AvaloniaNode<'t>, func: SelectionChangedEventArgs -> unit) =
        Types.routedEvent x AutoCompleteBox.SelectionChangedEvent func
    
    /// string | ObservableValue<string>
    [<CustomOperation("watermark")>] 
    member _.watermark<'t, 'v>(x: Types.AvaloniaNode<'t>, watermark: 'v) =
        Types.dependencyProperty x AutoCompleteBox.WatermarkProperty watermark
    
    /// int | ObservableValue<int>
    [<CustomOperation("minimumPrefixLength")>] 
    member _.minimumPrefixLength<'t, 'v>(x: Types.AvaloniaNode<'t>, length: 'v) =
        Types.dependencyProperty x AutoCompleteBox.MinimumPrefixLengthProperty length
        
    /// TimeSpan | ObservableValue<TimeSpan>
    [<CustomOperation("minimumPopulationDelay")>] 
    member _.minimumPopulationDelay<'t, 'v>(x: Types.AvaloniaNode<'t>, delay: 'v) =
        Types.dependencyProperty x AutoCompleteBox.MinimumPopulateDelayProperty delay
        
    /// float | ObservableValue<float>
    [<CustomOperation("maxDropDownHeight")>] 
    member _.maxDropDownHeight<'t, 'v>(x: Types.AvaloniaNode<'t>, height: 'v) =
        Types.dependencyProperty x AutoCompleteBox.MaxDropDownHeightProperty height
        
    /// bool | ObservableValue<bool>
    [<CustomOperation("isTextCompletionEnabled")>] 
    member _.isTextCompletionEnabled<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x AutoCompleteBox.IsTextCompletionEnabledProperty value
        
    /// IDataTemplate | ObservableValue<IDataTemplate>
    [<CustomOperation("itemTemplate")>] 
    member _.itemTemplate<'t, 'v>(x: Types.AvaloniaNode<'t>, template: 'v) =
        Types.dependencyProperty x AutoCompleteBox.ItemTemplateProperty template
        
    /// bool | ObservableValue<bool>
    [<CustomOperation("isDropDownOpen")>] 
    member _.isDropDownOpen<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x AutoCompleteBox.IsDropDownOpenProperty value
        
    /// obj | ObservableValue<obj>
    [<CustomOperation("selectedItem")>] 
    member _.selectedItem<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x AutoCompleteBox.SelectedItemProperty value
        
    [<CustomOperation("onSelectedItemChanged")>] 
    member _.onSelectedItemChanged<'t, 'v>(x: Types.AvaloniaNode<'t>, func: obj -> unit) =
        Types.dependencyPropertyEvent x AutoCompleteBox.SelectedItemProperty func

    /// string | ObservableValue<string>
    [<CustomOperation("text")>] 
    member _.text<'t, 'v>(x: Types.AvaloniaNode<'t>, text: 'v) =
        Types.dependencyProperty x AutoCompleteBox.TextProperty text
        
    [<CustomOperation("onTextChanged")>] 
    member _.onTextChanged<'t, 'v>(x: Types.AvaloniaNode<'t>, func: string -> unit) =
        Types.dependencyPropertyEvent x AutoCompleteBox.TextProperty func
        
    /// string | ObservableValue<string>
    [<CustomOperation("searchText")>] 
    member _.searchText<'t, 'v>(x: Types.AvaloniaNode<'t>, text: 'v) =
        Types.dependencyProperty x AutoCompleteBox.SearchTextProperty text
        
    [<CustomOperation("onSearchTextChanged")>] 
    member _.onSearchTextChanged<'t, 'v>(x: Types.AvaloniaNode<'t>, func: string -> unit) =
        Types.dependencyPropertyEvent x AutoCompleteBox.SearchTextProperty func
        
    /// AutoCompleteFilterMode | ObservableValue<AutoCompleteFilterMode>
    [<CustomOperation("filterMode")>] 
    member _.filterMode<'t, 'v>(x: Types.AvaloniaNode<'t>, mode: 'v) =
        Types.dependencyProperty x AutoCompleteBox.FilterModeProperty mode
        
    [<CustomOperation("itemFilter")>] 
    member _.itemFilter<'t, 'v>(x: Types.AvaloniaNode<'t>, filterFunc: string * obj -> bool) =
        Types.dependencyProperty x AutoCompleteBox.ItemFilterProperty filterFunc
        
    /// string | ObservableValue<string>
    [<CustomOperation("textFilter")>] 
    member _.textFilter<'t, 'v>(x: Types.AvaloniaNode<'t>, filter: 'v) =
        Types.dependencyProperty x AutoCompleteBox.TextFilterProperty filter
        
    /// IEnumerable | ObservableValue<IEnumerable>
    [<CustomOperation("items")>] 
    member _.items<'t, 'v>(x: Types.AvaloniaNode<'t>, items: 'v) =
        Types.dependencyProperty x AutoCompleteBox.ItemsProperty items