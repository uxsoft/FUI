namespace FUI.Avalonia.DatePicker

open System
open Avalonia.Controls
open Avalonia.Controls.Templates
open FUI.Avalonia
open FUI.Avalonia.TemplatedControl
 
type DatePickerBuilder<'t when 't :> DatePicker and 't : equality>() =
    inherit TemplatedControlBuilder<'t>()

     [<CustomOperation("selectedDate")>] 
     member _.selectedDate<'t>(x: Types.AvaloniaNode<'t>, value: DateTimeOffset) =
        Types.dependencyProperty x DatePicker.SelectedDateProperty (Nullable value)

     [<CustomOperation("onSelectedDateChanged")>] 
     member _.onSelectedDateChanged<'t>(x: Types.AvaloniaNode<'t>, func: Nullable<DateTimeOffset> -> unit) =
        Types.dependencyPropertyEvent x DatePicker.SelectedDateProperty func

     [<CustomOperation("dayVisible")>] 
     member _.dayVisible<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x DatePicker.DayVisibleProperty value

     [<CustomOperation("monthVisible")>] 
     member _.monthVisible<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x DatePicker.MonthVisibleProperty value

     [<CustomOperation("yearVisible")>] 
     member _.yearVisible<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x DatePicker.YearVisibleProperty value

     [<CustomOperation("dayFormat")>] 
     member _.dayFormat<'t>(x: Types.AvaloniaNode<'t>, value: string) =
        Types.dependencyProperty x DatePicker.DayFormatProperty value

     [<CustomOperation("monthFormat")>] 
     member _.monthFormat<'t>(x: Types.AvaloniaNode<'t>, value: string) =
        Types.dependencyProperty x DatePicker.MonthFormatProperty value

     [<CustomOperation("yearFormat")>] 
     member _.yearFormat<'t>(x: Types.AvaloniaNode<'t>, value: string) =
        Types.dependencyProperty x DatePicker.YearFormatProperty value

     [<CustomOperation("minYear")>] 
     member _.minYear<'t>(x: Types.AvaloniaNode<'t>, value: DateTimeOffset) =
        Types.dependencyProperty x DatePicker.MinYearProperty value
        
     [<CustomOperation("maxYear")>] 
     member _.maxYear<'t>(x: Types.AvaloniaNode<'t>, value: DateTimeOffset) =
        Types.dependencyProperty x DatePicker.MaxYearProperty value

     [<CustomOperation("header")>] 
     member _.header<'t>(x: Types.AvaloniaNode<'t>, value: obj) =
        Types.dependencyProperty x DatePicker.HeaderProperty value
    
     [<CustomOperation("headerTemplate")>] 
     member _.headerTemplate<'t>(x: Types.AvaloniaNode<'t>, template: IDataTemplate) =
        Types.dependencyProperty x DatePicker.HeaderTemplateProperty template
    