module Avalonia.FuncUI.Experiments.DSL.Calendar

open System
open FUI.UIBuilder
open Avalonia.FuncUI.Experiments.DSL.TemplatedControl
open Avalonia.Media
open Avalonia.Controls
open Avalonia.FuncUI.Builder
 
type CalendarBuilder<'t when 't :> Calendar>() =
    inherit TemplatedControlBuilder<'t>()

     [<CustomOperation("firstDayOfWeek")>] 
     member _.firstDayOfWeek<'t>(x: Element, value: DayOfWeek) =
        x @@ [ AttrBuilder<'t>.CreateProperty<DayOfWeek>(Calendar.FirstDayOfWeekProperty, value, ValueNone) ]
    
     [<CustomOperation("isTodayHighlighted")>] 
     member _.isTodayHighlighted<'t>(x: Element, value: bool) =
        x @@ [ AttrBuilder<'t>.CreateProperty<bool>(Calendar.IsTodayHighlightedProperty , value, ValueNone) ]

     [<CustomOperation("headerBackground")>] 
     member _.headerBackground<'t>(x: Element, value: IBrush) =
        x @@ [ AttrBuilder<'t>.CreateProperty<IBrush>(Calendar.HeaderBackgroundProperty, value, ValueNone) ]

     [<CustomOperation("displayMode")>] 
     member _.displayMode<'t>(x: Element, value: CalendarMode) =
        x @@ [ AttrBuilder<'t>.CreateProperty<CalendarMode>(Calendar.DisplayModeProperty, value, ValueNone) ]

     [<CustomOperation("onDisplayModeChanged")>] 
     member _.onDisplayModeChanged<'t>(x: Element, func: CalendarMode -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<CalendarMode>(Calendar.DisplayModeProperty, func) ]

     [<CustomOperation("selectionMode")>] 
     member _.selectionMode<'t>(x: Element, value: CalendarSelectionMode) =
        x @@ [ AttrBuilder<'t>.CreateProperty<CalendarSelectionMode>(Calendar.SelectionModeProperty, value, ValueNone) ]

     [<CustomOperation("onSelectionModeChanged")>] 
     member _.onSelectionModeChanged<'t>(x: Element, func: CalendarSelectionMode  -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<CalendarSelectionMode >(Calendar.SelectionModeProperty, func) ]

     [<CustomOperation("selectedDate")>] 
     member _.selectedDate<'t>(x: Element, value: DateTime) =
        x @@ [ AttrBuilder<'t>.CreateProperty<DateTime Nullable>(Calendar.SelectedDateProperty, Nullable value, ValueNone) ]

     [<CustomOperation("onSelectedDateChanged")>] 
     member _.onSelectedDateChanged<'t>(x: Element, func: Nullable<DateTime> -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<DateTime Nullable>(Calendar.SelectedDateProperty, func) ]

     [<CustomOperation("displayDate")>] 
     member _.displayDate<'t>(x: Element, value: DateTime) =
        x @@ [ AttrBuilder<'t>.CreateProperty<DateTime>(Calendar.DisplayDateProperty, value, ValueNone) ]

     [<CustomOperation("displayDateStart")>] 
     member _.displayDateStart<'t>(x: Element, value: DateTime) =
        x @@ [ AttrBuilder<'t>.CreateProperty<DateTime Nullable>(Calendar.DisplayDateStartProperty, Nullable value, ValueNone) ]

     [<CustomOperation("displayDateEnd")>] 
     member _.displayDateEnd<'t>(x: Element, value: DateTime) =
        x @@ [ AttrBuilder<'t>.CreateProperty<DateTime Nullable>(Calendar.DisplayDateEndProperty, Nullable value, ValueNone) ]