module FUI.Avalonia.Expander

open Avalonia.Animation
open Avalonia.Controls
open FUI.Avalonia.HeaderedContentControl

type ExpanderBuilder<'t when 't :> Expander and 't : equality>() =
    inherit HeaderedContentControlBuilder<'t>()

    [<CustomOperation("contentTransition")>]
    member _.contentTransition<'t>(x: Types.AvaloniaNode<'t>, value: IPageTransition) =
        Types.dependencyProperty x Expander.ContentTransitionProperty value

    [<CustomOperation("expandDirection")>]
    member _.expandDirection<'t>(x: Types.AvaloniaNode<'t>, value: ExpandDirection) =
        Types.dependencyProperty x Expander.ExpandDirectionProperty value

    [<CustomOperation("isExpanded")>]
    member _.isExpanded<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x Expander.IsExpandedProperty value

    [<CustomOperation("onIsExpandedChanged")>]
    member _.onIsExpandedChanged<'t>(x: Types.AvaloniaNode<'t>, func: bool -> unit) =
        Types.dependencyPropertyEvent x Expander.IsExpandedProperty func
