module Avalonia.FuncUI.Experiments.DSL.ButtonSpinner

open Avalonia.Controls
open FUI.UIBuilder
open Avalonia.FuncUI.Experiments.DSL.Spinner
open Avalonia.FuncUI.Builder

type ButtonSpinnerBuilder<'t when 't :> ButtonSpinner>() =
    inherit SpinnerBuilder<'t>()
    
    /// <summary>
    /// Sets a value indicating whether the <see cref="ButtonSpinner"/> should allow to spin.
    /// </summary>
    [<CustomOperation("allowSpin")>] 
    member _.allowSpin<'t>(x: Element, value: bool) =
        x @@ [ AttrBuilder<'t>.CreateProperty<bool>(ButtonSpinner.AllowSpinProperty, value, ValueNone) ]

    /// <summary>
    /// Sets a value indicating whether the spin buttons should be shown.
    /// </summary>
    [<CustomOperation("showButtonSpinner")>] 
    member _.showButtonSpinner<'t>(x: Element, value: bool) =
        x @@ [ AttrBuilder<'t>.CreateProperty<bool>(ButtonSpinner.ShowButtonSpinnerProperty, value, ValueNone) ]

    /// <summary>
    /// Sets current location of the <see cref="ButtonSpinner"/>.
    /// </summary>
    [<CustomOperation("buttonSpinnerLocation")>] 
    member _.buttonSpinnerLocation<'t>(x: Element, value: Location) =
        x @@ [ AttrBuilder<'t>.CreateProperty<Location>(ButtonSpinner.ButtonSpinnerLocationProperty, value, ValueNone) ]