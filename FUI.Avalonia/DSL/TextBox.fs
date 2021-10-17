module FUI.Avalonia.TextBox

open Avalonia.Controls
open FUI.Avalonia.TemplatedControl
open Avalonia.Layout
open Avalonia.Media

type TextBoxBuilder<'t when 't :> TextBox and 't : equality>() =
    inherit TemplatedControlBuilder<'t>()

    /// bool | ObservableValue<bool>
    [<CustomOperation("acceptsReturn")>]
    member _.acceptsReturn<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TextBox.AcceptsReturnProperty value

    /// bool | ObservableValue<bool>
    [<CustomOperation("acceptsTab")>]
    member _.acceptsTab<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TextBox.AcceptsTabProperty value        

    /// int | ObservableValue<int>
    [<CustomOperation("caretIndex")>]
    member _.caretIndex<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TextBox.CaretIndexProperty value                
            
    /// bool | ObservableValue<bool>        
    [<CustomOperation("isReadOnly")>]
    member _.isReadOnly<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TextBox.IsReadOnlyProperty value

    /// HorizontalAlignment | ObservableValue<HorizontalAlignment>
    [<CustomOperation("horizontalContentAlignment")>]
    member _.horizontalContentAlignment<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TextBox.HorizontalContentAlignmentProperty value

    /// char | ObservableValue<char>
    [<CustomOperation("passwordChar")>]
    member _.passwordChar<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TextBox.PasswordCharProperty value
        
    /// IBrush | ObservableValue<IBrush>
    [<CustomOperation("selectionBrush")>]
    member _.selectionBrush<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TextBox.SelectionBrushProperty value
        
    /// IBrush | ObservableValue<IBrush>
    [<CustomOperation("selectionForegroundBrush")>]
    member _.selectionForegroundBrush<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TextBox.SelectionForegroundBrushProperty value  
        
    /// IBrush | ObservableValue<IBrush>
    [<CustomOperation("caretBrush")>]
    member _.caretBrush<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TextBox.CaretBrushProperty value
        
    /// int | ObservableValue<int>
    [<CustomOperation("selectionStart")>]
    member _.selectionStart<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TextBox.SelectionStartProperty value     
        
    /// int | ObservableValue<int>
    [<CustomOperation("selectionEnd")>]
    member _.selectionEnd<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TextBox.SelectionEndProperty value     
        
    /// int | ObservableValue<int>
    [<CustomOperation("maxLength")>]
    member _.maxLength<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TextBox.MaxLengthProperty value     
        
    /// string | ObservableValue<string>
    [<CustomOperation("text")>]
    member _.text<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TextBox.TextProperty value
        
    [<CustomOperation("onTextChanged")>]
    member _.onTextChanged<'t, 'v>(x, func: string -> unit) =
        Types.dependencyPropertyEvent x TextBox.TextProperty func
        
    /// TextAlignment | ObservableValue<TextAlignment>
    [<CustomOperation("textAlignment")>]
    member _.textAlignment<'t, 'v>(x, alignment: 'v) =
        Types.dependencyProperty x TextBox.TextAlignmentProperty alignment
        
    /// TextWrapping | ObservableValue<TextWrapping>
    [<CustomOperation("textWrapping")>]
    member _.textWrapping<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TextBox.TextWrappingProperty value
        
    /// bool | ObservableValue<bool>
    [<CustomOperation("useFloatingWatermark")>]
    member _.useFloatingWatermark<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TextBox.UseFloatingWatermarkProperty value
        
    /// string | ObservableValue<string>
    [<CustomOperation("newLine")>]
    member _.newLine<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TextBox.NewLineProperty value

    /// VerticalAlignment | ObservableValue<VerticalAlignment>
    [<CustomOperation("verticalContentAlignment")>]
    member _.verticalContentAlignment<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TextBox.VerticalContentAlignmentProperty value
        
    /// string | ObservableValue<string>
    [<CustomOperation("watermark")>]
    member _.watermark<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TextBox.WatermarkProperty value