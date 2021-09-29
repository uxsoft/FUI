module FUI.Avalonia.HeaderedContentControl

open Avalonia.Controls.Primitives
open FUI.UiBuilder
open FUI.Avalonia.ContentControl
open Avalonia.FuncUI.Types
open Avalonia.FuncUI.Builder
open Avalonia.Controls.Templates
 
type HeaderedContentControlBuilder<'t when 't :> HeaderedContentControl>() =
    inherit ContentControlBuilder<'t>()
        
    [<CustomOperation("header")>] 
    member _.header<'t, 'c when 't :> HeaderedContentControl and 'c :> obj>(x: Node<_, _>, value: 'c) =
        let prop = 
            match box value with
            | :? IView as view -> AttrBuilder<'t>.CreateContentSingle(HeaderedContentControl.HeaderProperty, Some view)
            | :? string as text -> AttrBuilder<'t>.CreateProperty<string>(HeaderedContentControl.HeaderProperty, text, ValueNone)
            | _ -> AttrBuilder<'t>.CreateProperty<obj>(HeaderedContentControl.HeaderProperty, value, ValueNone)
        
        x @@ [ prop ]
        
    [<CustomOperation("headerTemplate")>] 
    member _.headerTemplate<'t when 't :> HeaderedContentControl>(x: Node<_, _>, value: IDataTemplate) =
        Types.dependencyProperty<IDataTemplate>(HeaderedContentControl.HeaderTemplateProperty, value, ValueNone) ]