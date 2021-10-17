module FUI.Avalonia.ContentControl
  
open Avalonia.Controls
open FUI.Avalonia.Patcher
open FUI.Avalonia.TemplatedControl
open Avalonia.Controls.Templates
open Avalonia.Layout

type ContentControlBuilder<'t when 't :> ContentControl and 't : equality>() =
    inherit TemplatedControlBuilder<'t>()
    
    member this.Run x =
        this.RunWithChild<'t> x (fun control child -> control.Content <- child)
            
    /// IDataTemplate | ObservableValue<IDataTemplate>
    [<CustomOperation("contentTemplate")>] 
    member _.contentTemplate<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x ContentControl.ContentTemplateProperty value

    /// HorizontalAlignment | ObservableValue<HorizontalAlignment>
    [<CustomOperation("horizontalAlignment")>] 
    member _.horizontalAlignment<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x ContentControl.HorizontalAlignmentProperty value
        
    /// VerticalAlignment | ObservableValue<VerticalAlignment>
    [<CustomOperation("verticalAlignment")>] 
    member _.verticalAlignment<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x ContentControl.VerticalAlignmentProperty value
    
    /// HorizontalAlignment | ObservableValue<HorizontalAlignment>
    [<CustomOperation("horizontalContentAlignment")>] 
    member _.horizontalContentAlignment<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x ContentControl.HorizontalContentAlignmentProperty value

    /// VerticalAlignment | ObservableValue<VerticalAlignment>
    [<CustomOperation("verticalContentAlignment")>] 
    member _.verticalContentAlignment<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x ContentControl.VerticalContentAlignmentProperty value
