module Avalonia.FuncUI.Experiments.DSL.ContentControl
  
open Avalonia.Controls
open FUI.UIBuilder
open Avalonia.FuncUI.Experiments.DSL.TemplatedControl
open Avalonia.FuncUI.Types
open Avalonia.FuncUI.Builder
open Avalonia.Controls.Templates
open Avalonia.Layout

type ContentControlBuilder<'t when 't :> ContentControl>() =
    inherit TemplatedControlBuilder<'t>()
    
    override _.Flatten x =
        match x.Children |> List.tryLast with
        | None -> x.Attributes
        | Some lastChild -> 
            let contentProp =
                match lastChild with
                | :? string as text ->
                    AttrBuilder<'t>.CreateProperty(ContentControl.ContentProperty, text, ValueNone)
                | :? IView as view ->
                    AttrBuilder<'t>.CreateContentSingle(ContentControl.ContentProperty, Some view)
                | other ->
                    AttrBuilder<'t>.CreateProperty(ContentControl.ContentProperty, other, ValueNone)
        
            x.Attributes @ [ contentProp ]
            
    [<CustomOperation("contentTemplate")>] 
    member _.contentTemplate<'t>(x: Element, value: IDataTemplate) =
        x @@ [ AttrBuilder<'t>.CreateProperty<IDataTemplate>(ContentControl.ContentTemplateProperty, value, ValueNone) ]

    [<CustomOperation("horizontalAlignment")>] 
    member _.horizontalAlignment<'t>(x: Element, value: HorizontalAlignment) =
        x @@ [ AttrBuilder<'t>.CreateProperty<HorizontalAlignment>(ContentControl.HorizontalAlignmentProperty, value, ValueNone) ]
        
    [<CustomOperation("verticalAlignment")>] 
    member _.verticalAlignment<'t>(x: Element, value: VerticalAlignment) =
        x @@ [ AttrBuilder<'t>.CreateProperty<VerticalAlignment>(ContentControl.VerticalAlignmentProperty, value, ValueNone) ]
    
    [<CustomOperation("horizontalContentAlignment")>] 
    member _.horizontalContentAlignment<'t>(x: Element, value: HorizontalAlignment) =
        x @@ [ AttrBuilder<'t>.CreateProperty<HorizontalAlignment>(ContentControl.HorizontalContentAlignmentProperty, value, ValueNone) ]

    [<CustomOperation("verticalContentAlignment")>] 
    member _.verticalContentAlignment<'t>(x: Element, value: VerticalAlignment) =
        x @@ [ AttrBuilder<'t>.CreateProperty<VerticalAlignment>(ContentControl.VerticalContentAlignmentProperty, value, ValueNone) ]
