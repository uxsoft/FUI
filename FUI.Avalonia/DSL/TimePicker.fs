module FUI.Avalonia.TimePicker

open System
open Avalonia.Controls
open Avalonia.Controls.Templates
open FUI.UiBuilder
open FUI.Avalonia.TemplatedControl
open Avalonia.FuncUI.Builder
 
type TimePickerBuilder<'t when 't :> TimePicker>() =
    inherit TemplatedControlBuilder<'t>()

    [<CustomOperation("clockIdentifier")>] 
    member _.clockIdentifier<'t>(x: Types.AvaloniaNode<'t>, value: string) =
        Types.dependencyProperty x<string>(TimePicker.ClockIdentifierProperty, value, ValueNone) ]
    
    [<CustomOperation("header")>] 
    member _.header<'t>(x: Types.AvaloniaNode<'t>, value: obj) =
        Types.dependencyProperty x<obj>(TimePicker.HeaderProperty, value, ValueNone) ]
    
    [<CustomOperation("headerTemplate")>] 
    member _.headerTemplate<'t>(x: Types.AvaloniaNode<'t>, template: IDataTemplate) =
        Types.dependencyProperty x<IDataTemplate>(TimePicker.HeaderTemplateProperty, template, ValueNone) ]
    
    [<CustomOperation("minuteIncrement")>] 
    member _.minuteIncrement<'t>(x: Types.AvaloniaNode<'t>, value: int) =
        Types.dependencyProperty x<int>(TimePicker.MinuteIncrementProperty, value, ValueNone) ]
    
    [<CustomOperation("selectedTime")>] 
    member _.selectedTime<'t>(x: Types.AvaloniaNode<'t>, value: Nullable<TimeSpan>) =
        Types.dependencyProperty x<TimeSpan Nullable>(TimePicker.SelectedTimeProperty, value, ValueNone) ]
    
    [<CustomOperation("onSelectedTimeChanged")>] 
    member _.onSelectedTimeChanged<'t>(x: Types.AvaloniaNode<'t>, func: Nullable<TimeSpan> -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<TimeSpan Nullable>(TimePicker.SelectedTimeProperty, func) ]
