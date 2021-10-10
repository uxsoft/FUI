module FUI.Avalonia.CalendarDatePicker

open System
open Avalonia.Controls
open FUI.Avalonia.TemplatedControl

type CalendarDatePickerBuilder<'t when 't :> CalendarDatePicker and 't : equality>() =
    inherit TemplatedControlBuilder<'t>()

     /// DateTime | ObservableValue<DateTime>
     [<CustomOperation("displayDate")>] 
     member _.displayDate<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x CalendarDatePicker.DisplayDateProperty value

     /// Nullable DateTime | ObservableValue<Nullable DateTime>
     [<CustomOperation("displayDateStart")>] 
     member _.displayDateStart<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x CalendarDatePicker.DisplayDateStartProperty value

     /// Nullable DateTime | ObservableValue<Nullable DateTime>
     [<CustomOperation("displayDateEnd")>] 
     member _.displayDateEnd<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x CalendarDatePicker.DisplayDateEndProperty value

     /// DayOfWeek | ObservableValue<DayOfWeek>
     [<CustomOperation("firstDayOfWeek")>] 
     member _.firstDayOfWeek<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x CalendarDatePicker.FirstDayOfWeekProperty value

     /// bool | ObservableValue<bool>
     [<CustomOperation("isDropDownOpen")>] 
     member _.isDropDownOpen<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x CalendarDatePicker.IsDropDownOpenProperty value

     [<CustomOperation("onDropDownOpenChanged")>] 
     member _.onDropDownOpenChanged<'t>(x: Types.AvaloniaNode<'t>, func: bool -> unit) =
        Types.dependencyPropertyEvent x CalendarDatePicker.IsDropDownOpenProperty func
    
     /// bool | ObservableValue<bool>
     [<CustomOperation("isTodayHighlighted")>] 
     member _.isTodayHighlighted<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x CalendarDatePicker.IsTodayHighlightedProperty value

     /// Nullable DateTime | ObservableValue<NullableDateTime>
     [<CustomOperation("selectedDate")>] 
     member _.selectedDate<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x CalendarDatePicker.SelectedDateProperty value

     [<CustomOperation("onSelectedDateChanged")>] 
     member _.onSelectedDateChanged<'t, 'v>(x: Types.AvaloniaNode<'t>, func: Nullable<DateTime> -> unit) =
        Types.dependencyPropertyEvent x CalendarDatePicker.SelectedDateProperty func

     /// CalendarDatePickerFormat | ObservableValue<CalendarDatePickerFormat>
     [<CustomOperation("selectedDateFormat")>] 
     member _.selectedDateFormat<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x CalendarDatePicker.SelectedDateFormatProperty value

     /// string | ObservableValue<string>
     [<CustomOperation("customDateFormatString")>] 
     member _.customDateFormatString<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x CalendarDatePicker.CustomDateFormatStringProperty value

     /// string | ObservableValue<string>
     [<CustomOperation("text")>] 
     member _.text<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x CalendarDatePicker.TextProperty value

     /// string | ObservableValue<string>
     [<CustomOperation("watermark")>] 
     member _.watermark<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x CalendarDatePicker.WatermarkProperty value

     /// bool | ObservableValue<bool>
     [<CustomOperation("useFloatingWatermark")>] 
     member _.useFloatingWatermark<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x CalendarDatePicker.UseFloatingWatermarkProperty value