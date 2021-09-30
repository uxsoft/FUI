﻿module Avalonia.FuncUI.Experiments.DSL.ToggleSwitch

open Avalonia.Controls
open Avalonia.Controls.Templates
open FUI.UIBuilder
open Avalonia.FuncUI.Experiments.DSL.ToggleButton
open Avalonia.FuncUI.Builder

type ToggleSwitchBuilder<'t when 't :> ToggleSwitch>() =
    inherit ToggleButtonBuilder<'t>()
    
    [<CustomOperation("onContent")>] 
    member _.onContent<'t>(x: Element, value: obj) =
        x @@ [ AttrBuilder<'t>.CreateProperty<obj>(ToggleSwitch.OnContentProperty, value, ValueNone) ]
    
    [<CustomOperation("onContentTemplate")>] 
    member _.onContentTemplate<'t>(x: Element, template: IDataTemplate) =
        x @@ [ AttrBuilder<'t>.CreateProperty<IDataTemplate>(ToggleSwitch.OnContentTemplateProperty, template, ValueNone) ]
    
    [<CustomOperation("offContent")>] 
    member _.offContent<'t>(x: Element, value: obj) =
        x @@ [ AttrBuilder<'t>.CreateProperty<obj>(ToggleSwitch.OffContentProperty, value, ValueNone) ]

    [<CustomOperation("offContentTemplate")>] 
    member _.offContentTemplate<'t>(x: Element, template: IDataTemplate) =
        x @@ [ AttrBuilder<'t>.CreateProperty<IDataTemplate>(ToggleSwitch.OffContentTemplateProperty, template, ValueNone) ]
        