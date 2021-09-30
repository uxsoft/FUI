module FUI.Avalonia.CalendarDatePicker

open System
open Avalonia.Controls
open FUI.Avalonia.TemplatedControl

type CalendarDatePickerBuilder<'t when 't :> CalendarDatePicker and 't : equality>() =
    inherit TemplatedControlBuilder<'t>()

     [<CustomOperation("displayDate")>] 
     member _.displayDate<'t>(x: Types.AvaloniaNode<'t>, value: DateTime) =
        Types.dependencyProperty x CalendarDatePicker.DisplayDateProperty value

     [<CustomOperation("displayDateStart")>] 
     member _.displayDateStart<'t>(x: Types.AvaloniaNode<'t>, value: DateTime) =
        Types.dependencyProperty x CalendarDatePicker.DisplayDateStartProperty (Nullable value)

     [<CustomOperation("displayDateEnd")>] 
     member _.displayDateEnd<'t>(x: Types.AvaloniaNode<'t>, value: DateTime) =
        Types.dependencyProperty x CalendarDatePicker.DisplayDateEndProperty (Nullable value)

     [<CustomOperation("firstDayOfWeek")>] 
     member _.firstDayOfWeek<'t>(x: Types.AvaloniaNode<'t>, value: DayOfWeek) =
        Types.dependencyProperty x CalendarDatePicker.FirstDayOfWeekProperty value

     [<CustomOperation("isDropDownOpen")>] 
     member _.isDropDownOpen<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x CalendarDatePicker.IsDropDownOpenProperty value

     [<CustomOperation("onDropDownOpenChanged")>] 
     member _.onDropDownOpenChanged<'t>(x: Types.AvaloniaNode<'t>, func: bool -> unit) =
        Types.dependencyPropertyEvent x CalendarDatePicker.IsDropDownOpenProperty func
    
     [<CustomOperation("isTodayHighlighted")>] 
     member _.isTodayHighlighted<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x CalendarDatePicker.IsTodayHighlightedProperty value

     [<CustomOperation("selectedDate")>] 
     member _.selectedDate<'t>(x: Types.AvaloniaNode<'t>, value: DateTime) =
        Types.dependencyProperty x CalendarDatePicker.SelectedDateProperty (Nullable value)

     [<CustomOperation("onSelectedDateChanged")>] 
     member _.onSelectedDateChanged<'t>(x: Types.AvaloniaNode<'t>, func: Nullable<DateTime> -> unit) =
        Types.dependencyPropertyEvent x CalendarDatePicker.SelectedDateProperty func

     [<CustomOperation("selectedDateFormat")>] 
     member _.selectedDateFormat<'t>(x: Types.AvaloniaNode<'t>, value: CalendarDatePickerFormat) =
        Types.dependencyProperty x CalendarDatePicker.SelectedDateFormatProperty value

     [<CustomOperation("customDateFormatString")>] 
     member _.customDateFormatString<'t>(x: Types.AvaloniaNode<'t>, value: string) =
        Types.dependencyProperty x CalendarDatePicker.CustomDateFormatStringProperty value

     [<CustomOperation("text")>] 
     member _.text<'t>(x: Types.AvaloniaNode<'t>, value: string) =
        Types.dependencyProperty x CalendarDatePicker.TextProperty value

     [<CustomOperation("watermark")>] 
     member _.watermark<'t>(x: Types.AvaloniaNode<'t>, value: string) =
        Types.dependencyProperty x CalendarDatePicker.WatermarkProperty value

     [<CustomOperation("useFloatingWatermark")>] 
     member _.useFloatingWatermark<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x CalendarDatePicker.UseFloatingWatermarkProperty value