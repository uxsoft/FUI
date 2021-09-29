namespace FUI.Avalonia.DatePicker

open System
open Avalonia.Controls
open Avalonia.Controls.Templates
open FUI.UiBuilder
open FUI.Avalonia.TemplatedControl
open Avalonia.FuncUI.Builder
 
type DatePickerBuilder<'t when 't :> DatePicker>() =
    inherit TemplatedControlBuilder<'t>()

     [<CustomOperation("selectedDate")>] 
     member _.selectedDate<'t>(x: Types.AvaloniaNode<'t>, value: DateTimeOffset) =
        Types.dependencyProperty x<DateTimeOffset Nullable>(DatePicker.SelectedDateProperty, Nullable value, ValueNone) ]

     [<CustomOperation("onSelectedDateChanged")>] 
     member _.onSelectedDateChanged<'t>(x: Types.AvaloniaNode<'t>, func: Nullable<DateTimeOffset> -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<DateTimeOffset Nullable>(DatePicker.SelectedDateProperty, func) ]

     [<CustomOperation("dayVisible")>] 
     member _.dayVisible<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x<bool>(DatePicker.DayVisibleProperty, value, ValueNone) ]

     [<CustomOperation("monthVisible")>] 
     member _.monthVisible<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x<bool>(DatePicker.MonthVisibleProperty, value, ValueNone) ]

     [<CustomOperation("yearVisible")>] 
     member _.yearVisible<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x<bool>(DatePicker.YearVisibleProperty, value, ValueNone) ]

     [<CustomOperation("dayFormat")>] 
     member _.dayFormat<'t>(x: Types.AvaloniaNode<'t>, value: string) =
        Types.dependencyProperty x<string>(DatePicker.DayFormatProperty, value, ValueNone) ]

     [<CustomOperation("monthFormat")>] 
     member _.monthFormat<'t>(x: Types.AvaloniaNode<'t>, value: string) =
        Types.dependencyProperty x<string>(DatePicker.MonthFormatProperty, value, ValueNone) ]

     [<CustomOperation("yearFormat")>] 
     member _.yearFormat<'t>(x: Types.AvaloniaNode<'t>, value: string) =
        Types.dependencyProperty x<string>(DatePicker.YearFormatProperty, value, ValueNone) ]

     [<CustomOperation("minYear")>] 
     member _.minYear<'t>(x: Types.AvaloniaNode<'t>, value: DateTimeOffset) =
        Types.dependencyProperty x<DateTimeOffset>(DatePicker.MinYearProperty, value, ValueNone) ]
        
     [<CustomOperation("maxYear")>] 
     member _.maxYear<'t>(x: Types.AvaloniaNode<'t>, value: DateTimeOffset) =
        Types.dependencyProperty x<DateTimeOffset>(DatePicker.MaxYearProperty, value, ValueNone) ]

     [<CustomOperation("header")>] 
     member _.header<'t>(x: Types.AvaloniaNode<'t>, value: obj) =
        Types.dependencyProperty x<obj>(DatePicker.HeaderProperty, value, ValueNone) ]
    
     [<CustomOperation("headerTemplate")>] 
     member _.headerTemplate<'t>(x: Types.AvaloniaNode<'t>, template: IDataTemplate) =
        Types.dependencyProperty x<IDataTemplate>(DatePicker.HeaderTemplateProperty, template, ValueNone) ]
    