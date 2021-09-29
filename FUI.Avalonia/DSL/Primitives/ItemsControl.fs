module FUI.Avalonia.ItemsControl

open Avalonia.Controls.Templates
open Avalonia.Controls
open FUI
open FUI.ObservableCollection
open FUI.Avalonia.Patcher
open FUI.Avalonia.TemplatedControl
 
type ItemsControlBuilder<'t when 't :> ItemsControl and 't : equality>() =
    inherit TemplatedControlBuilder<'t>()

    member this.Run x =
        this.RunWithChildren x (fun panel (children: IReadOnlyObservableCollection<obj>) ->
            //TODO optimise by implementing INotifyCollectionChanged so that we don't have to create a copy
            let items = System.Collections.ObjectModel.ObservableCollection(children)
            panel.Items <- items
            children.OnChanged.Add(Change.commit items))
        
    [<CustomOperation("items")>] 
    member _.items<'t, 'i when 'i :> obj>(x: Types.AvaloniaNode<'t>, views: 'i list) =
        Types.dependencyProperty x ItemsControl.ItemsProperty views
        
    [<CustomOperation("itemsPanel")>] 
    member _.itemsPanel<'t>(x: Types.AvaloniaNode<'t>, value: ITemplate<IPanel>) =
        Types.dependencyProperty x ItemsControl.ItemsPanelProperty value
        
    [<CustomOperation("itemTemplate")>] 
    member _.itemTemplate<'t>(x: Types.AvaloniaNode<'t>, value: IDataTemplate) =
        Types.dependencyProperty x ItemsControl.ItemTemplateProperty value