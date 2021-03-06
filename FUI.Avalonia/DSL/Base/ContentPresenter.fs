module FUI.Avalonia.ContentPresenter

open FUI.Avalonia.Patcher
open FUI.Avalonia.Control
open Avalonia.Controls.Presenters

type ContentPresenterBuilder<'t when 't :> ContentPresenter and 't : equality>() =
    inherit ControlBuilder<'t>()
    
    member this.Run x =
        this.RunWithChild<'t> x (fun control child -> control.Content <- child)
    
    /// IBrush | ObservableValue<IBrush>
    [<CustomOperation("background")>]
    member _.background<'t, 'v>(x, brush: 'v) =
        Types.dependencyProperty x ContentPresenter.BackgroundProperty brush

    /// IBrush | ObservableValue<IBrush>
    [<CustomOperation("borderBrush")>]
    member _.borderBrush<'t, 'v>(x, brush: 'v) =
        Types.dependencyProperty x ContentPresenter.BorderBrushProperty brush
        
    /// Thickness | ObservableValue<Thickness>
    [<CustomOperation("borderThickness")>]
    member _.borderThickness<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x ContentPresenter.BorderThicknessProperty value
    
    /// BoxShadows | ObservableValue<BoxShadows>
    [<CustomOperation("boxShadows")>]
    member _.boxShadows<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x ContentPresenter.BoxShadowProperty value
        
    /// CornerRadius | ObservableValue<CornerRadius>
    [<CustomOperation("cornerRadius")>]
    member _.cornerRadius<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x ContentPresenter.CornerRadiusProperty value
        
    /// obj | ObservableValue<obj>
    [<CustomOperation("child")>]
    member _.child<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x ContentPresenter.ChildProperty value

    /// obj | ObservableValue<obj>
    [<CustomOperation("content")>]
    member _.content<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x ContentPresenter.ContentProperty value

    /// IDataTemplate | ObservableValue<IDataTemplate>
    [<CustomOperation("contentTemplate")>]
    member _.contentTemplate<'t, 'v>(x, template: 'v) =
        Types.dependencyProperty x ContentPresenter.ContentTemplateProperty template
        
    /// HorizontalAlignment | ObservableValue<HorizontalAlignment>
    [<CustomOperation("horizontalContentAlignment")>]
    member _.horizontalContentAlignment<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x ContentPresenter.HorizontalContentAlignmentProperty value
        
    /// VerticalAlignment | ObservableValue<VerticalAlignment>
    [<CustomOperation("verticalContentAlignment")>]
    member _.verticalContentAlignment<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x ContentPresenter.VerticalContentAlignmentProperty value
        
    /// Thickness | ObservableValue<Thickness>
    [<CustomOperation("padding")>]
    member _.padding<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x ContentPresenter.PaddingProperty value