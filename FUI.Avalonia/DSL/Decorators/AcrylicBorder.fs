module FUI.Avalonia.AcrylicBorder

open Avalonia
open Avalonia.Controls
open Avalonia.FuncUI.Builder
open FUI.UiBuilder
open FUI.Avalonia.Decorator
open Avalonia.Media

type AcrylicBorderBuilder<'t when 't :> ExperimentalAcrylicBorder>() =
    inherit DecoratorBuilder<'t>()
    
    [<CustomOperation("cornerRadius")>] 
    member _.cornerRadius<'t>(x: Types.AvaloniaNode<'t>, value: CornerRadius) =
        Types.dependencyProperty x<CornerRadius>(ExperimentalAcrylicBorder.CornerRadiusProperty, value, ValueNone) ]
        
    [<CustomOperation("material")>] 
    member _.material<'t>(x: Types.AvaloniaNode<'t>, value: ExperimentalAcrylicMaterial) =
        Types.dependencyProperty x<ExperimentalAcrylicMaterial>(ExperimentalAcrylicBorder.MaterialProperty, value, ValueNone) ]