module FUI.Avalonia.Expander

open Avalonia.Animation
open Avalonia.Controls
open FUI.UiBuilder
open FUI.Avalonia.HeaderedContentControl
open Avalonia.FuncUI.Builder

type ExpanderBuilder<'t when 't :> Expander>() =
    inherit HeaderedContentControlBuilder<'t>()

    [<CustomOperation("contentTransition")>]
    member _.contentTransition<'t>(x: Types.AvaloniaNode<'t>, value: IPageTransition) =
        Types.dependencyProperty x<IPageTransition>(Expander.ContentTransitionProperty, value, ValueNone) ]

    [<CustomOperation("expandDirection")>]
    member _.expandDirection<'t>(x: Types.AvaloniaNode<'t>, value: ExpandDirection) =
        Types.dependencyProperty x<ExpandDirection>(Expander.ExpandDirectionProperty, value, ValueNone) ]

    [<CustomOperation("isExpanded")>]
    member _.isExpanded<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x<bool>(Expander.IsExpandedProperty, value, ValueNone) ]

    [<CustomOperation("onIsExpandedChanged")>]
    member _.onIsExpandedChanged<'t>(x: Types.AvaloniaNode<'t>, func: bool -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription(Expander.IsExpandedProperty, func) ]
