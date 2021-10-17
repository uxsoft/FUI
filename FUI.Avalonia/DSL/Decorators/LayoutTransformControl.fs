module FUI.Avalonia.LayoutTransformControl

open FUI.Avalonia.Decorator
open Avalonia.Media
open Avalonia.Controls

type LayoutTransformControlBuilder<'t when 't :> LayoutTransformControl and 't : equality>() =
    inherit DecoratorBuilder<'t>()
    
    /// Transform | ObservableValue<Transform>
    [<CustomOperation("layoutTransform")>]
    member _.layoutTransform<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x LayoutTransformControl.LayoutTransformProperty value
    
    /// bool | ObservableValue<bool>
    [<CustomOperation("useRenderTransform")>]
    member _.useRenderTransform<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x LayoutTransformControl.UseRenderTransformProperty value