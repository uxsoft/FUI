module FUI.Avalonia.ButtonSpinner

open Avalonia.Controls
open FUI.Avalonia.Spinner

type ButtonSpinnerBuilder<'t when 't :> ButtonSpinner and 't : equality>() =
    inherit SpinnerBuilder<'t>()
    
    /// <summary>
    /// Sets a value indicating whether the <see cref="ButtonSpinner"/> should allow to spin.
    /// </summary>
    [<CustomOperation("allowSpin")>] 
    member _.allowSpin<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x ButtonSpinner.AllowSpinProperty value

    /// <summary>
    /// Sets a value indicating whether the spin buttons should be shown.
    /// </summary>
    [<CustomOperation("showButtonSpinner")>] 
    member _.showButtonSpinner<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x ButtonSpinner.ShowButtonSpinnerProperty value

    /// <summary>
    /// Sets current location of the <see cref="ButtonSpinner"/>.
    /// </summary>
    [<CustomOperation("buttonSpinnerLocation")>] 
    member _.buttonSpinnerLocation<'t>(x: Types.AvaloniaNode<'t>, value: Location) =
        Types.dependencyProperty x ButtonSpinner.ButtonSpinnerLocationProperty value