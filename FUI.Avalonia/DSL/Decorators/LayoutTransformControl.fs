module FUI.Avalonia.LayoutTransformControl

open FUI.UiBuilder
open FUI.Avalonia.Decorator
open Avalonia.Media
open Avalonia.Controls
open Avalonia.FuncUI.Builder

type LayoutTransformControlBuilder<'t when 't :> LayoutTransformControl>() =
    inherit DecoratorBuilder<'t>()
    
    [<CustomOperation("layoutTransform")>]
    member _.layoutTransform<'t>(x: Types.AvaloniaNode<'t>, value: Transform) =
        Types.dependencyProperty x<Transform>(LayoutTransformControl.LayoutTransformProperty, value, ValueNone) ]
        
    [<CustomOperation("useRenderTransform")>]
    member _.useRenderTransform<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x<bool>(LayoutTransformControl.UseRenderTransformProperty, value, ValueNone) ]