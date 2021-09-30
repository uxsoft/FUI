module FUI.Avalonia.UniformGrid

open Avalonia.Controls.Primitives
open FUI.Avalonia.Panel

type UniformGridBuilder<'t when 't :> UniformGrid and 't : equality>() =
    inherit PanelBuilder<'t>() 

    /// <summary>
    /// Specifies the column count. If set to 0, column count will be calculated automatically.
    /// </summary>
    [<CustomOperation("columns")>] 
    member _.columns<'t>(x: Types.AvaloniaNode<'t>, value: int) =
        Types.dependencyProperty x UniformGrid.ColumnsProperty value

    /// <summary>
    /// Specifies the row count. If set to 0, row count will be calculated automatically.
    /// </summary>
    [<CustomOperation("rows")>] 
    member _.rows<'t>(x: Types.AvaloniaNode<'t>, value: int) =
        Types.dependencyProperty x UniformGrid.RowsProperty value
       
    /// <summary>
    /// Specifies, for the first row, the column where the items should start.
    /// </summary>
    [<CustomOperation("firstColumn")>] 
    member _.firstColumn<'t>(x: Types.AvaloniaNode<'t>, value: int) =
        Types.dependencyProperty x UniformGrid.FirstColumnProperty value