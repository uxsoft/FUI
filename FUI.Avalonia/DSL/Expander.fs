module Avalonia.FuncUI.Experiments.DSL.Expander

open Avalonia.Animation
open Avalonia.Controls
open FUI.UiBuilder
open Avalonia.FuncUI.Experiments.DSL.HeaderedContentControl
open Avalonia.FuncUI.Builder

type ExpanderBuilder<'t when 't :> Expander>() =
    inherit HeaderedContentControlBuilder<'t>()

    [<CustomOperation("contentTransition")>]
    member _.contentTransition<'t>(x: Node<_, _>, value: IPageTransition) =
        Types.dependencyProperty<IPageTransition>(Expander.ContentTransitionProperty, value, ValueNone) ]

    [<CustomOperation("expandDirection")>]
    member _.expandDirection<'t>(x: Node<_, _>, value: ExpandDirection) =
        Types.dependencyProperty<ExpandDirection>(Expander.ExpandDirectionProperty, value, ValueNone) ]

    [<CustomOperation("isExpanded")>]
    member _.isExpanded<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(Expander.IsExpandedProperty, value, ValueNone) ]

    [<CustomOperation("onIsExpandedChanged")>]
    member _.onIsExpandedChanged<'t>(x: Node<_, _>, func: bool -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription(Expander.IsExpandedProperty, func) ]
