module FUI.Avalonia.AutoCompleteBox

open System
open System.Collections
open FUI.UiBuilder
open FUI.Avalonia.TemplatedControl
open Avalonia.Controls
open Avalonia.Controls.Templates    
open Avalonia.FuncUI.Types
open Avalonia.FuncUI.Builder

type AutoCompleteBoxBuilder<'t when 't :> AutoCompleteBox>() =
    inherit TemplatedControlBuilder<'t>()
    
    [<CustomOperation("onSelectionChanged")>] 
    member _.onSelectionChanged<'t>(x: Node<_, _>, func: SelectionChangedEventArgs -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<_>(AutoCompleteBox.SelectionChangedEvent, func) ]
    
    [<CustomOperation("watermark")>] 
    member _.watermark<'t>(x: Node<_, _>, watermark: string) =
        Types.dependencyProperty<string>(AutoCompleteBox.WatermarkProperty, watermark, ValueNone) ]
        
    [<CustomOperation("minimumPrefixLength")>] 
    member _.minimumPrefixLength<'t>(x: Node<_, _>, length: int) =
        Types.dependencyProperty<int>(AutoCompleteBox.MinimumPrefixLengthProperty, length, ValueNone) ]
        
    [<CustomOperation("minimumPopulationDelay")>] 
    member _.minimumPopulationDelay<'t>(x: Node<_, _>, delay: TimeSpan) =
        Types.dependencyProperty<TimeSpan>(AutoCompleteBox.MinimumPopulateDelayProperty, delay, ValueNone) ]
        
    [<CustomOperation("maxDropDownHeight")>] 
    member _.maxDropDownHeight<'t>(x: Node<_, _>, height: float) =
        Types.dependencyProperty<float>(AutoCompleteBox.MaxDropDownHeightProperty, height, ValueNone) ]
        
    [<CustomOperation("isTextCompletionEnabled")>] 
    member _.isTextCompletionEnabled<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(AutoCompleteBox.IsTextCompletionEnabledProperty, value, ValueNone) ]
        
    [<CustomOperation("itemTemplate")>] 
    member _.itemTemplate<'t>(x: Node<_, _>, template: IDataTemplate) =
        Types.dependencyProperty<IDataTemplate>(AutoCompleteBox.ItemTemplateProperty, template, ValueNone) ]
        
    [<CustomOperation("isDropDownOpen")>] 
    member _.isDropDownOpen<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(AutoCompleteBox.IsDropDownOpenProperty, value, ValueNone) ]
        
    [<CustomOperation("selectedItem")>] 
    member _.selectedItem<'t>(x: Node<_, _>, value: obj) =
        Types.dependencyProperty<obj>(AutoCompleteBox.SelectedItemProperty, value, ValueNone) ]
        
    [<CustomOperation("onSelectedItemChanged")>] 
    member _.onSelectedItemChanged<'t>(x: Node<_, _>, func: obj -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<obj>(AutoCompleteBox.SelectedItemProperty, func) ]

    [<CustomOperation("text")>] 
    member _.text<'t>(x: Node<_, _>, text: string) =
        Types.dependencyProperty<string>(AutoCompleteBox.TextProperty, text, ValueNone) ]
        
    [<CustomOperation("onTextChanged")>] 
    member _.onTextChanged<'t>(x: Node<_, _>, func: string -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<string>(AutoCompleteBox.TextProperty, func) ]
        
    [<CustomOperation("searchText")>] 
    member _.searchText<'t>(x: Node<_, _>, text: string) =
        Types.dependencyProperty<string>(AutoCompleteBox.SearchTextProperty, text, ValueNone) ]
        
    [<CustomOperation("onSearchTextChanged")>] 
    member _.onSearchTextChanged<'t>(x: Node<_, _>, func: string -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<string>(AutoCompleteBox.SearchTextProperty, func) ]
        
    [<CustomOperation("filterMode")>] 
    member _.filterMode<'t>(x: Node<_, _>, mode: AutoCompleteFilterMode) =
        Types.dependencyProperty<AutoCompleteFilterMode>(AutoCompleteBox.FilterModeProperty, mode, ValueNone) ]
        
    [<CustomOperation("itemFilter")>] 
    member _.itemFilter<'t>(x: Node<_, _>, filterFunc: string * obj -> bool) =
        // TODO: implement custom comparer (value is a function)
        Types.dependencyProperty<_>(AutoCompleteBox.ItemFilterProperty, filterFunc, ValueNone) ]
        
    [<CustomOperation("textFilter")>] 
    member _.textFilter<'t>(x: Node<_, _>, filter: string) =
        Types.dependencyProperty<string>(AutoCompleteBox.TextFilterProperty, filter, ValueNone) ]
        
    [<CustomOperation("dataItems")>] 
    member _.dataItems<'t>(x: Node<_, _>, items: IEnumerable) =
        Types.dependencyProperty<IEnumerable>(AutoCompleteBox.ItemsProperty, items, ValueNone) ]
        
    [<CustomOperation("viewItems")>] 
    member _.viewItems<'t>(x: Node<_, _>, views: IView list) =
        x @@ [ AttrBuilder<'t>.CreateContentMultiple(AutoCompleteBox.ItemsProperty, views) ]