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
        let setter : 't * obj -> unit = fun (view, value) -> view.ColumnDefinitions <- unbox<ColumnDefinitions> value
        let factory() = ColumnDefinitions() |> box
        Types.property x "ColumnDefinitions" (ColumnDefinitions.Parse value) setter factory

    [<CustomOperation("rowDefinitions")>] 
    member _.rowDefinitions<'t, 'v>(x, value: string) =
        let setter : 't * obj -> unit = fun (view, value) -> view.RowDefinitions <- unbox<RowDefinitions> value
        let factory() = RowDefinitions() |> box
        Types.property x "ColumnDefinitions" (RowDefinitions.Parse value) setter factory