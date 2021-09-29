module FUI.Avalonia.Panel

open Avalonia.Controls
open FUI
open FUI.ObservableCollection
open FUI.UiBuilder
open Avalonia.Media
open FUI.Avalonia.Control

type PanelBuilder<'t when 't :> Panel>() =
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
            
    [<CustomOperation("background")>]
    member _.background<'t>(x: Node<_, _>, value: IBrush) =
        Types.dependencyProperty Panel.BackgroundProperty value