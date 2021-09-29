module FUI.Avalonia.ContentPresenter

open Avalonia
open Avalonia.Controls.Templates
open FUI.UiBuilder
open FUI.Avalonia.Control
open Avalonia.Layout    
open Avalonia.Controls.Presenters
open Avalonia.Media

type ContentPresenterBuilder<'t when 't :> ContentPresenter>() =
    inherit ControlBuilder<'t>()
    
    member this.Run x =
        this.RunWithChild x (fun control child -> control.Content <- child)
    
    [<CustomOperation("background")>]
    member _.background<'t>(x: Node<_, _>, brush: IBrush) =
        Types.dependencyProperty ContentPresenter.BackgroundProperty brush

    [<CustomOperation("borderBrush")>]
    member _.borderBrush<'t>(x: Node<_, _>, brush: IBrush) =
        Types.dependencyProperty ContentPresenter.BorderBrushProperty brush
        
    [<CustomOperation("borderThickness")>]
    member _.borderThickness<'t>(x: Node<_, _>, value: Thickness) =
        Types.dependencyProperty ContentPresenter.BorderThicknessProperty value
    
    [<CustomOperation("boxShadows")>]
    member _.boxShadows<'t>(x: Node<_, _>, value: BoxShadows) =
        Types.dependencyProperty ContentPresenter.BoxShadowProperty value
        
    [<CustomOperation("cornerRadius")>]
    member _.cornerRadius<'t>(x: Node<_, _>, value: CornerRadius) =
        Types.dependencyProperty ContentPresenter.CornerRadiusProperty value
        
    [<CustomOperation("child")>]
    member _.child<'t>(x: Node<_, _>, value: 'c) =
        Types.dependencyProperty ContentPresenter.ChildProperty value

    [<CustomOperation("content")>]
    member _.content<'t>(x: Node<_, _>, value: 'c) =
        Types.dependencyProperty ContentPresenter.ContentProperty value

    [<CustomOperation("contentTemplate")>]
    member _.contentTemplate<'t>(x: Node<_, _>, template: IDataTemplate) =
        Types.dependencyProperty ContentPresenter.ContentTemplateProperty template
        
    [<CustomOperation("horizontalContentAlignment")>]
    member _.horizontalContentAlignment<'t>(x: Node<_, _>, value: HorizontalAlignment) =
        Types.dependencyProperty ContentPresenter.HorizontalContentAlignmentProperty value
        
    [<CustomOperation("verticalContentAlignment")>]
    member _.verticalContentAlignment<'t>(x: Node<_, _>, value: VerticalAlignment) =
        Types.dependencyProperty ContentPresenter.VerticalContentAlignmentProperty value
        
    [<CustomOperation("padding")>]
    member _.padding<'t>(x: Node<_, _>, value: Thickness) =
        Types.dependencyProperty ContentPresenter.PaddingProperty value