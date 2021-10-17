module FUI.Avalonia.Panel

open Avalonia.Controls
open Avalonia.Controls.Presenters
open FUI
open FUI.Avalonia.Patcher
open Avalonia.Media
open FUI.Avalonia.Control
open FUI.ObservableCollection

type PanelBuilder<'t when 't :> Panel and 't : equality>() =
    inherit ControlBuilder<'t>()
            
    member this.Run x =
        this.RunWithChildren<'t> x (fun panel (children: IReadOnlyObservableCollection<obj>) ->
            
            let toControl item =
                match box item with
                | :? IControl as control -> control
                | _ -> ContentPresenter(Content = item) :> IControl
            
            for child in children do
                panel.Children.Add (toControl child)
        
            children.OnChanged.Add(function
                | CollectionChange.Insert(index, item) ->
                    panel.Children.Insert(index, toControl item)
                | CollectionChange.Remove(index, _) ->
                    panel.Children.RemoveAt(index))
        )
        
    /// IBrush | ObservableValue<IBrush>        
    [<CustomOperation("background")>]
    member _.background<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Panel.BackgroundProperty value