module FUI.Avalonia.TextBox

open Avalonia.Controls
open FUI.Avalonia.TemplatedControl
open Avalonia.Layout
open Avalonia.Media

type TextBoxBuilder<'t when 't :> TextBox and 't : equality>() =
    inherit TemplatedControlBuilder<'t>()

    [<CustomOperation("acceptsReturn")>]
    member _.acceptsReturn<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x TextBox.AcceptsReturnProperty value

    [<CustomOperation("acceptsTab")>]
    member _.acceptsTab<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x TextBox.AcceptsTabProperty value        

    [<CustomOperation("caretIndex")>]
    member _.caretIndex<'t>(x: Types.AvaloniaNode<'t>, value: int) =
        Types.dependencyProperty x TextBox.CaretIndexProperty value                
                    
    [<CustomOperation("isReadOnly")>]
    member _.isReadOnly<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x TextBox.IsReadOnlyProperty value

    [<CustomOperation("horizontalContentAlignment")>]
    member _.horizontalContentAlignment<'t>(x: Types.AvaloniaNode<'t>, value: HorizontalAlignment) =
        Types.dependencyProperty x TextBox.HorizontalContentAlignmentProperty value

    [<CustomOperation("passwordChar")>]
    member _.passwordChar<'t>(x: Types.AvaloniaNode<'t>, value: char) =
        Types.dependencyProperty x TextBox.PasswordCharProperty value
        
    [<CustomOperation("selectionBrush")>]
    member _.selectionBrush<'t>(x: Types.AvaloniaNode<'t>, value: IBrush) =
        Types.dependencyProperty x TextBox.SelectionBrushProperty value
        
    [<CustomOperation("selectionForegroundBrush")>]
    member _.selectionForegroundBrush<'t>(x: Types.AvaloniaNode<'t>, value: IBrush) =
        Types.dependencyProperty x TextBox.SelectionForegroundBrushProperty value  
        
    [<CustomOperation("caretBrush")>]
    member _.caretBrush<'t>(x: Types.AvaloniaNode<'t>, value: IBrush) =
        Types.dependencyProperty x TextBox.CaretBrushProperty value
        
    [<CustomOperation("selectionStart")>]
    member _.selectionStart<'t>(x: Types.AvaloniaNode<'t>, value: int) =
        Types.dependencyProperty x TextBox.SelectionStartProperty value     
        
    [<CustomOperation("selectionEnd")>]
    member _.selectionEnd<'t>(x: Types.AvaloniaNode<'t>, value: int) =
        Types.dependencyProperty x TextBox.SelectionEndProperty value     
        
    [<CustomOperation("maxLength")>]
    member _.maxLength<'t>(x: Types.AvaloniaNode<'t>, value: int) =
        Types.dependencyProperty x TextBox.MaxLengthProperty value     
        
    [<CustomOperation("text")>]
    member _.text<'t>(x: Types.AvaloniaNode<'t>, value: string) =
        Types.dependencyProperty x TextBox.TextProperty value
        
    [<CustomOperation("onTextChanged")>]
    member _.onTextChanged<'t>(x: Types.AvaloniaNode<'t>, func: string -> unit) =
        Types.dependencyPropertyEvent x TextBox.TextProperty func
        
    [<CustomOperation("textAlignment")>]
    member _.textAlignment<'t>(x: Types.AvaloniaNode<'t>, alignment: TextAlignment) =
        Types.dependencyProperty x TextBox.TextAlignmentProperty alignment
        
    [<CustomOperation("textWrapping")>]
    member _.textWrapping<'t>(x: Types.AvaloniaNode<'t>, value: TextWrapping) =
        Types.dependencyProperty x TextBox.TextWrappingProperty value
        
    [<CustomOperation("useFloatingWatermark")>]
    member _.useFloatingWatermark<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x TextBox.UseFloatingWatermarkProperty value
        
    [<CustomOperation("newLine")>]
    member _.newLine<'t>(x: Types.AvaloniaNode<'t>, value: string) =
        Types.dependencyProperty x TextBox.NewLineProperty value

    [<CustomOperation("verticalContentAlignment")>]
    member _.verticalContentAlignment<'t>(x: Types.AvaloniaNode<'t>, value: VerticalAlignment) =
        Types.dependencyProperty x TextBox.VerticalContentAlignmentProperty value
        
    [<CustomOperation("watermark")>]
    member _.watermark<'t>(x: Types.AvaloniaNode<'t>, value: string) =
        Types.dependencyProperty x TextBox.WatermarkProperty value