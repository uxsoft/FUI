module FUI.Avalonia.DataValidationErrors

open Avalonia.Controls.Templates
open Avalonia.Controls
open FUI.Avalonia.Types
    
type DataValidationErrorsBuilder<'t when 't :> DataValidationErrors and 't : equality>() =
    inherit ContentControl.ContentControlBuilder<'t>()
    
    [<CustomOperation("errorTemplate")>]
    member _.errorTemplate<'t>(x: AvaloniaNode<'t>, template: IDataTemplate) =
        Types.dependencyProperty x DataValidationErrors.ErrorTemplateProperty template