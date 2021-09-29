module FUI.Avalonia.ContentPresenter

open Avalonia
open Avalonia.Controls.Templates
open FUI.Avalonia.Patcher
open FUI.Avalonia.Control
open Avalonia.Layout    
open Avalonia.Controls.Presenters
open Avalonia.Media

type ContentPresenterBuilder<'t when 't :> ContentPresenter and 't : equality>() =
    inherit ControlBuilder<'t>()
    
    member this.Run x =
        this.RunWithChild x (fun control child -> control.Content <- child)
    
    [<CustomOperation("background")>]
    member _.background<'t>(x: Types.AvaloniaNode<'t>, brush: IBrush) =
        Types.dependencyProperty x ContentPresenter.BackgroundProperty brush

    [<CustomOperation("borderBrush")>]
    member _.borderBrush<'t>(x: Types.AvaloniaNode<'t>, brush: IBrush) =
        Types.dependencyProperty x ContentPresenter.BorderBrushProperty brush
        
    [<CustomOperation("borderThickness")>]
    member _.borderThickness<'t>(x: Types.AvaloniaNode<'t>, value: Thickness) =
        Types.dependencyProperty x ContentPresenter.BorderThicknessProperty value
    
    [<CustomOperation("boxShadows")>]
    member _.boxShadows<'t>(x: Types.AvaloniaNode<'t>, value: BoxShadows) =
        Types.dependencyProperty x ContentPresenter.BoxShadowProperty value
        
    [<CustomOperation("cornerRadius")>]
    member _.cornerRadius<'t>(x: Types.AvaloniaNode<'t>, value: CornerRadius) =
        Types.dependencyProperty x ContentPresenter.CornerRadiusProperty value
        
    [<CustomOperation("child")>]
    member _.child<'t, 'c>(x: Types.AvaloniaNode<'t>, value: 'c) =
        Types.dependencyProperty x ContentPresenter.ChildProperty value

    [<CustomOperation("content")>]
    member _.content<'t, 'c>(x: Types.AvaloniaNode<'t>, value: 'c) =
        Types.dependencyProperty x ContentPresenter.ContentProperty value

    [<CustomOperation("contentTemplate")>]
    member _.contentTemplate<'t>(x: Types.AvaloniaNode<'t>, template: IDataTemplate) =
        Types.dependencyProperty x ContentPresenter.ContentTemplateProperty template
        
    [<CustomOperation("horizontalContentAlignment")>]
    member _.horizontalContentAlignment<'t>(x: Types.AvaloniaNode<'t>, value: HorizontalAlignment) =
        Types.dependencyProperty x ContentPresenter.HorizontalContentAlignmentProperty value
        
    [<CustomOperation("verticalContentAlignment")>]
    member _.verticalContentAlignment<'t>(x: Types.AvaloniaNode<'t>, value: VerticalAlignment) =
        Types.dependencyProperty x ContentPresenter.VerticalContentAlignmentProperty value
        
    [<CustomOperation("padding")>]
    member _.padding<'t>(x: Types.AvaloniaNode<'t>, value: Thickness) =
        Types.dependencyProperty x ContentPresenter.PaddingProperty value