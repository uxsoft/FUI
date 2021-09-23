module Avalonia.FuncUI.Experiments.DSL.LayoutTransformControl

open FUI.UIBuilder
open Avalonia.FuncUI.Experiments.DSL.Decorator
open Avalonia.Media
open Avalonia.Controls
open Avalonia.FuncUI.Builder

type LayoutTransformControlBuilder<'t when 't :> LayoutTransformControl>() =
    inherit DecoratorBuilder<'t>()
    
    [<CustomOperation("layoutTransform")>]
    member _.layoutTransform<'t>(x: Element, value: Transform) =
        x @@ [ AttrBuilder<'t>.CreateProperty<Transform>(LayoutTransformControl.LayoutTransformProperty, value, ValueNone) ]
        
    [<CustomOperation("useRenderTransform")>]
    member _.useRenderTransform<'t>(x: Element, value: bool) =
        x @@ [ AttrBuilder<'t>.CreateProperty<bool>(LayoutTransformControl.UseRenderTransformProperty, value, ValueNone) ]