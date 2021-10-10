module FUI.Avalonia.Decorator

open Avalonia
open Avalonia.Controls
open FUI.Avalonia.Patcher
open FUI.Avalonia.Control

type DecoratorBuilder<'t when 't :> Decorator and 't : equality>() =
    inherit ControlBuilder<'t>()
        
    member this.Run x =
        this.RunWithChild x (fun control child ->
            match child with
            | :? IControl as child -> control.Child <- child
            | _ -> printfn "Child of Decorator must be of type IControl")
        
    /// Thickness | ObservableValue<Thickness>
    [<CustomOperation("padding")>]
    member _.padding<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x Decorator.PaddingProperty value