module FUI.Avalonia.ContentControl
  
open Avalonia.Controls
open FUI.Avalonia.Patcher
open FUI.Avalonia.TemplatedControl
open Avalonia.Controls.Templates
open Avalonia.Layout

type ContentControlBuilder<'t when 't :> ContentControl and 't : equality>() =
    inherit TemplatedControlBuilder<'t>()
    
    member this.Run x =
        this.RunWithChild x (fun control child -> control.Content <- child)
            
    [<CustomOperation("contentTemplate")>] 
    member _.contentTemplate<'t>(x: Types.AvaloniaNode<'t>, value: IDataTemplate) =
        Types.dependencyProperty x ContentControl.ContentTemplateProperty value

    [<CustomOperation("horizontalAlignment")>] 
    member _.horizontalAlignment<'t>(x: Types.AvaloniaNode<'t>, value: HorizontalAlignment) =
        Types.dependencyProperty x ContentControl.HorizontalAlignmentProperty value
        
    [<CustomOperation("verticalAlignment")>] 
    member _.verticalAlignment<'t>(x: Types.AvaloniaNode<'t>, value: VerticalAlignment) =
        Types.dependencyProperty x ContentControl.VerticalAlignmentProperty value
    
    [<CustomOperation("horizontalContentAlignment")>] 
    member _.horizontalContentAlignment<'t>(x: Types.AvaloniaNode<'t>, value: HorizontalAlignment) =
        Types.dependencyProperty x ContentControl.HorizontalContentAlignmentProperty value

    [<CustomOperation("verticalContentAlignment")>] 
    member _.verticalContentAlignment<'t>(x: Types.AvaloniaNode<'t>, value: VerticalAlignment) =
        Types.dependencyProperty x ContentControl.VerticalContentAlignmentProperty value
