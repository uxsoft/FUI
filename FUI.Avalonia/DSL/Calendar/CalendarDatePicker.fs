module Avalonia.FuncUI.Experiments.DSL.CalendarDatePicker

open System
open Avalonia.Controls
open FUI.UiBuilder
open Avalonia.FuncUI.Experiments.DSL.TemplatedControl
open Avalonia.FuncUI.Builder

type CalendarDatePickerBuilder<'t when 't :> CalendarDatePicker>() =
    inherit TemplatedControlBuilder<'t>()

     [<CustomOperation("displayDate")>] 
     member _.displayDate<'t>(x: Node<_, _>, value: DateTime) =
        Types.dependencyProperty<DateTime>(CalendarDatePicker.DisplayDateProperty, value, ValueNone) ]

     [<CustomOperation("displayDateStart")>] 
     member _.displayDateStart<'t>(x: Node<_, _>, value: DateTime) =
        Types.dependencyProperty<DateTime Nullable>(CalendarDatePicker.DisplayDateStartProperty, Nullable value, ValueNone) ]

     [<CustomOperation("displayDateEnd")>] 
     member _.displayDateEnd<'t>(x: Node<_, _>, value: DateTime) =
        Types.dependencyProperty<DateTime Nullable>(CalendarDatePicker.DisplayDateEndProperty, Nullable value, ValueNone) ]

     [<CustomOperation("firstDayOfWeek")>] 
     member _.firstDayOfWeek<'t>(x: Node<_, _>, value: DayOfWeek) =
        Types.dependencyProperty<DayOfWeek>(CalendarDatePicker.FirstDayOfWeekProperty, value, ValueNone) ]

     [<CustomOperation("isDropDownOpen")>] 
     member _.isDropDownOpen<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(CalendarDatePicker.IsDropDownOpenProperty, value, ValueNone) ]

     [<CustomOperation("onDropDownOpenChanged")>] 
     member _.onDropDownOpenChanged<'t>(x: Node<_, _>, func: bool -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription(CalendarDatePicker.IsDropDownOpenProperty, func) ]
    
     [<CustomOperation("isTodayHighlighted")>] 
     member _.isTodayHighlighted<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(CalendarDatePicker.IsTodayHighlightedProperty , value, ValueNone) ]

     [<CustomOperation("selectedDate")>] 
     member _.selectedDate<'t>(x: Node<_, _>, value: DateTime) =
        Types.dependencyProperty<DateTime Nullable>(CalendarDatePicker.SelectedDateProperty, Nullable value, ValueNone) ]

     [<CustomOperation("onSelectedDateChanged")>] 
     member _.onSelectedDateChanged<'t>(x: Node<_, _>, func: Nullable<DateTime> -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<DateTime Nullable>(CalendarDatePicker.SelectedDateProperty, func) ]

     [<CustomOperation("selectedDateFormat")>] 
     member _.selectedDateFormat<'t>(x: Node<_, _>, value: CalendarDatePickerFormat) =
        Types.dependencyProperty<CalendarDatePickerFormat>(CalendarDatePicker.SelectedDateFormatProperty, value, ValueNone) ]

     [<CustomOperation("customDateFormatString")>] 
     member _.customDateFormatString<'t>(x: Node<_, _>, value: string) =
        Types.dependencyProperty<string>(CalendarDatePicker.CustomDateFormatStringProperty, value, ValueNone) ]

     [<CustomOperation("text")>] 
     member _.text<'t>(x: Node<_, _>, value: string) =
        Types.dependencyProperty<string>(CalendarDatePicker.TextProperty, value, ValueNone) ]

     [<CustomOperation("watermark")>] 
     member _.watermark<'t>(x: Node<_, _>, value: string) =
        Types.dependencyProperty<string>(CalendarDatePicker.WatermarkProperty, value, ValueNone) ]

     [<CustomOperation("useFloatingWatermark")>] 
     member _.useFloatingWatermark<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(CalendarDatePicker.UseFloatingWatermarkProperty, value, ValueNone) ]