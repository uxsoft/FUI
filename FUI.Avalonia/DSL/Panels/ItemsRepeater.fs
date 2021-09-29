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
    member _.viewItems<'t>(x: Types.AvaloniaNode<'t>, views: List<IView>) =
        x @@ [ AttrBuilder<'t>.CreateContentMultiple(ItemsRepeater.ItemsProperty, views) 
    
    [<CustomOperation("dataItems")>] 
    member _.dataItems<'t>(x: Types.AvaloniaNode<'t>, data : IEnumerable) =
        Types.dependencyProperty x<IEnumerable>(ItemsRepeater.ItemsProperty, data, ValueNone) 
        
    [<CustomOperation("itemTemplate")>] 
    member _.itemTemplate<'t>(x: Types.AvaloniaNode<'t>, value : IDataTemplate) =
        Types.dependencyProperty x<IDataTemplate>(ItemsRepeater.ItemTemplateProperty, value, ValueNone) 
