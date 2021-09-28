module Avalonia.FuncUI.Experiments.DSL.Decorator

open Avalonia
open Avalonia.Controls
open FUI.UiBuilder
open Avalonia.FuncUI.Experiments.DSL.Control
open Avalonia.FuncUI.Types
open Avalonia.FuncUI.Builder

type DecoratorBuilder<'t when 't :> Decorator>() =
    inherit ControlBuilder<'t>()
        
    override _.Flatten x =
        match x.Children |> List.tryLast with
        | None -> x.Attributes
        | Some lastChild -> 
            let contentProp =
                match lastChild with
                | :? string as text ->
                    AttrBuilder<'t>.CreateProperty(Decorator.ChildProperty, text, ValueNone)
                | :? IView as view ->
                    AttrBuilder<'t>.CreateContentSingle(Decorator.ChildProperty, Some view)
                | other ->
                    AttrBuilder<'t>.CreateProperty(Decorator.ChildProperty, other, ValueNone)
        
            x.Attributes @ [ contentProp ]
        
    [<CustomOperation("padding")>]
    member _.padding<'t>(x: Node<_, _>, value: Thickness) =
        Types.dependencyProperty<Thickness>(Decorator.PaddingProperty, value, ValueNone) ]