module Avalonia.FuncUI.Experiments.DSL.Control
  
open Avalonia.Controls
open Avalonia.Controls.Primitives
open FUI.UiBuilder
open Avalonia.FuncUI.Experiments.DSL.InputElement
open Avalonia.FuncUI.Builder
open Avalonia.FuncUI.Types
open Avalonia.Visuals.Media.Imaging

type ControlBuilder<'t when 't :> Control>() =
    inherit InputElementBuilder<'t>()
    
    [<CustomOperation("focusAdorner")>] 
    member _.focusAdorner<'t, 'c when 'c :> IControl>(x: Node<_, _>, value: ITemplate<'c>) =
        x @@ [  AttrBuilder<'t>.CreateProperty<ITemplate<'c>>(Control.FocusAdornerProperty, value, ValueNone) ]
                                                      
    [<CustomOperation("tag")>]
    member _.tag<'t>(x: Node<_, _>, value: obj) =
        x @@ [  AttrBuilder<'t>.CreateProperty<obj>(Control.TagProperty, value, ValueNone) ]
    
    [<CustomOperation("contextMenu")>] 
    member _.contextMenu<'t>(x: Node<_, _>, menu: ContextMenu) =
        x @@ [  AttrBuilder<'t>.CreateProperty<ContextMenu>(Control.ContextMenuProperty, menu, ValueNone) ]
    
    [<CustomOperation("bitmapInterpolationMode")>]
    member _.bitmapInterpolationMode<'t>(x: Node<_, _>, mode: BitmapInterpolationMode) =
        x @@ [  AttrBuilder<'t>.CreateProperty<BitmapInterpolationMode>(Avalonia.Media.RenderOptions.BitmapInterpolationModeProperty, mode, ValueNone) ]
    
    [<CustomOperation("dock")>]
    member _.dock<'t>(x: Node<_, _>, dock: Dock) =
        Types.dependencyProperty<Dock>(DockPanel.DockProperty, dock, ValueNone) ]
        
    [<CustomOperation("left")>] 
    member _.left<'t>(x: Node<_, _>, value: double) =
        Types.dependencyProperty<double>(Canvas.LeftProperty, value, ValueNone) ]
        
    [<CustomOperation("top")>] 
    member _.top<'t>(x: Node<_, _>, value: double) =
        Types.dependencyProperty<double>(Canvas.TopProperty, value, ValueNone) ]
        
    [<CustomOperation("right")>] 
    member _.right<'t>(x: Node<_, _>, value: double) =
        Types.dependencyProperty<double>(Canvas.RightProperty, value, ValueNone) ]
        
    [<CustomOperation("bottom")>] 
    member _.bottom<'t>(x: Node<_, _>, value: double) =
        Types.dependencyProperty<double>(Canvas.BottomProperty, value, ValueNone) ]
        
    [<CustomOperation("row")>] 
    member _.row<'t>(x: Node<_, _>, row: int) =
        Types.dependencyProperty<int>(Grid.RowProperty, row, ValueNone) ]
        
    [<CustomOperation("rowSpan")>] 
    member _.rowSpan<'t>(x: Node<_, _>, span: int) =
        Types.dependencyProperty<int>(Grid.RowSpanProperty, span, ValueNone) ]
        
    [<CustomOperation("column")>] 
    member _.column<'t>(x: Node<_, _>, column: int) =
        Types.dependencyProperty<int>(Grid.ColumnProperty, column, ValueNone) ]
        
    [<CustomOperation("columnSpan")>] 
    member _.columnSpan<'t>(x: Node<_, _>, span: int) =
        Types.dependencyProperty<int>(Grid.ColumnSpanProperty, span, ValueNone) ]
        
    [<CustomOperation("isSharedSizeScope")>] 
    member _.isSharedSizeScope<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(Grid.IsSharedSizeScopeProperty, value, ValueNone) ]
        
    [<CustomOperation("showAccessKey")>]
    member _.showAccessKey<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty(AccessText.ShowAccessKeyProperty, value, ValueNone) ]
        
    [<CustomOperation("verticalScrollBarVisibility")>]
    member _.verticalScrollBarVisibility<'t>(x: Node<_, _>, value: ScrollBarVisibility) =
        Types.dependencyProperty<ScrollBarVisibility>(ScrollViewer.VerticalScrollBarVisibilityProperty, value, ValueNone) ]

    /// <summary>
    /// Sets the horizontal scrollbar visibility.
    /// </summary>
    [<CustomOperation("horizontalScrollBarVisibility")>]
    member _.horizontalScrollBarVisibility<'t>(x: Node<_, _>, value: ScrollBarVisibility) =
        Types.dependencyProperty<ScrollBarVisibility>(ScrollViewer.HorizontalScrollBarVisibilityProperty, value, ValueNone) ]


    /// <summary>
    /// A value indicating whether the tool tip is visible.
    /// </summary>
    [<CustomOperation("toolTipIsOpen")>]
    member _.toolTipIsOpen<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(ToolTip.IsOpenProperty, value, ValueNone) ]

    /// <summary>
    /// The content to be displayed in the control's tooltip.
    /// </summary>
    [<CustomOperation("tip")>] 
    member _.tip<'t, 'c when 't :> Control and 'c :> obj>(x: Node<_, _>, value: 'c) =
        let prop = 
            match box value with
            | :? IView as view -> AttrBuilder<'t>.CreateContentSingle(ToolTip.TipProperty, Some view)
            | :? string as text -> AttrBuilder<'t>.CreateProperty<string>(ToolTip.TipProperty, text, ValueNone)
            | _ -> AttrBuilder<'t>.CreateProperty<obj>(ToolTip.TipProperty, value, ValueNone)
        
        x @@ [ prop ]

    /// <summary>
    /// A value indicating how the tool tip is positioned.
    /// </summary>
    [<CustomOperation("toolTipPlacement")>]
    member _.toolTipPlacement<'t>(x: Node<_, _>, value: PlacementMode) =
        Types.dependencyProperty<PlacementMode>(ToolTip.PlacementProperty, value, ValueNone) ]

    /// <summary>
    /// A value indicating how the tool tip is positioned.
    /// </summary>
    [<CustomOperation("toolTipHorizontalOffset")>]
    member _.toolTipHorizontalOffset<'t>(x: Node<_, _>, value: float) =
        Types.dependencyProperty<float>(ToolTip.HorizontalOffsetProperty, value, ValueNone) ]

    /// <summary>
    /// A value indicating how the tool tip is positioned.
    /// </summary>
    [<CustomOperation("toolTipVerticalOffset")>]
    member _.toolTipVerticalOffset<'t>(x: Node<_, _>, value: float) =
        Types.dependencyProperty<float>(ToolTip.VerticalOffsetProperty, value, ValueNone) ]

    /// <summary>
    /// A value indicating the time, in milliseconds, before a tool tip opens.
    /// </summary>
    [<CustomOperation("toolTipShowDelay")>]
    member _.toolTipShowDelay<'t>(x: Node<_, _>, value: int) =
        Types.dependencyProperty<int>(ToolTip.ShowDelayProperty, value, ValueNone) ]
