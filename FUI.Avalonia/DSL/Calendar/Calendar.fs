module FUI.Avalonia.Calendar

open System
open FUI.Avalonia.TemplatedControl
open Avalonia.Media
open Avalonia.Controls
 
type CalendarBuilder<'t when 't :> Calendar and 't : equality>() =
    inherit TemplatedControlBuilder<'t>()

     /// DayOfWeek | ObservableValue<DayOfWeek>
     [<CustomOperation("firstDayOfWeek")>] 
     member _.firstDayOfWeek<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Calendar.FirstDayOfWeekProperty value
    
     /// bool | ObservableValue<bool>
     [<CustomOperation("isTodayHighlighted")>] 
     member _.isTodayHighlighted<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Calendar.IsTodayHighlightedProperty value

     /// IBrush | ObservableValue<IBrush>
     [<CustomOperation("headerBackground")>] 
     member _.headerBackground<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Calendar.HeaderBackgroundProperty value

     /// CalendarMode | ObservableValue<CalendarMode>
     [<CustomOperation("displayMode")>] 
     member _.displayMode<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Calendar.DisplayModeProperty value

     [<CustomOperation("onDisplayModeChanged")>] 
     member _.onDisplayModeChanged<'t, 'v>(x, func: CalendarMode -> unit) =
        Types.dependencyPropertyEvent x Calendar.DisplayModeProperty func

     /// CalendarSelectionMode | ObservableValue<CalendarSelectionMode>
     [<CustomOperation("selectionMode")>] 
     member _.selectionMode<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Calendar.SelectionModeProperty value

     [<CustomOperation("onSelectionModeChanged")>] 
     member _.onSelectionModeChanged<'t, 'v>(x, func: CalendarSelectionMode  -> unit) =
        Types.dependencyPropertyEvent x Calendar.SelectionModeProperty func

     /// Nullable DateTime | ObservableValue<Nullable DateTime>
     [<CustomOperation("selectedDate")>] 
     member _.selectedDate<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Calendar.SelectedDateProperty value

     [<CustomOperation("onSelectedDateChanged")>] 
     member _.onSelectedDateChanged<'t, 'v>(x, func: Nullable<DateTime> -> unit) =
        Types.dependencyPropertyEvent x Calendar.SelectedDateProperty func

     /// DateTime | ObservableValue<DateTime>
     [<CustomOperation("displayDate")>] 
     member _.displayDate<'t, 'v>(x, value: DateTime) =
        Types.dependencyProperty x Calendar.DisplayDateProperty value

     /// DateTime | ObservableValue<DateTime>
     [<CustomOperation("displayDateStart")>] 
     member _.displayDateStart<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Calendar.DisplayDateStartProperty value

     /// DateTime | ObservableValue<DateTime>
     [<CustomOperation("displayDateEnd")>] 
     member _.displayDateEnd<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Calendar.DisplayDateEndProperty value