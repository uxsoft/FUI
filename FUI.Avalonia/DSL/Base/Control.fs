module Avalonia.FuncUI.Experiments.DSL.Control
  
open Avalonia.Controls
open Avalonia.Controls.Primitives
open FUI.UIBuilder
open Avalonia.FuncUI.Experiments.DSL.InputElement
open Avalonia.FuncUI.Builder
open Avalonia.FuncUI.Types
open Avalonia.Visuals.Media.Imaging

type ControlBuilder<'t when 't :> Control>() =
    inherit InputElementBuilder<'t>()
    
    [<CustomOperation("focusAdorner")>] 
    member _.focusAdorner<'t, 'c when 'c :> IControl>(x: Element, value: ITemplate<'c>) =
        x @@ [  AttrBuilder<'t>.CreateProperty<ITemplate<'c>>(Control.FocusAdornerProperty, value, ValueNone) ]
                                                      
    [<CustomOperation("tag")>]
    member _.tag<'t>(x: Element, value: obj) =
        x @@ [  AttrBuilder<'t>.CreateProperty<obj>(Control.TagProperty, value, ValueNone) ]
    
    [<CustomOperation("contextMenu")>] 
    member _.contextMenu<'t>(x: Element, menu: ContextMenu) =
        x @@ [  AttrBuilder<'t>.CreateProperty<ContextMenu>(Control.ContextMenuProperty, menu, ValueNone) ]
    
    [<CustomOperation("bitmapInterpolationMode")>]
    member _.bitmapInterpolationMode<'t>(x: Element, mode: BitmapInterpolationMode) =
        x @@ [  AttrBuilder<'t>.CreateProperty<BitmapInterpolationMode>(Avalonia.Media.RenderOptions.BitmapInterpolationModeProperty, mode, ValueNone) ]
    
    [<CustomOperation("dock")>]
    member _.dock<'t>(x: Element, dock: Dock) =
        x @@ [ AttrBuilder<'t>.CreateProperty<Dock>(DockPanel.DockProperty, dock, ValueNone) ]
        
    [<CustomOperation("left")>] 
    member _.left<'t>(x: Element, value: double) =
        x @@ [ AttrBuilder<'t>.CreateProperty<double>(Canvas.LeftProperty, value, ValueNone) ]
        
    [<CustomOperation("top")>] 
    member _.top<'t>(x: Element, value: double) =
        x @@ [ AttrBuilder<'t>.CreateProperty<double>(Canvas.TopProperty, value, ValueNone) ]
        
    [<CustomOperation("right")>] 
    member _.right<'t>(x: Element, value: double) =
        x @@ [ AttrBuilder<'t>.CreateProperty<double>(Canvas.RightProperty, value, ValueNone) ]
        
    [<CustomOperation("bottom")>] 
    member _.bottom<'t>(x: Element, value: double) =
        x @@ [ AttrBuilder<'t>.CreateProperty<double>(Canvas.BottomProperty, value, ValueNone) ]
        
    [<CustomOperation("row")>] 
    member _.row<'t>(x: Element, row: int) =
        x @@ [ AttrBuilder<'t>.CreateProperty<int>(Grid.RowProperty, row, ValueNone) ]
        
    [<CustomOperation("rowSpan")>] 
    member _.rowSpan<'t>(x: Element, span: int) =
        x @@ [ AttrBuilder<'t>.CreateProperty<int>(Grid.RowSpanProperty, span, ValueNone) ]
        
    [<CustomOperation("column")>] 
    member _.column<'t>(x: Element, column: int) =
        x @@ [ AttrBuilder<'t>.CreateProperty<int>(Grid.ColumnProperty, column, ValueNone) ]
        
    [<CustomOperation("columnSpan")>] 
    member _.columnSpan<'t>(x: Element, span: int) =
        x @@ [ AttrBuilder<'t>.CreateProperty<int>(Grid.ColumnSpanProperty, span, ValueNone) ]
        
    [<CustomOperation("isSharedSizeScope")>] 
    member _.isSharedSizeScope<'t>(x: Element, value: bool) =
        x @@ [ AttrBuilder<'t>.CreateProperty<bool>(Grid.IsSharedSizeScopeProperty, value, ValueNone) ]
        
    [<CustomOperation("showAccessKey")>]
    member _.showAccessKey<'t>(x: Element, value: bool) =
        x @@ [ AttrBuilder<'t>.CreateProperty(AccessText.ShowAccessKeyProperty, value, ValueNone) ]
        
    [<CustomOperation("verticalScrollBarVisibility")>]
    member _.verticalScrollBarVisibility<'t>(x: Element, value: ScrollBarVisibility) =
        x @@ [ AttrBuilder<'t>.CreateProperty<ScrollBarVisibility>(ScrollViewer.VerticalScrollBarVisibilityProperty, value, ValueNone) ]

    /// <summary>
    /// Sets the horizontal scrollbar visibility.
    /// </summary>
    [<CustomOperation("horizontalScrollBarVisibility")>]
    member _.horizontalScrollBarVisibility<'t>(x: Element, value: ScrollBarVisibility) =
        x @@ [ AttrBuilder<'t>.CreateProperty<ScrollBarVisibility>(ScrollViewer.HorizontalScrollBarVisibilityProperty, value, ValueNone) ]


    /// <summary>
    /// A value indicating whether the tool tip is visible.
    /// </summary>
    [<CustomOperation("toolTipIsOpen")>]
    member _.toolTipIsOpen<'t>(x: Element, value: bool) =
        x @@ [ AttrBuilder<'t>.CreateProperty<bool>(ToolTip.IsOpenProperty, value, ValueNone) ]

    /// <summary>
    /// The content to be displayed in the control's tooltip.
    /// </summary>
    [<CustomOperation("tip")>] 
    member _.tip<'t, 'c when 't :> Control and 'c :> obj>(x: Element, value: 'c) =
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
    member _.toolTipPlacement<'t>(x: Element, value: PlacementMode) =
        x @@ [ AttrBuilder<'t>.CreateProperty<PlacementMode>(ToolTip.PlacementProperty, value, ValueNone) ]

    /// <summary>
    /// A value indicating how the tool tip is positioned.
    /// </summary>
    [<CustomOperation("toolTipHorizontalOffset")>]
    member _.toolTipHorizontalOffset<'t>(x: Element, value: float) =
        x @@ [ AttrBuilder<'t>.CreateProperty<float>(ToolTip.HorizontalOffsetProperty, value, ValueNone) ]

    /// <summary>
    /// A value indicating how the tool tip is positioned.
    /// </summary>
    [<CustomOperation("toolTipVerticalOffset")>]
    member _.toolTipVerticalOffset<'t>(x: Element, value: float) =
        x @@ [ AttrBuilder<'t>.CreateProperty<float>(ToolTip.VerticalOffsetProperty, value, ValueNone) ]

    /// <summary>
    /// A value indicating the time, in milliseconds, before a tool tip opens.
    /// </summary>
    [<CustomOperation("toolTipShowDelay")>]
    member _.toolTipShowDelay<'t>(x: Element, value: int) =
        x @@ [ AttrBuilder<'t>.CreateProperty<int>(ToolTip.ShowDelayProperty, value, ValueNone) ]
