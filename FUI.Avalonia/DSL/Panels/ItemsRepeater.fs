module FUI.Avalonia.ItemsRepeater

open FUI
open FUI.Avalonia.Patcher
open Avalonia.Controls
open FUI.Avalonia.Panel
open Avalonia.Controls.Templates
open FUI.ObservableCollection

type ItemsRepeaterBuilder<'t when 't :> ItemsRepeater and 't : equality>() =
    inherit Panel.PanelBuilder<'t>()
    
    member this.Run x =
        this.RunWithChildren<'t> x (fun panel (children: IReadOnlyObservableCollection<obj>) ->
            //TODO optimise by implementing INotifyCollectionChanged
            let items = System.Collections.ObjectModel.ObservableCollection(children)
            panel.Items <- items
            children.OnChanged.Add(Change.commit items))
        
    /// IDataTemplate | ObservableValue<IDataTemplate>
    [<CustomOperation("itemTemplate")>] 
    member _.itemTemplate<'t, 'v>(x, value : 'v) =
        Types.dependencyProperty x ItemsRepeater.ItemTemplateProperty value
