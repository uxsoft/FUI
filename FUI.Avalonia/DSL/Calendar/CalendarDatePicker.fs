module Avalonia.FuncUI.Experiments.DSL.CalendarDatePicker

open System
open Avalonia.Controls
open FUI.UIBuilder
open Avalonia.FuncUI.Experiments.DSL.TemplatedControl
open Avalonia.FuncUI.Builder

type CalendarDatePickerBuilder<'t when 't :> CalendarDatePicker>() =
    inherit TemplatedControlBuilder<'t>()

     [<CustomOperation("displayDate")>] 
     member _.displayDate<'t>(x: Element, value: DateTime) =
        x @@ [ AttrBuilder<'t>.CreateProperty<DateTime>(CalendarDatePicker.DisplayDateProperty, value, ValueNone) ]

     [<CustomOperation("displayDateStart")>] 
     member _.displayDateStart<'t>(x: Element, value: DateTime) =
        x @@ [ AttrBuilder<'t>.CreateProperty<DateTime Nullable>(CalendarDatePicker.DisplayDateStartProperty, Nullable value, ValueNone) ]

     [<CustomOperation("displayDateEnd")>] 
     member _.displayDateEnd<'t>(x: Element, value: DateTime) =
        x @@ [ AttrBuilder<'t>.CreateProperty<DateTime Nullable>(CalendarDatePicker.DisplayDateEndProperty, Nullable value, ValueNone) ]

     [<CustomOperation("firstDayOfWeek")>] 
     member _.firstDayOfWeek<'t>(x: Element, value: DayOfWeek) =
        x @@ [ AttrBuilder<'t>.CreateProperty<DayOfWeek>(CalendarDatePicker.FirstDayOfWeekProperty, value, ValueNone) ]

     [<CustomOperation("isDropDownOpen")>] 
     member _.isDropDownOpen<'t>(x: Element, value: bool) =
        x @@ [ AttrBuilder<'t>.CreateProperty<bool>(CalendarDatePicker.IsDropDownOpenProperty, value, ValueNone) ]

     [<CustomOperation("onDropDownOpenChanged")>] 
     member _.onDropDownOpenChanged<'t>(x: Element, func: bool -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription(CalendarDatePicker.IsDropDownOpenProperty, func) ]
    
     [<CustomOperation("isTodayHighlighted")>] 
     member _.isTodayHighlighted<'t>(x: Element, value: bool) =
        x @@ [ AttrBuilder<'t>.CreateProperty<bool>(CalendarDatePicker.IsTodayHighlightedProperty , value, ValueNone) ]

     [<CustomOperation("selectedDate")>] 
     member _.selectedDate<'t>(x: Element, value: DateTime) =
        x @@ [ AttrBuilder<'t>.CreateProperty<DateTime Nullable>(CalendarDatePicker.SelectedDateProperty, Nullable value, ValueNone) ]

     [<CustomOperation("onSelectedDateChanged")>] 
     member _.onSelectedDateChanged<'t>(x: Element, func: Nullable<DateTime> -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<DateTime Nullable>(CalendarDatePicker.SelectedDateProperty, func) ]

     [<CustomOperation("selectedDateFormat")>] 
     member _.selectedDateFormat<'t>(x: Element, value: CalendarDatePickerFormat) =
        x @@ [ AttrBuilder<'t>.CreateProperty<CalendarDatePickerFormat>(CalendarDatePicker.SelectedDateFormatProperty, value, ValueNone) ]

     [<CustomOperation("customDateFormatString")>] 
     member _.customDateFormatString<'t>(x: Element, value: string) =
        x @@ [ AttrBuilder<'t>.CreateProperty<string>(CalendarDatePicker.CustomDateFormatStringProperty, value, ValueNone) ]

     [<CustomOperation("text")>] 
     member _.text<'t>(x: Element, value: string) =
        x @@ [ AttrBuilder<'t>.CreateProperty<string>(CalendarDatePicker.TextProperty, value, ValueNone) ]

     [<CustomOperation("watermark")>] 
     member _.watermark<'t>(x: Element, value: string) =
        x @@ [ AttrBuilder<'t>.CreateProperty<string>(CalendarDatePicker.WatermarkProperty, value, ValueNone) ]

     [<CustomOperation("useFloatingWatermark")>] 
     member _.useFloatingWatermark<'t>(x: Element, value: bool) =
        x @@ [ AttrBuilder<'t>.CreateProperty<bool>(CalendarDatePicker.UseFloatingWatermarkProperty, value, ValueNone) ]