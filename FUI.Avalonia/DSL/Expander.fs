module FUI.Avalonia.Expander

open Avalonia.Animation
open Avalonia.Controls
open FUI.Avalonia.HeaderedContentControl

type ExpanderBuilder<'t when 't :> Expander and 't : equality>() =
    inherit HeaderedContentControlBuilder<'t>()

    /// IPageTransition | ObservableValue<IPageTransition>
    [<CustomOperation("contentTransition")>]
    member _.contentTransition<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Expander.ContentTransitionProperty value

    /// ExpandDirection | ObservableValue<ExpandDirection>
    [<CustomOperation("expandDirection")>]
    member _.expandDirection<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Expander.ExpandDirectionProperty value

    /// bool | ObservableValue<bool>
    [<CustomOperation("isExpanded")>]
    member _.isExpanded<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Expander.IsExpandedProperty value

    [<CustomOperation("onIsExpandedChanged")>]
    member _.onIsExpandedChanged<'t, 'v>(x, func: bool -> unit) =
        Types.dependencyPropertyEvent x Expander.IsExpandedProperty func
