module FUI.Avalonia.DataValidationErrors

open Avalonia.Controls.Templates
open Avalonia.Controls
open FUI.Avalonia.Types
    
type DataValidationErrorsBuilder<'t when 't :> DataValidationErrors and 't : equality>() =
    inherit ContentControl.ContentControlBuilder<'t>()
    
    /// IDataTemplate | ObservableValue<IDataTemplate>
    [<CustomOperation("errorTemplate")>]
    member _.errorTemplate<'t, 'v>(x: AvaloniaNode<'t>, template: 'v) =
        Types.dependencyProperty x DataValidationErrors.ErrorTemplateProperty template