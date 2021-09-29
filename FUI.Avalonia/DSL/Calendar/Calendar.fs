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
     member _.firstDayOfWeek<'t>(x: Types.AvaloniaNode<'t>, value: DayOfWeek) =
        Types.dependencyProperty x<DayOfWeek>(Calendar.FirstDayOfWeekProperty, value, ValueNone) ]
    
     [<CustomOperation("isTodayHighlighted")>] 
     member _.isTodayHighlighted<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x<bool>(Calendar.IsTodayHighlightedProperty , value, ValueNone) ]

     [<CustomOperation("headerBackground")>] 
     member _.headerBackground<'t>(x: Types.AvaloniaNode<'t>, value: IBrush) =
        Types.dependencyProperty x<IBrush>(Calendar.HeaderBackgroundProperty, value, ValueNone) ]

     [<CustomOperation("displayMode")>] 
     member _.displayMode<'t>(x: Types.AvaloniaNode<'t>, value: CalendarMode) =
        Types.dependencyProperty x<CalendarMode>(Calendar.DisplayModeProperty, value, ValueNone) ]

     [<CustomOperation("onDisplayModeChanged")>] 
     member _.onDisplayModeChanged<'t>(x: Types.AvaloniaNode<'t>, func: CalendarMode -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<CalendarMode>(Calendar.DisplayModeProperty, func) ]

     [<CustomOperation("selectionMode")>] 
     member _.selectionMode<'t>(x: Types.AvaloniaNode<'t>, value: CalendarSelectionMode) =
        Types.dependencyProperty x<CalendarSelectionMode>(Calendar.SelectionModeProperty, value, ValueNone) ]

     [<CustomOperation("onSelectionModeChanged")>] 
     member _.onSelectionModeChanged<'t>(x: Types.AvaloniaNode<'t>, func: CalendarSelectionMode  -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<CalendarSelectionMode >(Calendar.SelectionModeProperty, func) ]

     [<CustomOperation("selectedDate")>] 
     member _.selectedDate<'t>(x: Types.AvaloniaNode<'t>, value: DateTime) =
        Types.dependencyProperty x<DateTime Nullable>(Calendar.SelectedDateProperty, Nullable value, ValueNone) ]

     [<CustomOperation("onSelectedDateChanged")>] 
     member _.onSelectedDateChanged<'t>(x: Types.AvaloniaNode<'t>, func: Nullable<DateTime> -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<DateTime Nullable>(Calendar.SelectedDateProperty, func) ]

     [<CustomOperation("displayDate")>] 
     member _.displayDate<'t>(x: Types.AvaloniaNode<'t>, value: DateTime) =
        Types.dependencyProperty x<DateTime>(Calendar.DisplayDateProperty, value, ValueNone) ]

     [<CustomOperation("displayDateStart")>] 
     member _.displayDateStart<'t>(x: Types.AvaloniaNode<'t>, value: DateTime) =
        Types.dependencyProperty x<DateTime Nullable>(Calendar.DisplayDateStartProperty, Nullable value, ValueNone) ]

     [<CustomOperation("displayDateEnd")>] 
     member _.displayDateEnd<'t>(x: Types.AvaloniaNode<'t>, value: DateTime) =
        Types.dependencyProperty x<DateTime Nullable>(Calendar.DisplayDateEndProperty, Nullable value, ValueNone) ]