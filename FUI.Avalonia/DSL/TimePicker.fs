module Avalonia.FuncUI.Experiments.DSL.TimePicker

open System
open Avalonia.Controls
open Avalonia.Controls.Templates
open FUI.UIBuilder
open Avalonia.FuncUI.Experiments.DSL.TemplatedControl
open Avalonia.FuncUI.Builder
 
type TimePickerBuilder<'t when 't :> TimePicker>() =
    inherit TemplatedControlBuilder<'t>()

    [<CustomOperation("clockIdentifier")>] 
    member _.clockIdentifier<'t>(x: Element, value: string) =
        x @@ [ AttrBuilder<'t>.CreateProperty<string>(TimePicker.ClockIdentifierProperty, value, ValueNone) ]
    
    [<CustomOperation("header")>] 
    member _.header<'t>(x: Element, value: obj) =
        x @@ [ AttrBuilder<'t>.CreateProperty<obj>(TimePicker.HeaderProperty, value, ValueNone) ]
    
    [<CustomOperation("headerTemplate")>] 
    member _.headerTemplate<'t>(x: Element, template: IDataTemplate) =
        x @@ [ AttrBuilder<'t>.CreateProperty<IDataTemplate>(TimePicker.HeaderTemplateProperty, template, ValueNone) ]
    
    [<CustomOperation("minuteIncrement")>] 
    member _.minuteIncrement<'t>(x: Element, value: int) =
        x @@ [ AttrBuilder<'t>.CreateProperty<int>(TimePicker.MinuteIncrementProperty, value, ValueNone) ]
    
    [<CustomOperation("selectedTime")>] 
    member _.selectedTime<'t>(x: Element, value: Nullable<TimeSpan>) =
        x @@ [ AttrBuilder<'t>.CreateProperty<TimeSpan Nullable>(TimePicker.SelectedTimeProperty, value, ValueNone) ]
    
    [<CustomOperation("onSelectedTimeChanged")>] 
    member _.onSelectedTimeChanged<'t>(x: Element, func: Nullable<TimeSpan> -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<TimeSpan Nullable>(TimePicker.SelectedTimeProperty, func) ]
