module Avalonia.FuncUI.Experiments.DSL.TimePicker

open System
open Avalonia.Controls
open Avalonia.Controls.Templates
open FUI.UiBuilder
open Avalonia.FuncUI.Experiments.DSL.TemplatedControl
open Avalonia.FuncUI.Builder
 
type TimePickerBuilder<'t when 't :> TimePicker>() =
    inherit TemplatedControlBuilder<'t>()

    [<CustomOperation("clockIdentifier")>] 
    member _.clockIdentifier<'t>(x: Node<_, _>, value: string) =
        Types.dependencyProperty<string>(TimePicker.ClockIdentifierProperty, value, ValueNone) ]
    
    [<CustomOperation("header")>] 
    member _.header<'t>(x: Node<_, _>, value: obj) =
        Types.dependencyProperty<obj>(TimePicker.HeaderProperty, value, ValueNone) ]
    
    [<CustomOperation("headerTemplate")>] 
    member _.headerTemplate<'t>(x: Node<_, _>, template: IDataTemplate) =
        Types.dependencyProperty<IDataTemplate>(TimePicker.HeaderTemplateProperty, template, ValueNone) ]
    
    [<CustomOperation("minuteIncrement")>] 
    member _.minuteIncrement<'t>(x: Node<_, _>, value: int) =
        Types.dependencyProperty<int>(TimePicker.MinuteIncrementProperty, value, ValueNone) ]
    
    [<CustomOperation("selectedTime")>] 
    member _.selectedTime<'t>(x: Node<_, _>, value: Nullable<TimeSpan>) =
        Types.dependencyProperty<TimeSpan Nullable>(TimePicker.SelectedTimeProperty, value, ValueNone) ]
    
    [<CustomOperation("onSelectedTimeChanged")>] 
    member _.onSelectedTimeChanged<'t>(x: Node<_, _>, func: Nullable<TimeSpan> -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<TimeSpan Nullable>(TimePicker.SelectedTimeProperty, func) ]
