module Avalonia.FuncUI.Experiments.DSL.ItemsControl

open Avalonia.Controls.Templates
open System.Collections
open Avalonia.Controls
open FUI.UIBuilder
open Avalonia.FuncUI.Experiments.DSL.TemplatedControl
open Avalonia.FuncUI.Types
open Avalonia.FuncUI.Builder
 
type ItemsControlBuilder<'t when 't :> ItemsControl>() =
    inherit TemplatedControlBuilder<'t>()

    override _.Flatten x =
        let views = 
            x.Children
            |> List.filter (fun it -> it :? IView)
            |> List.map (fun it -> it :?> IView)
        
        if views.Length > 0 then
            let prop = AttrBuilder<'t>.CreateContentMultiple(ItemsControl.ItemsProperty, views)
            x.Attributes @ [ prop ]
        else
            x.Attributes
        
    
    [<CustomOperation("viewItems")>] 
    member _.viewItems<'t>(x: Element, views: IView list) =
        x @@ [ AttrBuilder<'t>.CreateContentMultiple(ItemsControl.ItemsProperty, views) ]
        
    [<CustomOperation("dataItems")>] 
    member _.dataItems<'t>(x: Element, data: IEnumerable) =
        x @@ [ AttrBuilder<'t>.CreateProperty<IEnumerable>(ItemsControl.ItemsProperty, data, ValueNone) ]
        
    [<CustomOperation("itemsPanel")>] 
    member _.itemsPanel<'t>(x: Element, value: ITemplate<IPanel>) =
        x @@ [ AttrBuilder<'t>.CreateProperty<ITemplate<IPanel>>(ItemsControl.ItemsPanelProperty, value, ValueNone) ]
        
    [<CustomOperation("itemTemplate")>] 
    member _.itemTemplate<'t>(x: Element, value: IDataTemplate) =
        x @@ [ AttrBuilder<'t>.CreateProperty<IDataTemplate>(ItemsControl.ItemTemplateProperty, value, ValueNone) ]