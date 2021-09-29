module FUI.Avalonia.LayoutTransformControl

open FUI.UiBuilder
open FUI.Avalonia.Decorator
open Avalonia.Media
open Avalonia.Controls
open Avalonia.FuncUI.Builder

type LayoutTransformControlBuilder<'t when 't :> LayoutTransformControl>() =
    inherit DecoratorBuilder<'t>()
    
    [<CustomOperation("layoutTransform")>]
    member _.layoutTransform<'t>(x: Node<_, _>, value: Transform) =
        Types.dependencyProperty<Transform>(LayoutTransformControl.LayoutTransformProperty, value, ValueNone) ]
        
    [<CustomOperation("useRenderTransform")>]
    member _.useRenderTransform<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(LayoutTransformControl.UseRenderTransformProperty, value, ValueNone) ]