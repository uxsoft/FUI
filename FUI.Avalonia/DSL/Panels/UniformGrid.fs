module FUI.Avalonia.UniformGrid

open Avalonia.Controls.Primitives
open FUI.Avalonia.Panel

type UniformGridBuilder<'t when 't :> UniformGrid and 't : equality>() =
    inherit PanelBuilder<'t>() 

    /// int | ObservableValue<int>
    [<CustomOperation("columns")>] 
    member _.columns<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x UniformGrid.ColumnsProperty value

    /// int | ObservableValue<int>
    [<CustomOperation("rows")>] 
    member _.rows<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x UniformGrid.RowsProperty value
    
    /// int | ObservableValue<int>   
    [<CustomOperation("firstColumn")>] 
    member _.firstColumn<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x UniformGrid.FirstColumnProperty value