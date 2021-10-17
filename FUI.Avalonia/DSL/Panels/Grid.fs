module FUI.Avalonia.Grid
  
open Avalonia.Controls
open FUI.Avalonia
open FUI.Avalonia.Panel

type GridBuilder<'t when 't :> Grid and 't : equality>() =
    inherit PanelBuilder<'t>()
    
    /// bool | ObservableValue<bool>
    [<CustomOperation("showGridLines")>] 
    member _.showGridLines<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Grid.ShowGridLinesProperty value

    [<CustomOperation("columnDefinitions")>] 
    member _.columnDefinitions<'t, 'v>(x, value: string) =
        let getter : 't -> obj = fun view -> box view.ColumnDefinitions
        let setter : 't * obj -> unit = fun (view, value) -> view.ColumnDefinitions <- unbox<ColumnDefinitions> value
        
        Types.property x "ColumnDefinitions" (ColumnDefinitions.Parse value) getter setter (fun () -> ColumnDefinitions() :> obj)

    [<CustomOperation("rowDefinitions")>] 
    member _.rowDefinitions<'t, 'v>(x, value: string) =
        let getter : 't -> obj = fun view -> box view.RowDefinitions
        let setter : 't * obj -> unit = fun (view, value) -> view.RowDefinitions <- unbox<RowDefinitions> value
        
        Types.property x "ColumnDefinitions" (RowDefinitions.Parse value) getter setter (fun () -> RowDefinitions() :> obj)