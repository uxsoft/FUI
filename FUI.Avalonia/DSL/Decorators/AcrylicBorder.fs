module FUI.Avalonia.AcrylicBorder

open Avalonia
open Avalonia.Controls
open FUI.Avalonia.Decorator
open Avalonia.Media

type AcrylicBorderBuilder<'t when 't :> ExperimentalAcrylicBorder and 't : equality>() =
    inherit DecoratorBuilder<'t>()
    
    /// CornerRadius | ObservableValue<CornerRadius>
    [<CustomOperation("cornerRadius")>] 
    member _.cornerRadius<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x ExperimentalAcrylicBorder.CornerRadiusProperty value
        
    /// ExperimentalAcrylicMaterial | ObservableValue<ExperimentalAcrylicMaterial>
    [<CustomOperation("material")>] 
    member _.material<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x ExperimentalAcrylicBorder.MaterialProperty value