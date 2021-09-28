module Avalonia.FuncUI.Experiments.DSL.Spinner

open Avalonia.Controls
open FUI.UiBuilder
open Avalonia.FuncUI.Experiments.DSL.ContentControl
open Avalonia.FuncUI.Types
open Avalonia.FuncUI.Builder

let create (attrs: IAttr<Spinner> list): IView<Spinner> =
    ViewBuilder.Create<Spinner>(attrs)

type SpinnerBuilder<'t when 't :> Spinner>() =
    inherit ContentControlBuilder<'t>()
    
    /// <summary>
    /// Sets <see cref="ValidSpinDirections"/> allowed for this control.
    /// </summary>
    [<CustomOperation("validSpinDirection")>] 
    member _.validSpinDirection<'t>(x: Node<_, _>, value: ValidSpinDirections) =
        Types.dependencyProperty<ValidSpinDirections>(Spinner.ValidSpinDirectionProperty, value, ValueNone) ]
    
    /// <summary>
    /// Occurs when spinning is initiated by the end-user.
    /// </summary>
    [<CustomOperation("onSpin")>] 
    member _.onSpin<'t>(x: Node<_, _>, func: SpinEventArgs -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<SpinEventArgs>(Spinner.SpinEvent, func) ]