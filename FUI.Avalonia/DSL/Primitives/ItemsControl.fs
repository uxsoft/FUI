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
        
    /// IEnumerable<obj> | ObservableValue<IEnumerable<obj>
    [<CustomOperation("items")>] 
    member _.items<'t, 'v>(x: Types.AvaloniaNode<'t>, views: 'v) =
        Types.dependencyProperty x ItemsControl.ItemsProperty views
        
    /// ITemplate<IPanel> | ObservableValue<ITemplate<IPanel>>
    [<CustomOperation("itemsPanel")>] 
    member _.itemsPanel<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x ItemsControl.ItemsPanelProperty value
        
    /// IDataTemplate | ObservableValue<IDataTemplate>
    [<CustomOperation("itemTemplate")>] 
    member _.itemTemplate<'t, 'v>(x: Types.AvaloniaNode<'t>, value: 'v) =
        Types.dependencyProperty x ItemsControl.ItemTemplateProperty value