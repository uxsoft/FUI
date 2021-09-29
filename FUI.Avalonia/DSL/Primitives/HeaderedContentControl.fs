module FUI.Avalonia.HeaderedContentControl

open Avalonia.Controls.Primitives
open FUI.UiBuilder
open FUI.Avalonia.ContentControl
open Avalonia.Controls.Templates
 
type HeaderedContentControlBuilder<'t when 't :> HeaderedContentControl and 't : equality>() =
    inherit ContentControlBuilder<'t>()
        
    [<CustomOperation("header")>] 
    member _.header<'t, 'c when 't :> HeaderedContentControl and 'c :> obj>(x: Types.AvaloniaNode<'t>, value: 'c) =
        Types.dependencyProperty x HeaderedContentControl.HeaderProperty value
        
    [<CustomOperation("headerTemplate")>] 
    member _.headerTemplate<'t when 't :> HeaderedContentControl>(x: Types.AvaloniaNode<'t>, value: IDataTemplate) =
        Types.dependencyProperty x HeaderedContentControl.HeaderTemplateProperty value