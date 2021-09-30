module FUI.Avalonia.Border

open Avalonia
open Avalonia.Controls
open FUI.Avalonia.Decorator
open Avalonia.Media

type BorderBuilder<'t when 't :> Border and 't : equality>() =
    inherit DecoratorBuilder<'t>()
    
    [<CustomOperation("background")>] 
    member _.background<'t>(x: Types.AvaloniaNode<'t>, brush: IBrush) =
        Types.dependencyProperty x Border.BackgroundProperty brush
        
    [<CustomOperation("borderBrush")>] 
    member _.borderBrush<'t>(x: Types.AvaloniaNode<'t>, brush: IBrush) =
        Types.dependencyProperty x Border.BorderBrushProperty brush
        
    [<CustomOperation("borderThickness")>] 
    member _.borderThickness<'t>(x: Types.AvaloniaNode<'t>, value: Thickness) =
        Types.dependencyProperty x Border.BorderThicknessProperty value
        
    [<CustomOperation("cornerRadius")>] 
    member _.cornerRadius<'t>(x: Types.AvaloniaNode<'t>, value: CornerRadius) =
        Types.dependencyProperty x Border.CornerRadiusProperty value
        
    [<CustomOperation("boxShadows")>] 
    member _.boxShadows<'t>(x: Types.AvaloniaNode<'t>, value: BoxShadows) =
        Types.dependencyProperty x Border.BoxShadowProperty value