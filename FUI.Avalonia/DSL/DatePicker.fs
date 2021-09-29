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
     member _.selectedDate<'t>(x: Node<_, _>, value: DateTimeOffset) =
        Types.dependencyProperty<DateTimeOffset Nullable>(DatePicker.SelectedDateProperty, Nullable value, ValueNone) ]

     [<CustomOperation("onSelectedDateChanged")>] 
     member _.onSelectedDateChanged<'t>(x: Node<_, _>, func: Nullable<DateTimeOffset> -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<DateTimeOffset Nullable>(DatePicker.SelectedDateProperty, func) ]

     [<CustomOperation("dayVisible")>] 
     member _.dayVisible<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(DatePicker.DayVisibleProperty, value, ValueNone) ]

     [<CustomOperation("monthVisible")>] 
     member _.monthVisible<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(DatePicker.MonthVisibleProperty, value, ValueNone) ]

     [<CustomOperation("yearVisible")>] 
     member _.yearVisible<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(DatePicker.YearVisibleProperty, value, ValueNone) ]

     [<CustomOperation("dayFormat")>] 
     member _.dayFormat<'t>(x: Node<_, _>, value: string) =
        Types.dependencyProperty<string>(DatePicker.DayFormatProperty, value, ValueNone) ]

     [<CustomOperation("monthFormat")>] 
     member _.monthFormat<'t>(x: Node<_, _>, value: string) =
        Types.dependencyProperty<string>(DatePicker.MonthFormatProperty, value, ValueNone) ]

     [<CustomOperation("yearFormat")>] 
     member _.yearFormat<'t>(x: Node<_, _>, value: string) =
        Types.dependencyProperty<string>(DatePicker.YearFormatProperty, value, ValueNone) ]

     [<CustomOperation("minYear")>] 
     member _.minYear<'t>(x: Node<_, _>, value: DateTimeOffset) =
        Types.dependencyProperty<DateTimeOffset>(DatePicker.MinYearProperty, value, ValueNone) ]
        
     [<CustomOperation("maxYear")>] 
     member _.maxYear<'t>(x: Node<_, _>, value: DateTimeOffset) =
        Types.dependencyProperty<DateTimeOffset>(DatePicker.MaxYearProperty, value, ValueNone) ]

     [<CustomOperation("header")>] 
     member _.header<'t>(x: Node<_, _>, value: obj) =
        Types.dependencyProperty<obj>(DatePicker.HeaderProperty, value, ValueNone) ]
    
     [<CustomOperation("headerTemplate")>] 
     member _.headerTemplate<'t>(x: Node<_, _>, template: IDataTemplate) =
        Types.dependencyProperty<IDataTemplate>(DatePicker.HeaderTemplateProperty, template, ValueNone) ]
    