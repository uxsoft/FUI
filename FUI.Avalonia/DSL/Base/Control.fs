module FUI.Avalonia.Control
  
open Avalonia.Controls
open Avalonia.Controls.Primitives
open FUI.Avalonia.InputElement
open FUI.Avalonia.Patcher
open FUI.Avalonia

type ControlBuilder<'t when 't :> Control and 't : equality>() =
    inherit InputElementBuilder<'t>()
    
    member this.Run x =
        this.RunChildless<'t> x
    
    /// ITemplate<IControl> | ObservableValue<ITemplate<IControl>>
    [<CustomOperation("focusAdorner")>] 
    member _.focusAdorner<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Control.FocusAdornerProperty value
                          
    /// obj | ObservableValue<obj>                            
    [<CustomOperation("tag")>]
    member _.tag<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Control.TagProperty value
    
    /// ContextMenu | ObservableValue<ContextMenu>
    [<CustomOperation("contextMenu")>] 
    member _.contextMenu<'t, 'v>(x, menu: 'v) =
        Types.dependencyProperty x Control.ContextMenuProperty menu
    
    /// BitmapInterpolationMode | ObservableValue<BitmapInterpolationMode>
    [<CustomOperation("bitmapInterpolationMode")>]
    member _.bitmapInterpolationMode<'t, 'v>(x, mode: 'v) =
        Types.dependencyProperty x Avalonia.Media.RenderOptions.BitmapInterpolationModeProperty mode
    
    /// Dock | ObservableValue<Dock>
    [<CustomOperation("dock")>]
    member _.dock<'t, 'v>(x, dock: 'v) =
        Types.dependencyProperty x DockPanel.DockProperty dock 
        
    /// double | ObservableValue<double>
    [<CustomOperation("left")>] 
    member _.left<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Canvas.LeftProperty value 
        
    /// double | ObservableValue<double>
    [<CustomOperation("top")>] 
    member _.top<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Canvas.TopProperty value 
        
    /// double | ObservableValue<double>
    [<CustomOperation("right")>] 
    member _.right<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Canvas.RightProperty value 
    
    /// double | ObservableValue<double>    
    [<CustomOperation("bottom")>] 
    member _.bottom<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Canvas.BottomProperty value 
        
    /// int | ObservableValue<int>
    [<CustomOperation("row")>] 
    member _.row<'t, 'v>(x, row: 'v) =
        Types.dependencyProperty x Grid.RowProperty row 
        
    /// int | ObservableValue<int>
    [<CustomOperation("rowSpan")>] 
    member _.rowSpan<'t, 'v>(x, span: 'v) =
        Types.dependencyProperty x Grid.RowSpanProperty span 
        
    /// int | ObservableValue<int>
    [<CustomOperation("column")>] 
    member _.column<'t, 'v>(x, column: 'v) =
        Types.dependencyProperty x Grid.ColumnProperty column 
        
    /// int | ObservableValue<int>
    [<CustomOperation("columnSpan")>] 
    member _.columnSpan<'t, 'v>(x, span: 'v) =
        Types.dependencyProperty x Grid.ColumnSpanProperty span 
        
    /// bool | ObservableValue<bool>
    [<CustomOperation("isSharedSizeScope")>] 
    member _.isSharedSizeScope<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Grid.IsSharedSizeScopeProperty value 
        
    /// bool | ObservableValue<bool>
    [<CustomOperation("showAccessKey")>]
    member _.showAccessKey<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x AccessText.ShowAccessKeyProperty value 
        
    /// ScrollBarVisibility | ObservableValue<ScrollBarVisibility>
    [<CustomOperation("verticalScrollBarVisibility")>]
    member _.verticalScrollBarVisibility<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x ScrollViewer.VerticalScrollBarVisibilityProperty value 

    /// ScrollBarVisibility | ObservableValue<ScrollBarVisibility>
    [<CustomOperation("horizontalScrollBarVisibility")>]
    member _.horizontalScrollBarVisibility<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x ScrollViewer.HorizontalScrollBarVisibilityProperty value 

    /// bool | ObservableValue<bool>
    [<CustomOperation("toolTipIsOpen")>]
    member _.toolTipIsOpen<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x ToolTip.IsOpenProperty value 

    /// obj | ObservableValue<obj>
    [<CustomOperation("tip")>] 
    member _.tip<'t, 'v when 't :> Control>(x, value: 'v) =
        Types.dependencyProperty x ToolTip.TipProperty value

    /// PlacementMode | ObservableValue<PlacementMode>
    [<CustomOperation("toolTipPlacement")>]
    member _.toolTipPlacement<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x ToolTip.PlacementProperty value 

    /// float | ObservableValue<float>
    [<CustomOperation("toolTipHorizontalOffset")>]
    member _.toolTipHorizontalOffset<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x ToolTip.HorizontalOffsetProperty value 

    /// float | ObservableValue<float>
    [<CustomOperation("toolTipVerticalOffset")>]
    member _.toolTipVerticalOffset<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x ToolTip.VerticalOffsetProperty value 

    /// int | ObservableValue<int>
    [<CustomOperation("toolTipShowDelay")>]
    member _.toolTipShowDelay<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x ToolTip.ShowDelayProperty value 

    /// obj seq | ObservableValue<obj seq>
    [<CustomOperation("errors")>]
    member _.errors<'t, 'v>(x, errors: 'v) =
        Types.dependencyProperty x DataValidationErrors.ErrorsProperty errors
        
    /// bool | ObservableValue<bool>
    [<CustomOperation("hasErrors")>]
    member _.hasErrors<'t, 'v>(x, hasErrors: 'v) =
        Types.dependencyProperty x DataValidationErrors.HasErrorsProperty hasErrors