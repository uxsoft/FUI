module Avalonia.FuncUI.Experiments.DSL.Panel

open Avalonia.Controls
open FUI.UiBuilder
open Avalonia.FuncUI.Types
open Avalonia.FuncUI.Builder
open Avalonia.Media
open Avalonia.FuncUI.Experiments.DSL.Control

type PanelBuilder<'t when 't :> Panel>() =
    inherit ControlBuilder<'t>()
    
    override _.Flatten x =
        let views = x.Children |> List.choose (function | :? IView as view -> Some view | _ -> None)
        let getter : ('t -> obj) = (fun control -> control.Children :> obj)
        let childrenProp = AttrBuilder<'t>.CreateContentMultiple("Children", ValueSome getter, ValueNone, views)
        x.Attributes @ [ childrenProp ]
            
    [<CustomOperation("background")>]
    member _.background<'t>(x: Node<_, _>, value: IBrush) =
        Types.dependencyProperty<IBrush>(Panel.BackgroundProperty, value, ValueNone) ]
        