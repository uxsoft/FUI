module FUI.Avalonia.HeaderedContentControl

open Avalonia.Controls.Primitives
open FUI.UiBuilder
open FUI.Avalonia.ContentControl
open Avalonia.Controls.Templates
 
type HeaderedContentControlBuilder<'t when 't :> HeaderedContentControl and 't : equality>() =
    inherit ContentControlBuilder<'t>()
        
    /// obj | ObservableValue<obj>
    [<CustomOperation("header")>] 
    member _.header<'t, 'v when 't :> HeaderedContentControl>(x, value: 'v) =
        Types.dependencyProperty x HeaderedContentControl.HeaderProperty value
        
    /// IDataTemplate | ObservableValue<IDataTemplate>
    [<CustomOperation("headerTemplate")>] 
    member _.headerTemplate<'t, 'v when 't :> HeaderedContentControl>(x, value: 'v) =
        Types.dependencyProperty x HeaderedContentControl.HeaderTemplateProperty value