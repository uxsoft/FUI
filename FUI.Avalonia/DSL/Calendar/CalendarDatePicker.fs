module FUI.Avalonia.CalendarDatePicker

open System
open Avalonia.Controls
open FUI.UiBuilder
open FUI.Avalonia.TemplatedControl
open Avalonia.FuncUI.Builder

type CalendarDatePickerBuilder<'t when 't :> CalendarDatePicker>() =
    inherit TemplatedControlBuilder<'t>()

     [<CustomOperation("displayDate")>] 
     member _.displayDate<'t>(x: Types.AvaloniaNode<'t>, value: DateTime) =
        Types.dependencyProperty x<DateTime>(CalendarDatePicker.DisplayDateProperty, value, ValueNone) ]

     [<CustomOperation("displayDateStart")>] 
     member _.displayDateStart<'t>(x: Types.AvaloniaNode<'t>, value: DateTime) =
        Types.dependencyProperty x<DateTime Nullable>(CalendarDatePicker.DisplayDateStartProperty, Nullable value, ValueNone) ]

     [<CustomOperation("displayDateEnd")>] 
     member _.displayDateEnd<'t>(x: Types.AvaloniaNode<'t>, value: DateTime) =
        Types.dependencyProperty x<DateTime Nullable>(CalendarDatePicker.DisplayDateEndProperty, Nullable value, ValueNone) ]

     [<CustomOperation("firstDayOfWeek")>] 
     member _.firstDayOfWeek<'t>(x: Types.AvaloniaNode<'t>, value: DayOfWeek) =
        Types.dependencyProperty x<DayOfWeek>(CalendarDatePicker.FirstDayOfWeekProperty, value, ValueNone) ]

     [<CustomOperation("isDropDownOpen")>] 
     member _.isDropDownOpen<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x<bool>(CalendarDatePicker.IsDropDownOpenProperty, value, ValueNone) ]

     [<CustomOperation("onDropDownOpenChanged")>] 
     member _.onDropDownOpenChanged<'t>(x: Types.AvaloniaNode<'t>, func: bool -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription(CalendarDatePicker.IsDropDownOpenProperty, func) ]
    
     [<CustomOperation("isTodayHighlighted")>] 
     member _.isTodayHighlighted<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x<bool>(CalendarDatePicker.IsTodayHighlightedProperty , value, ValueNone) ]

     [<CustomOperation("selectedDate")>] 
     member _.selectedDate<'t>(x: Types.AvaloniaNode<'t>, value: DateTime) =
        Types.dependencyProperty x<DateTime Nullable>(CalendarDatePicker.SelectedDateProperty, Nullable value, ValueNone) ]

     [<CustomOperation("onSelectedDateChanged")>] 
     member _.onSelectedDateChanged<'t>(x: Types.AvaloniaNode<'t>, func: Nullable<DateTime> -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<DateTime Nullable>(CalendarDatePicker.SelectedDateProperty, func) ]

     [<CustomOperation("selectedDateFormat")>] 
     member _.selectedDateFormat<'t>(x: Types.AvaloniaNode<'t>, value: CalendarDatePickerFormat) =
        Types.dependencyProperty x<CalendarDatePickerFormat>(CalendarDatePicker.SelectedDateFormatProperty, value, ValueNone) ]

     [<CustomOperation("customDateFormatString")>] 
     member _.customDateFormatString<'t>(x: Types.AvaloniaNode<'t>, value: string) =
        Types.dependencyProperty x<string>(CalendarDatePicker.CustomDateFormatStringProperty, value, ValueNone) ]

     [<CustomOperation("text")>] 
     member _.text<'t>(x: Types.AvaloniaNode<'t>, value: string) =
        Types.dependencyProperty x<string>(CalendarDatePicker.TextProperty, value, ValueNone) ]

     [<CustomOperation("watermark")>] 
     member _.watermark<'t>(x: Types.AvaloniaNode<'t>, value: string) =
        Types.dependencyProperty x<string>(CalendarDatePicker.WatermarkProperty, value, ValueNone) ]

     [<CustomOperation("useFloatingWatermark")>] 
     member _.useFloatingWatermark<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x<bool>(CalendarDatePicker.UseFloatingWatermarkProperty, value, ValueNone) ]