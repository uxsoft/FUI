module Avalonia.FuncUI.Experiments.DSL.Border

open Avalonia
open Avalonia.Controls
open FUI.UiBuilder
open Avalonia.FuncUI.Experiments.DSL.Decorator
open Avalonia.FuncUI.Builder
open Avalonia.Media

type BorderBuilder<'t when 't :> Border>() =
    inherit DecoratorBuilder<'t>()
    
    [<CustomOperation("background")>] 
    member _.background<'t>(x: Node<_, _>, brush: IBrush) =
        Types.dependencyProperty<IBrush>(Border.BackgroundProperty, brush, ValueNone) ]
        
    [<CustomOperation("borderBrush")>] 
    member _.borderBrush<'t>(x: Node<_, _>, brush: IBrush) =
        Types.dependencyProperty<IBrush>(Border.BorderBrushProperty, brush, ValueNone) ]
        
    [<CustomOperation("borderThickness")>] 
    member _.borderThickness<'t>(x: Node<_, _>, value: Thickness) =
        Types.dependencyProperty<Thickness>(Border.BorderThicknessProperty, value, ValueNone) ]
        
    [<CustomOperation("cornerRadius")>] 
    member _.cornerRadius<'t>(x: Node<_, _>, value: CornerRadius) =
        Types.dependencyProperty<CornerRadius>(Border.CornerRadiusProperty, value, ValueNone) ]
        
    [<CustomOperation("boxShadows")>] 
    member _.boxShadows<'t>(x: Node<_, _>, value: BoxShadows) =
        Types.dependencyProperty(Border.BoxShadowProperty, value, ValueNone) ]