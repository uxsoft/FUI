module FUI.Avalonia.ContentControl
  
open Avalonia.Controls
open FUI.UiBuilder
open FUI.Avalonia.TemplatedControl
open Avalonia.Controls.Templates
open Avalonia.Layout

type ContentControlBuilder<'t when 't :> ContentControl>() =
    inherit TemplatedControlBuilder<'t>()
    
    member this.Run x =
        this.RunWithChild x (fun control child -> control.Content <- child)
            
    [<CustomOperation("contentTemplate")>] 
    member _.contentTemplate<'t>(x: Node<_, _>, value: IDataTemplate) =
        Types.dependencyProperty ContentControl.ContentTemplateProperty value

    [<CustomOperation("horizontalAlignment")>] 
    member _.horizontalAlignment<'t>(x: Node<_, _>, value: HorizontalAlignment) =
        Types.dependencyProperty ContentControl.HorizontalAlignmentProperty value
        
    [<CustomOperation("verticalAlignment")>] 
    member _.verticalAlignment<'t>(x: Node<_, _>, value: VerticalAlignment) =
        Types.dependencyProperty ContentControl.VerticalAlignmentProperty value
    
    [<CustomOperation("horizontalContentAlignment")>] 
    member _.horizontalContentAlignment<'t>(x: Node<_, _>, value: HorizontalAlignment) =
        Types.dependencyProperty ContentControl.HorizontalContentAlignmentProperty value

    [<CustomOperation("verticalContentAlignment")>] 
    member _.verticalContentAlignment<'t>(x: Node<_, _>, value: VerticalAlignment) =
        Types.dependencyProperty ContentControl.VerticalContentAlignmentProperty value
