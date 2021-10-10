module FUI.Avalonia.Border

open Avalonia
open Avalonia.Controls
open FUI.Avalonia.Decorator
open Avalonia.Media

type BorderBuilder<'t when 't :> Border and 't : equality>() =
    inherit DecoratorBuilder<'t>()
    
    /// IBrush | ObservableValue<IBrush>
    [<CustomOperation("background")>] 
    member _.background<'t, 'v>(x: Types.AvaloniaNode<'t>, brush: 'v) =
        Types.dependencyProperty x Border.BackgroundProperty brush
        
    /// IBrush | ObservableValue<IBrush>
    [<CustomOperation("borderBrush")>] 
    member _.borderBrush<'t, 'v>(x: Types.AvaloniaNode<'t>, brush: 'v) =
        Types.dependencyProperty x Border.BorderBrushProperty brush
        
    /// Thickness | ObservableValue<Thickness>
    [<CustomOperation("borderThickness")>] 
    member _.borderThickness<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x Border.BorderThicknessProperty value
        
    /// CornerRadius | ObservableValue<CornerRadius>
    [<CustomOperation("cornerRadius")>] 
    member _.cornerRadius<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x Border.CornerRadiusProperty value
        
    /// BoxShadows | ObservableValue<BoxShadows>
    [<CustomOperation("boxShadows")>] 
    member _.boxShadows<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x Border.BoxShadowProperty value