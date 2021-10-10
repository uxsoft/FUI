module FUI.Avalonia.Panel

open Avalonia.Controls
open FUI
open FUI.Avalonia.Patcher
open Avalonia.Media
open FUI.Avalonia.Control
open FUI.ObservableCollection

type PanelBuilder<'t when 't :> Panel and 't : equality>() =
    inherit ControlBuilder<'t>()
            
    member this.Run x =
        this.RunWithChildren x (fun panel (children: IReadOnlyObservableCollection<obj>) ->
            //TODO optimise to filter and cast on the Change level not on Oc
            let list = 
                children
                |> Oc.filter (fun i -> i :? IControl)
                |> Oc.map (fun i -> i :?> IControl)
            
            panel.Children.AddRange list
            list.OnChanged.Add(Change.commit panel.Children))
    
    /// IBrush | ObservableValue<IBrush>        
    [<CustomOperation("background")>]
    member _.background<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x Panel.BackgroundProperty value