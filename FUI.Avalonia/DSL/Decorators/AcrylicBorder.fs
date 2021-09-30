module FUI.Avalonia.AcrylicBorder

open Avalonia
open Avalonia.Controls
open FUI.Avalonia.Decorator
open Avalonia.Media

type AcrylicBorderBuilder<'t when 't :> ExperimentalAcrylicBorder and 't : equality>() =
    inherit DecoratorBuilder<'t>()
    
    [<CustomOperation("cornerRadius")>] 
    member _.cornerRadius<'t>(x: Types.AvaloniaNode<'t>, value: CornerRadius) =
        Types.dependencyProperty x ExperimentalAcrylicBorder.CornerRadiusProperty value
        
    [<CustomOperation("material")>] 
    member _.material<'t>(x: Types.AvaloniaNode<'t>, value: ExperimentalAcrylicMaterial) =
        Types.dependencyProperty x ExperimentalAcrylicBorder.MaterialProperty value