module FUI.Avalonia.TimePicker

open System
open Avalonia.Controls
open Avalonia.Controls.Templates
open FUI.Avalonia.TemplatedControl
 
type TimePickerBuilder<'t when 't :> TimePicker and 't : equality>() =
    inherit TemplatedControlBuilder<'t>()

    [<CustomOperation("clockIdentifier")>] 
    member _.clockIdentifier<'t>(x: Types.AvaloniaNode<'t>, value: string) =
        Types.dependencyProperty x TimePicker.ClockIdentifierProperty value
    
    [<CustomOperation("header")>] 
    member _.header<'t>(x: Types.AvaloniaNode<'t>, value: obj) =
        Types.dependencyProperty x TimePicker.HeaderProperty value
    
    [<CustomOperation("headerTemplate")>] 
    member _.headerTemplate<'t>(x: Types.AvaloniaNode<'t>, template: IDataTemplate) =
        Types.dependencyProperty x TimePicker.HeaderTemplateProperty template
    
    [<CustomOperation("minuteIncrement")>] 
    member _.minuteIncrement<'t>(x: Types.AvaloniaNode<'t>, value: int) =
        Types.dependencyProperty x TimePicker.MinuteIncrementProperty value
    
    [<CustomOperation("selectedTime")>] 
    member _.selectedTime<'t>(x: Types.AvaloniaNode<'t>, value: Nullable<TimeSpan>) =
        Types.dependencyProperty x TimePicker.SelectedTimeProperty value
    
    [<CustomOperation("onSelectedTimeChanged")>] 
    member _.onSelectedTimeChanged<'t>(x: Types.AvaloniaNode<'t>, func: Nullable<TimeSpan> -> unit) =
        Types.dependencyPropertyEvent x TimePicker.SelectedTimeProperty func
