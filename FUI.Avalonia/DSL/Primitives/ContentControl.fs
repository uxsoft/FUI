module Avalonia.FuncUI.Experiments.DSL.ContentControl
  
open Avalonia.Controls
open FUI.UiBuilder
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
    member _.contentTemplate<'t>(x: Node<_, _>, value: IDataTemplate) =
        Types.dependencyProperty<IDataTemplate>(ContentControl.ContentTemplateProperty, value, ValueNone) ]

    [<CustomOperation("horizontalAlignment")>] 
    member _.horizontalAlignment<'t>(x: Node<_, _>, value: HorizontalAlignment) =
        Types.dependencyProperty<HorizontalAlignment>(ContentControl.HorizontalAlignmentProperty, value, ValueNone) ]
        
    [<CustomOperation("verticalAlignment")>] 
    member _.verticalAlignment<'t>(x: Node<_, _>, value: VerticalAlignment) =
        Types.dependencyProperty<VerticalAlignment>(ContentControl.VerticalAlignmentProperty, value, ValueNone) ]
    
    [<CustomOperation("horizontalContentAlignment")>] 
    member _.horizontalContentAlignment<'t>(x: Node<_, _>, value: HorizontalAlignment) =
        Types.dependencyProperty<HorizontalAlignment>(ContentControl.HorizontalContentAlignmentProperty, value, ValueNone) ]

    [<CustomOperation("verticalContentAlignment")>] 
    member _.verticalContentAlignment<'t>(x: Node<_, _>, value: VerticalAlignment) =
        Types.dependencyProperty<VerticalAlignment>(ContentControl.VerticalContentAlignmentProperty, value, ValueNone) ]
