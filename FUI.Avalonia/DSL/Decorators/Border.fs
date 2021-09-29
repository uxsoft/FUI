module FUI.Avalonia.Border

open Avalonia
open Avalonia.Controls
open FUI.UiBuilder
open FUI.Avalonia.Decorator
open Avalonia.FuncUI.Builder
open Avalonia.Media

type BorderBuilder<'t when 't :> Border>() =
    inherit DecoratorBuilder<'t>()
    
    [<CustomOperation("background")>] 
    member _.background<'t>(x: Types.AvaloniaNode<'t>, brush: IBrush) =
        Types.dependencyProperty x<IBrush>(Border.BackgroundProperty, brush, ValueNone) ]
        
    [<CustomOperation("borderBrush")>] 
    member _.borderBrush<'t>(x: Types.AvaloniaNode<'t>, brush: IBrush) =
        Types.dependencyProperty x<IBrush>(Border.BorderBrushProperty, brush, ValueNone) ]
        
    [<CustomOperation("borderThickness")>] 
    member _.borderThickness<'t>(x: Types.AvaloniaNode<'t>, value: Thickness) =
        Types.dependencyProperty x<Thickness>(Border.BorderThicknessProperty, value, ValueNone) ]
        
    [<CustomOperation("cornerRadius")>] 
    member _.cornerRadius<'t>(x: Types.AvaloniaNode<'t>, value: CornerRadius) =
        Types.dependencyProperty x<CornerRadius>(Border.CornerRadiusProperty, value, ValueNone) ]
        
    [<CustomOperation("boxShadows")>] 
    member _.boxShadows<'t>(x: Types.AvaloniaNode<'t>, value: BoxShadows) =
        Types.dependencyProperty x(Border.BoxShadowProperty, value, ValueNone) ]