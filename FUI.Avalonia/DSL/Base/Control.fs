module FUI.Avalonia.Control
  
open Avalonia.Controls
open Avalonia.Controls.Primitives
open FUI.Avalonia.InputElement
open FUI.UiBuilder
open FUI.Avalonia
open Avalonia.Visuals.Media.Imaging

type ControlBuilder<'t when 't :> Control and 't : equality>() =
    inherit InputElementBuilder<'t>()
    
    [<CustomOperation("focusAdorner")>] 
    member _.focusAdorner<'t, 'c when 'c :> IControl>(x: Types.AvaloniaNode<'t>, value: ITemplate<'c>) =
        Types.dependencyProperty x Control.FocusAdornerProperty value
                                                      
    [<CustomOperation("tag")>]
    member _.tag<'t>(x: Types.AvaloniaNode<'t>, value: obj) =
        Types.dependencyProperty x Control.TagProperty value
    
    [<CustomOperation("contextMenu")>] 
    member _.contextMenu<'t>(x: Types.AvaloniaNode<'t>, menu: ContextMenu) =
        Types.dependencyProperty x Control.ContextMenuProperty menu
    
    [<CustomOperation("bitmapInterpolationMode")>]
    member _.bitmapInterpolationMode<'t>(x: Types.AvaloniaNode<'t>, mode: BitmapInterpolationMode) =
        Types.dependencyProperty x Avalonia.Media.RenderOptions.BitmapInterpolationModeProperty mode
    
    [<CustomOperation("dock")>]
    member _.dock<'t>(x: Types.AvaloniaNode<'t>, dock: Dock) =
        Types.dependencyProperty x DockPanel.DockProperty dock 
        
    [<CustomOperation("left")>] 
    member _.left<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x Canvas.LeftProperty value 
        
    [<CustomOperation("top")>] 
    member _.top<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x Canvas.TopProperty value 
        
    [<CustomOperation("right")>] 
    member _.right<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x Canvas.RightProperty value 
        
    [<CustomOperation("bottom")>] 
    member _.bottom<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x Canvas.BottomProperty value 
        
    [<CustomOperation("row")>] 
    member _.row<'t>(x: Types.AvaloniaNode<'t>, row: int) =
        Types.dependencyProperty x Grid.RowProperty row 
        
    [<CustomOperation("rowSpan")>] 
    member _.rowSpan<'t>(x: Types.AvaloniaNode<'t>, span: int) =
        Types.dependencyProperty x Grid.RowSpanProperty span 
        
    [<CustomOperation("column")>] 
    member _.column<'t>(x: Types.AvaloniaNode<'t>, column: int) =
        Types.dependencyProperty x Grid.ColumnProperty column 
        
    [<CustomOperation("columnSpan")>] 
    member _.columnSpan<'t>(x: Types.AvaloniaNode<'t>, span: int) =
        Types.dependencyProperty x Grid.ColumnSpanProperty span 
        
    [<CustomOperation("isSharedSizeScope")>] 
    member _.isSharedSizeScope<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x Grid.IsSharedSizeScopeProperty value 
        
    [<CustomOperation("showAccessKey")>]
    member _.showAccessKey<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x AccessText.ShowAccessKeyProperty value 
        
    [<CustomOperation("verticalScrollBarVisibility")>]
    member _.verticalScrollBarVisibility<'t>(x: Types.AvaloniaNode<'t>, value: ScrollBarVisibility) =
        Types.dependencyProperty x ScrollViewer.VerticalScrollBarVisibilityProperty value 

    /// <summary>
    /// Sets the horizontal scrollbar visibility.
    /// </summary>
    [<CustomOperation("horizontalScrollBarVisibility")>]
    member _.horizontalScrollBarVisibility<'t>(x: Types.AvaloniaNode<'t>, value: ScrollBarVisibility) =
        Types.dependencyProperty x ScrollViewer.HorizontalScrollBarVisibilityProperty value 


    /// <summary>
    /// A value indicating whether the tool tip is visible.
    /// </summary>
    [<CustomOperation("toolTipIsOpen")>]
    member _.toolTipIsOpen<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x ToolTip.IsOpenProperty value 

    /// <summary>
    /// The content to be displayed in the control's tooltip.
    /// </summary>
    [<CustomOperation("tip")>] 
    member _.tip<'t, 'c when 't :> Control and 'c :> obj>(x: Types.AvaloniaNode<'t>, value: 'c) =
        Types.dependencyProperty x ToolTip.TipProperty value

    /// <summary>
    /// A value indicating how the tool tip is positioned.
    /// </summary>
    [<CustomOperation("toolTipPlacement")>]
    member _.toolTipPlacement<'t>(x: Types.AvaloniaNode<'t>, value: PlacementMode) =
        Types.dependencyProperty x ToolTip.PlacementProperty value 

    /// <summary>
    /// A value indicating how the tool tip is positioned.
    /// </summary>
    [<CustomOperation("toolTipHorizontalOffset")>]
    member _.toolTipHorizontalOffset<'t>(x: Types.AvaloniaNode<'t>, value: float) =
        Types.dependencyProperty x ToolTip.HorizontalOffsetProperty value 

    /// <summary>
    /// A value indicating how the tool tip is positioned.
    /// </summary>
    [<CustomOperation("toolTipVerticalOffset")>]
    member _.toolTipVerticalOffset<'t>(x: Types.AvaloniaNode<'t>, value: float) =
        Types.dependencyProperty x ToolTip.VerticalOffsetProperty value 

    /// <summary>
    /// A value indicating the time, in milliseconds, before a tool tip opens.
    /// </summary>
    [<CustomOperation("toolTipShowDelay")>]
    member _.toolTipShowDelay<'t>(x: Types.AvaloniaNode<'t>, value: int) =
        Types.dependencyProperty x ToolTip.ShowDelayProperty value 
