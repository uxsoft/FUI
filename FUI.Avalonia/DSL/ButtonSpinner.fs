module FUI.Avalonia.ButtonSpinner

open Avalonia.Controls
open FUI.UiBuilder
open FUI.Avalonia.Spinner
open Avalonia.FuncUI.Builder

type ButtonSpinnerBuilder<'t when 't :> ButtonSpinner>() =
    inherit SpinnerBuilder<'t>()
    
    /// <summary>
    /// Sets a value indicating whether the <see cref="ButtonSpinner"/> should allow to spin.
    /// </summary>
    [<CustomOperation("allowSpin")>] 
    member _.allowSpin<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(ButtonSpinner.AllowSpinProperty, value, ValueNone) ]

    /// <summary>
    /// Sets a value indicating whether the spin buttons should be shown.
    /// </summary>
    [<CustomOperation("showButtonSpinner")>] 
    member _.showButtonSpinner<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(ButtonSpinner.ShowButtonSpinnerProperty, value, ValueNone) ]

    /// <summary>
    /// Sets current location of the <see cref="ButtonSpinner"/>.
    /// </summary>
    [<CustomOperation("buttonSpinnerLocation")>] 
    member _.buttonSpinnerLocation<'t>(x: Node<_, _>, value: Location) =
        Types.dependencyProperty<Location>(ButtonSpinner.ButtonSpinnerLocationProperty, value, ValueNone) ]