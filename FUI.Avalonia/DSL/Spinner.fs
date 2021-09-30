module FUI.Avalonia.Spinner

open Avalonia.Controls
open FUI.Avalonia.ContentControl

type SpinnerBuilder<'t when 't :> Spinner and 't : equality>() =
    inherit ContentControlBuilder<'t>()
    
    /// <summary>
    /// Sets <see cref="ValidSpinDirections"/> allowed for this control.
    /// </summary>
    [<CustomOperation("validSpinDirection")>] 
    member _.validSpinDirection<'t>(x: Types.AvaloniaNode<'t>, value: ValidSpinDirections) =
        Types.dependencyProperty x Spinner.ValidSpinDirectionProperty value
    
    /// <summary>
    /// Occurs when spinning is initiated by the end-user.
    /// </summary>
    [<CustomOperation("onSpin")>] 
    member _.onSpin<'t>(x: Types.AvaloniaNode<'t>, func: SpinEventArgs -> unit) =
        Types.routedEvent x Spinner.SpinEvent func