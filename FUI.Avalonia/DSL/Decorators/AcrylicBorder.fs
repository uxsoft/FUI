module Avalonia.FuncUI.Experiments.DSL.AcrylicBorder

open Avalonia
open Avalonia.Controls
open Avalonia.FuncUI.Builder
open FUI.UiBuilder
open Avalonia.FuncUI.Experiments.DSL.Decorator
open Avalonia.Media

type AcrylicBorderBuilder<'t when 't :> ExperimentalAcrylicBorder>() =
    inherit DecoratorBuilder<'t>()
    
    [<CustomOperation("cornerRadius")>] 
    member _.cornerRadius<'t>(x: Node<_, _>, value: CornerRadius) =
        Types.dependencyProperty<CornerRadius>(ExperimentalAcrylicBorder.CornerRadiusProperty, value, ValueNone) ]
        
    [<CustomOperation("material")>] 
    member _.material<'t>(x: Node<_, _>, value: ExperimentalAcrylicMaterial) =
        Types.dependencyProperty<ExperimentalAcrylicMaterial>(ExperimentalAcrylicBorder.MaterialProperty, value, ValueNone) ]