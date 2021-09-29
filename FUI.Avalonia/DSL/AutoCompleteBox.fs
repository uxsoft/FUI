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
    member _.onSelectionChanged<'t>(x: Types.AvaloniaNode<'t>, func: SelectionChangedEventArgs -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<_>(AutoCompleteBox.SelectionChangedEvent, func) ]
    
    [<CustomOperation("watermark")>] 
    member _.watermark<'t>(x: Types.AvaloniaNode<'t>, watermark: string) =
        Types.dependencyProperty x<string>(AutoCompleteBox.WatermarkProperty, watermark, ValueNone) ]
        
    [<CustomOperation("minimumPrefixLength")>] 
    member _.minimumPrefixLength<'t>(x: Types.AvaloniaNode<'t>, length: int) =
        Types.dependencyProperty x<int>(AutoCompleteBox.MinimumPrefixLengthProperty, length, ValueNone) ]
        
    [<CustomOperation("minimumPopulationDelay")>] 
    member _.minimumPopulationDelay<'t>(x: Types.AvaloniaNode<'t>, delay: TimeSpan) =
        Types.dependencyProperty x<TimeSpan>(AutoCompleteBox.MinimumPopulateDelayProperty, delay, ValueNone) ]
        
    [<CustomOperation("maxDropDownHeight")>] 
    member _.maxDropDownHeight<'t>(x: Types.AvaloniaNode<'t>, height: float) =
        Types.dependencyProperty x<float>(AutoCompleteBox.MaxDropDownHeightProperty, height, ValueNone) ]
        
    [<CustomOperation("isTextCompletionEnabled")>] 
    member _.isTextCompletionEnabled<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x<bool>(AutoCompleteBox.IsTextCompletionEnabledProperty, value, ValueNone) ]
        
    [<CustomOperation("itemTemplate")>] 
    member _.itemTemplate<'t>(x: Types.AvaloniaNode<'t>, template: IDataTemplate) =
        Types.dependencyProperty x<IDataTemplate>(AutoCompleteBox.ItemTemplateProperty, template, ValueNone) ]
        
    [<CustomOperation("isDropDownOpen")>] 
    member _.isDropDownOpen<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x<bool>(AutoCompleteBox.IsDropDownOpenProperty, value, ValueNone) ]
        
    [<CustomOperation("selectedItem")>] 
    member _.selectedItem<'t>(x: Types.AvaloniaNode<'t>, value: obj) =
        Types.dependencyProperty x<obj>(AutoCompleteBox.SelectedItemProperty, value, ValueNone) ]
        
    [<CustomOperation("onSelectedItemChanged")>] 
    member _.onSelectedItemChanged<'t>(x: Types.AvaloniaNode<'t>, func: obj -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<obj>(AutoCompleteBox.SelectedItemProperty, func) ]

    [<CustomOperation("text")>] 
    member _.text<'t>(x: Types.AvaloniaNode<'t>, text: string) =
        Types.dependencyProperty x<string>(AutoCompleteBox.TextProperty, text, ValueNone) ]
        
    [<CustomOperation("onTextChanged")>] 
    member _.onTextChanged<'t>(x: Types.AvaloniaNode<'t>, func: string -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<string>(AutoCompleteBox.TextProperty, func) ]
        
    [<CustomOperation("searchText")>] 
    member _.searchText<'t>(x: Types.AvaloniaNode<'t>, text: string) =
        Types.dependencyProperty x<string>(AutoCompleteBox.SearchTextProperty, text, ValueNone) ]
        
    [<CustomOperation("onSearchTextChanged")>] 
    member _.onSearchTextChanged<'t>(x: Types.AvaloniaNode<'t>, func: string -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<string>(AutoCompleteBox.SearchTextProperty, func) ]
        
    [<CustomOperation("filterMode")>] 
    member _.filterMode<'t>(x: Types.AvaloniaNode<'t>, mode: AutoCompleteFilterMode) =
        Types.dependencyProperty x<AutoCompleteFilterMode>(AutoCompleteBox.FilterModeProperty, mode, ValueNone) ]
        
    [<CustomOperation("itemFilter")>] 
    member _.itemFilter<'t>(x: Types.AvaloniaNode<'t>, filterFunc: string * obj -> bool) =
        // TODO: implement custom comparer (value is a function)
        Types.dependencyProperty x<_>(AutoCompleteBox.ItemFilterProperty, filterFunc, ValueNone) ]
        
    [<CustomOperation("textFilter")>] 
    member _.textFilter<'t>(x: Types.AvaloniaNode<'t>, filter: string) =
        Types.dependencyProperty x<string>(AutoCompleteBox.TextFilterProperty, filter, ValueNone) ]
        
    [<CustomOperation("dataItems")>] 
    member _.dataItems<'t>(x: Types.AvaloniaNode<'t>, items: IEnumerable) =
        Types.dependencyProperty x<IEnumerable>(AutoCompleteBox.ItemsProperty, items, ValueNone) ]
        
    [<CustomOperation("viewItems")>] 
    member _.viewItems<'t>(x: Types.AvaloniaNode<'t>, views: IView list) =
        x @@ [ AttrBuilder<'t>.CreateContentMultiple(AutoCompleteBox.ItemsProperty, views) ]