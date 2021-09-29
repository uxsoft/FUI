module FUI.Avalonia.Control
  
open Avalonia.Controls
open Avalonia.Controls.Primitives
open FUI.Avalonia.InputElement
open FUI.UiBuilder
open FUI.Avalonia
open Avalonia.Visuals.Media.Imaging

type ControlBuilder<'t when 't :> Control>() =
    inherit InputElementBuilder<'t>()
    
    [<CustomOperation("focusAdorner")>] 
    member _.focusAdorner<'t, 'c when 'c :> IControl>(x: Node<_, _>, value: ITemplate<'c>) =
        Types.dependencyProperty Control.FocusAdornerProperty value
                                                      
    [<CustomOperation("tag")>]
    member _.tag<'t>(x: Node<_, _>, value: obj) =
        Types.dependencyProperty Control.TagProperty value
    
    [<CustomOperation("contextMenu")>] 
    member _.contextMenu<'t>(x: Node<_, _>, menu: ContextMenu) =
        Types.dependencyProperty Control.ContextMenuProperty menu
    
    [<CustomOperation("bitmapInterpolationMode")>]
    member _.bitmapInterpolationMode<'t>(x: Node<_, _>, mode: BitmapInterpolationMode) =
        Types.dependencyProperty Avalonia.Media.RenderOptions.BitmapInterpolationModeProperty mode
    
    [<CustomOperation("dock")>]
    member _.dock<'t>(x: Node<_, _>, dock: Dock) =
        Types.dependencyProperty DockPanel.DockProperty dock 
        
    [<CustomOperation("left")>] 
    member _.left<'t>(x: Node<_, _>, value: double) =
        Types.dependencyProperty Canvas.LeftProperty value 
        
    [<CustomOperation("top")>] 
    member _.top<'t>(x: Node<_, _>, value: double) =
        Types.dependencyProperty Canvas.TopProperty value 
        
    [<CustomOperation("right")>] 
    member _.right<'t>(x: Node<_, _>, value: double) =
        Types.dependencyProperty Canvas.RightProperty value 
        
    [<CustomOperation("bottom")>] 
    member _.bottom<'t>(x: Node<_, _>, value: double) =
        Types.dependencyProperty Canvas.BottomProperty value 
        
    [<CustomOperation("row")>] 
    member _.row<'t>(x: Node<_, _>, row: int) =
        Types.dependencyProperty Grid.RowProperty row 
        
    [<CustomOperation("rowSpan")>] 
    member _.rowSpan<'t>(x: Node<_, _>, span: int) =
        Types.dependencyProperty Grid.RowSpanProperty span 
        
    [<CustomOperation("column")>] 
    member _.column<'t>(x: Node<_, _>, column: int) =
        Types.dependencyProperty Grid.ColumnProperty column 
        
    [<CustomOperation("columnSpan")>] 
    member _.columnSpan<'t>(x: Node<_, _>, span: int) =
        Types.dependencyProperty Grid.ColumnSpanProperty span 
        
    [<CustomOperation("isSharedSizeScope")>] 
    member _.isSharedSizeScope<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty Grid.IsSharedSizeScopeProperty value 
        
    [<CustomOperation("showAccessKey")>]
    member _.showAccessKey<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty AccessText.ShowAccessKeyProperty value 
        
    [<CustomOperation("verticalScrollBarVisibility")>]
    member _.verticalScrollBarVisibility<'t>(x: Node<_, _>, value: ScrollBarVisibility) =
        Types.dependencyProperty ScrollViewer.VerticalScrollBarVisibilityProperty value 

    /// <summary>
    /// Sets the horizontal scrollbar visibility.
    /// </summary>
    [<CustomOperation("horizontalScrollBarVisibility")>]
    member _.horizontalScrollBarVisibility<'t>(x: Node<_, _>, value: ScrollBarVisibility) =
        Types.dependencyProperty ScrollViewer.HorizontalScrollBarVisibilityProperty value 


    /// <summary>
    /// A value indicating whether the tool tip is visible.
    /// </summary>
    [<CustomOperation("toolTipIsOpen")>]
    member _.toolTipIsOpen<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty ToolTip.IsOpenProperty value 

    /// <summary>
    /// The content to be displayed in the control's tooltip.
    /// </summary>
    [<CustomOperation("tip")>] 
    member _.tip<'t, 'c when 't :> Control and 'c :> obj>(x: Node<_, _>, value: 'c) =
        Types.dependencyProperty ToolTip.TipProperty value

    /// <summary>
    /// A value indicating how the tool tip is positioned.
    /// </summary>
    [<CustomOperation("toolTipPlacement")>]
    member _.toolTipPlacement<'t>(x: Node<_, _>, value: PlacementMode) =
        Types.dependencyProperty ToolTip.PlacementProperty value 

    /// <summary>
    /// A value indicating how the tool tip is positioned.
    /// </summary>
    [<CustomOperation("toolTipHorizontalOffset")>]
    member _.toolTipHorizontalOffset<'t>(x: Node<_, _>, value: float) =
        Types.dependencyProperty ToolTip.HorizontalOffsetProperty value 

    /// <summary>
    /// A value indicating how the tool tip is positioned.
    /// </summary>
    [<CustomOperation("toolTipVerticalOffset")>]
    member _.toolTipVerticalOffset<'t>(x: Node<_, _>, value: float) =
        Types.dependencyProperty ToolTip.VerticalOffsetProperty value 

    /// <summary>
    /// A value indicating the time, in milliseconds, before a tool tip opens.
    /// </summary>
    [<CustomOperation("toolTipShowDelay")>]
    member _.toolTipShowDelay<'t>(x: Node<_, _>, value: int) =
        Types.dependencyProperty ToolTip.ShowDelayProperty value 
