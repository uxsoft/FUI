namespace FUI.Avalonia.DatePicker

open System
open Avalonia.Controls
open Avalonia.Controls.Templates
open FUI.Avalonia
open FUI.Avalonia.TemplatedControl
 
type DatePickerBuilder<'t when 't :> DatePicker and 't : equality>() =
    inherit TemplatedControlBuilder<'t>()

     /// Nullable DateTimeOffset | ObservableValue<Nullable DateTimeOffset>
     [<CustomOperation("selectedDate")>] 
     member _.selectedDate<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x DatePicker.SelectedDateProperty value

     [<CustomOperation("onSelectedDateChanged")>] 
     member _.onSelectedDateChanged<'t, 'v>(x: Types.AvaloniaNode<'t>, func: Nullable<DateTimeOffset> -> unit) =
        Types.dependencyPropertyEvent x DatePicker.SelectedDateProperty func

     /// bool | ObservableValue<bool>
     [<CustomOperation("dayVisible")>] 
     member _.dayVisible<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x DatePicker.DayVisibleProperty value

     /// bool | ObservableValue<bool>
     [<CustomOperation("monthVisible")>] 
     member _.monthVisible<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x DatePicker.MonthVisibleProperty value

     /// bool | ObservableValue<bool>
     [<CustomOperation("yearVisible")>] 
     member _.yearVisible<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x DatePicker.YearVisibleProperty value

     /// string | ObservableValue<string>
     [<CustomOperation("dayFormat")>] 
     member _.dayFormat<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x DatePicker.DayFormatProperty value

     /// string | ObservableValue<string>
     [<CustomOperation("monthFormat")>] 
     member _.monthFormat<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x DatePicker.MonthFormatProperty value

     /// string | ObservableValue<string>
     [<CustomOperation("yearFormat")>] 
     member _.yearFormat<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x DatePicker.YearFormatProperty value

     /// DateTimeOffset | ObservableValue<DateTimeOffset>
     [<CustomOperation("minYear")>] 
     member _.minYear<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x DatePicker.MinYearProperty value
        
     /// DateTimeOffset | ObservableValue<DateTimeOffset>
     [<CustomOperation("maxYear")>] 
     member _.maxYear<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x DatePicker.MaxYearProperty value

     /// obj | ObservableValue<obj>
     [<CustomOperation("header")>] 
     member _.header<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x DatePicker.HeaderProperty value

     /// IDataTemplate | ObservableValue<IDataTemplate>    
     [<CustomOperation("headerTemplate")>] 
     member _.headerTemplate<'t, 'v>(x: Types.AvaloniaNode<'t>, template: 'v) =
        Types.dependencyProperty x DatePicker.HeaderTemplateProperty template
    