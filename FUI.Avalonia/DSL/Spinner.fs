module FUI.Avalonia.Spinner

open Avalonia.Controls
open FUI.Avalonia.ContentControl

type SpinnerBuilder<'t when 't :> Spinner and 't : equality>() =
    inherit ContentControlBuilder<'t>()
    
    /// ValidSpinDirections | ObservableValue<ValidSpinDirections>
    [<CustomOperation("validSpinDirection")>] 
    member _.validSpinDirection<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Spinner.ValidSpinDirectionProperty value
    
    [<CustomOperation("onSpin")>] 
    member _.onSpin<'t, 'v>(x, func: SpinEventArgs -> unit) =
        Types.routedEvent x Spinner.SpinEvent func