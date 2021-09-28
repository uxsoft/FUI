module Avalonia.FuncUI.Experiments.DSL.ContentPresenter

open Avalonia
open Avalonia.Controls.Templates
open FUI.UiBuilder
open Avalonia.FuncUI.Experiments.DSL.Control
open Avalonia.Layout    
open Avalonia.Controls.Presenters
open Avalonia.FuncUI.Types
open Avalonia.FuncUI.Builder
open Avalonia.Media

type ContentPresenterBuilder<'t when 't :> ContentPresenter>() =
    inherit ControlBuilder<'t>()
    
    [<CustomOperation("background")>]
    member _.background<'t>(x: Node<_, _>, brush: IBrush) =
        x @@ [  AttrBuilder<'t>.CreateProperty<IBrush>(ContentPresenter.BackgroundProperty, brush, ValueNone) ]

    [<CustomOperation("borderBrush")>]
    member _.borderBrush<'t>(x: Node<_, _>, brush: IBrush) =
        x @@ [  AttrBuilder<'t>.CreateProperty<IBrush>(ContentPresenter.BorderBrushProperty, brush, ValueNone) ]
        
    [<CustomOperation("borderThickness")>]
    member _.borderThickness<'t>(x: Node<_, _>, value: Thickness) =
        x @@ [  AttrBuilder<'t>.CreateProperty<Thickness>(ContentPresenter.BorderThicknessProperty, value, ValueNone) ]
    
    [<CustomOperation("boxShadows")>]
    member _.boxShadows<'t>(x: Node<_, _>, value: BoxShadows) =
        x @@ [  AttrBuilder<'t>.CreateProperty(ContentPresenter.BoxShadowProperty, value, ValueNone) ]
        
    [<CustomOperation("cornerRadius")>]
    member _.cornerRadius<'t>(x: Node<_, _>, value: CornerRadius) =
        x @@ [  AttrBuilder<'t>.CreateProperty<CornerRadius>(ContentPresenter.CornerRadiusProperty, value, ValueNone) ]
        
    [<CustomOperation("child")>]
    member _.child<'t>(x: Node<_, _>, value: IView) =
        x @@ [  AttrBuilder<'t>.CreateContentSingle(ContentPresenter.ChildProperty, Some value) ]

    [<CustomOperation("content")>]
    member _.content<'t>(x: Node<_, _>, value: IView) =
        x @@ [  AttrBuilder<'t>.CreateContentSingle(ContentPresenter.ContentProperty, Some value) ]

    [<CustomOperation("contentTemplate")>]
    member _.contentTemplate<'t>(x: Node<_, _>, template: IDataTemplate) =
        x @@ [  AttrBuilder<'t>.CreateProperty<IDataTemplate>(ContentPresenter.ContentTemplateProperty, template, ValueNone) ]
        
    [<CustomOperation("horizontalContentAlignment")>]
    member _.horizontalContentAlignment<'t>(x: Node<_, _>, value: HorizontalAlignment) =
        x @@ [  AttrBuilder<'t>.CreateProperty<HorizontalAlignment>(ContentPresenter.HorizontalContentAlignmentProperty, value, ValueNone) ]
        
    [<CustomOperation("verticalContentAlignment")>]
    member _.verticalContentAlignment<'t>(x: Node<_, _>, value: VerticalAlignment) =
        x @@ [  AttrBuilder<'t>.CreateProperty<VerticalAlignment>(ContentPresenter.VerticalContentAlignmentProperty, value, ValueNone) ]
        
    [<CustomOperation("padding")>]
    member _.padding<'t>(x: Node<_, _>, value: Thickness) =
        x @@ [  AttrBuilder<'t>.CreateProperty<Thickness>(ContentPresenter.PaddingProperty, value, ValueNone) ]
        