module FUI.Avalonia.Calendar

open System
open FUI.Avalonia.TemplatedControl
open Avalonia.Media
open Avalonia.Controls
 
type CalendarBuilder<'t when 't :> Calendar and 't : equality>() =
    inherit TemplatedControlBuilder<'t>()

     [<CustomOperation("firstDayOfWeek")>] 
     member _.firstDayOfWeek<'t>(x: Types.AvaloniaNode<'t>, value: DayOfWeek) =
        Types.dependencyProperty x Calendar.FirstDayOfWeekProperty value
    
     [<CustomOperation("isTodayHighlighted")>] 
     member _.isTodayHighlighted<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x Calendar.IsTodayHighlightedProperty value

     [<CustomOperation("headerBackground")>] 
     member _.headerBackground<'t>(x: Types.AvaloniaNode<'t>, value: IBrush) =
        Types.dependencyProperty x Calendar.HeaderBackgroundProperty value

     [<CustomOperation("displayMode")>] 
     member _.displayMode<'t>(x: Types.AvaloniaNode<'t>, value: CalendarMode) =
        Types.dependencyProperty x Calendar.DisplayModeProperty value

     [<CustomOperation("onDisplayModeChanged")>] 
     member _.onDisplayModeChanged<'t>(x: Types.AvaloniaNode<'t>, func: CalendarMode -> unit) =
        Types.dependencyPropertyEvent x Calendar.DisplayModeProperty func

     [<CustomOperation("selectionMode")>] 
     member _.selectionMode<'t>(x: Types.AvaloniaNode<'t>, value: CalendarSelectionMode) =
        Types.dependencyProperty x Calendar.SelectionModeProperty value

     [<CustomOperation("onSelectionModeChanged")>] 
     member _.onSelectionModeChanged<'t>(x: Types.AvaloniaNode<'t>, func: CalendarSelectionMode  -> unit) =
        Types.dependencyPropertyEvent x Calendar.SelectionModeProperty func

     [<CustomOperation("selectedDate")>] 
     member _.selectedDate<'t>(x: Types.AvaloniaNode<'t>, value: DateTime) =
        Types.dependencyProperty x Calendar.SelectedDateProperty (Nullable value)

     [<CustomOperation("onSelectedDateChanged")>] 
     member _.onSelectedDateChanged<'t>(x: Types.AvaloniaNode<'t>, func: Nullable<DateTime> -> unit) =
        Types.dependencyPropertyEvent x Calendar.SelectedDateProperty func

     [<CustomOperation("displayDate")>] 
     member _.displayDate<'t>(x: Types.AvaloniaNode<'t>, value: DateTime) =
        Types.dependencyProperty x Calendar.DisplayDateProperty value

     [<CustomOperation("displayDateStart")>] 
     member _.displayDateStart<'t>(x: Types.AvaloniaNode<'t>, value: DateTime) =
        Types.dependencyProperty x Calendar.DisplayDateStartProperty (Nullable value)

     [<CustomOperation("displayDateEnd")>] 
     member _.displayDateEnd<'t>(x: Types.AvaloniaNode<'t>, value: DateTime) =
        Types.dependencyProperty x Calendar.DisplayDateEndProperty (Nullable value)