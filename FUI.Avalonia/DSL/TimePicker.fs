module FUI.Avalonia.TimePicker

open System
open Avalonia.Controls
open Avalonia.Controls.Templates
open FUI.Avalonia.TemplatedControl
 
type TimePickerBuilder<'t when 't :> TimePicker and 't : equality>() =
    inherit TemplatedControlBuilder<'t>()

    /// string | ObservableValue<string>
    [<CustomOperation("clockIdentifier")>] 
    member _.clockIdentifier<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TimePicker.ClockIdentifierProperty value
    
    /// obj | ObservableValue<obj>
    [<CustomOperation("header")>] 
    member _.header<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TimePicker.HeaderProperty value
    
    /// IDataTemplate | ObservableValue<IDataTemplate>
    [<CustomOperation("headerTemplate")>] 
    member _.headerTemplate<'t, 'v>(x, template: 'v) =
        Types.dependencyProperty x TimePicker.HeaderTemplateProperty template
    
    /// int | ObservableValue<int>
    [<CustomOperation("minuteIncrement")>] 
    member _.minuteIncrement<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TimePicker.MinuteIncrementProperty value
    
    /// Nullable TimeSpan | ObservableValue<Nullable TimeSpan>
    [<CustomOperation("selectedTime")>] 
    member _.selectedTime<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TimePicker.SelectedTimeProperty value
    
    [<CustomOperation("onSelectedTimeChanged")>] 
    member _.onSelectedTimeChanged<'t, 'v>(x, func: Nullable<TimeSpan> -> unit) =
        Types.dependencyPropertyEvent x TimePicker.SelectedTimeProperty func
