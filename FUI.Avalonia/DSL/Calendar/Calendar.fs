module FUI.Avalonia.Calendar

open System
open FUI.UiBuilder
open FUI.Avalonia.TemplatedControl
open Avalonia.Media
open Avalonia.Controls
open Avalonia.FuncUI.Builder
 
type CalendarBuilder<'t when 't :> Calendar>() =
    inherit TemplatedControlBuilder<'t>()

     [<CustomOperation("firstDayOfWeek")>] 
     member _.firstDayOfWeek<'t>(x: Node<_, _>, value: DayOfWeek) =
        Types.dependencyProperty<DayOfWeek>(Calendar.FirstDayOfWeekProperty, value, ValueNone) ]
    
     [<CustomOperation("isTodayHighlighted")>] 
     member _.isTodayHighlighted<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(Calendar.IsTodayHighlightedProperty , value, ValueNone) ]

     [<CustomOperation("headerBackground")>] 
     member _.headerBackground<'t>(x: Node<_, _>, value: IBrush) =
        Types.dependencyProperty<IBrush>(Calendar.HeaderBackgroundProperty, value, ValueNone) ]

     [<CustomOperation("displayMode")>] 
     member _.displayMode<'t>(x: Node<_, _>, value: CalendarMode) =
        Types.dependencyProperty<CalendarMode>(Calendar.DisplayModeProperty, value, ValueNone) ]

     [<CustomOperation("onDisplayModeChanged")>] 
     member _.onDisplayModeChanged<'t>(x: Node<_, _>, func: CalendarMode -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<CalendarMode>(Calendar.DisplayModeProperty, func) ]

     [<CustomOperation("selectionMode")>] 
     member _.selectionMode<'t>(x: Node<_, _>, value: CalendarSelectionMode) =
        Types.dependencyProperty<CalendarSelectionMode>(Calendar.SelectionModeProperty, value, ValueNone) ]

     [<CustomOperation("onSelectionModeChanged")>] 
     member _.onSelectionModeChanged<'t>(x: Node<_, _>, func: CalendarSelectionMode  -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<CalendarSelectionMode >(Calendar.SelectionModeProperty, func) ]

     [<CustomOperation("selectedDate")>] 
     member _.selectedDate<'t>(x: Node<_, _>, value: DateTime) =
        Types.dependencyProperty<DateTime Nullable>(Calendar.SelectedDateProperty, Nullable value, ValueNone) ]

     [<CustomOperation("onSelectedDateChanged")>] 
     member _.onSelectedDateChanged<'t>(x: Node<_, _>, func: Nullable<DateTime> -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<DateTime Nullable>(Calendar.SelectedDateProperty, func) ]

     [<CustomOperation("displayDate")>] 
     member _.displayDate<'t>(x: Node<_, _>, value: DateTime) =
        Types.dependencyProperty<DateTime>(Calendar.DisplayDateProperty, value, ValueNone) ]

     [<CustomOperation("displayDateStart")>] 
     member _.displayDateStart<'t>(x: Node<_, _>, value: DateTime) =
        Types.dependencyProperty<DateTime Nullable>(Calendar.DisplayDateStartProperty, Nullable value, ValueNone) ]

     [<CustomOperation("displayDateEnd")>] 
     member _.displayDateEnd<'t>(x: Node<_, _>, value: DateTime) =
        Types.dependencyProperty<DateTime Nullable>(Calendar.DisplayDateEndProperty, Nullable value, ValueNone) ]