module FUI.Avalonia.LayoutTransformControl

open FUI.Avalonia.Decorator
open Avalonia.Media
open Avalonia.Controls

type LayoutTransformControlBuilder<'t when 't :> LayoutTransformControl and 't : equality>() =
    inherit DecoratorBuilder<'t>()
    
    [<CustomOperation("layoutTransform")>]
    member _.layoutTransform<'t>(x: Types.AvaloniaNode<'t>, value: Transform) =
        Types.dependencyProperty x LayoutTransformControl.LayoutTransformProperty value
        
    [<CustomOperation("useRenderTransform")>]
    member _.useRenderTransform<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x LayoutTransformControl.UseRenderTransformProperty value