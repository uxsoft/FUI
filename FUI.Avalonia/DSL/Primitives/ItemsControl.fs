module FUI.Avalonia.ItemsControl

open Avalonia.Controls.Templates
open Avalonia.Controls
open FUI
open FUI.ObservableCollection
open FUI.UiBuilder
open FUI.Avalonia.TemplatedControl
 
type ItemsControlBuilder<'t when 't :> ItemsControl>() =
    inherit TemplatedControlBuilder<'t>()

    member this.Run x =
        this.RunWithChildren x (fun panel (children: IReadOnlyObservableCollection<obj>) ->
            //TODO optimise by implementing INotifyCollectionChanged so that we don't have to create a copy
            let items = System.Collections.ObjectModel.ObservableCollection(children)
            panel.Items <- items
            children.OnChanged.Add(Change.commit items))
        
    [<CustomOperation("items")>] 
    member _.items<'t, 'i when 'i :> obj>(x: Node<_, _>, views: 'i list) =
        Types.dependencyProperty ItemsControl.ItemsProperty views
        
    [<CustomOperation("itemsPanel")>] 
    member _.itemsPanel<'t>(x: Node<_, _>, value: ITemplate<IPanel>) =
        Types.dependencyProperty ItemsControl.ItemsPanelProperty value
        
    [<CustomOperation("itemTemplate")>] 
    member _.itemTemplate<'t>(x: Node<_, _>, value: IDataTemplate) =
        Types.dependencyProperty ItemsControl.ItemTemplateProperty value