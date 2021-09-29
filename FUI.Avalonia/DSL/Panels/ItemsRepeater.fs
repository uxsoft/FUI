module FUI.Avalonia.ItemsRepeater

open System.Collections
open Avalonia.Controls
open FUI.UiBuilder
open FUI.Avalonia.Panel
open Avalonia.FuncUI.Types
open Avalonia.FuncUI.Builder
open Avalonia.Controls.Templates

type ItemsRepeaterBuilder<'t when 't :> ItemsRepeater>() =
    inherit Panel.PanelBuilder<'t>()
    
    [<CustomOperation("viewItems")>] 
    member _.viewItems<'t>(x: Node<_, _>, views: List<IView>) =
        x @@ [ AttrBuilder<'t>.CreateContentMultiple(ItemsRepeater.ItemsProperty, views) 
    
    [<CustomOperation("dataItems")>] 
    member _.dataItems<'t>(x: Node<_, _>, data : IEnumerable) =
        Types.dependencyProperty<IEnumerable>(ItemsRepeater.ItemsProperty, data, ValueNone) 
        
    [<CustomOperation("itemTemplate")>] 
    member _.itemTemplate<'t>(x: Node<_, _>, value : IDataTemplate) =
        Types.dependencyProperty<IDataTemplate>(ItemsRepeater.ItemTemplateProperty, value, ValueNone) 
