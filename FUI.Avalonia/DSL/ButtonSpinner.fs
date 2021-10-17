module FUI.Avalonia.ButtonSpinner

open Avalonia.Controls
open FUI.Avalonia.Spinner

type ButtonSpinnerBuilder<'t when 't :> ButtonSpinner and 't : equality>() =
    inherit SpinnerBuilder<'t>()
    
    /// bool | ObservableValue<bool>
    [<CustomOperation("allowSpin")>] 
    member _.allowSpin<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x ButtonSpinner.AllowSpinProperty value

    /// bool | ObservableValue<bool>
    [<CustomOperation("showButtonSpinner")>] 
    member _.showButtonSpinner<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x ButtonSpinner.ShowButtonSpinnerProperty value

    /// Location | ObservableValue<Location>
    [<CustomOperation("buttonSpinnerLocation")>] 
    member _.buttonSpinnerLocation<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x ButtonSpinner.ButtonSpinnerLocationProperty value