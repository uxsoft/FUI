module FUI.Avalonia.TextBox

open Avalonia.Controls
open FUI.UiBuilder
open FUI.Avalonia.TemplatedControl
open Avalonia.Layout
open Avalonia.Media
open Avalonia.FuncUI.Builder

type TextBoxBuilder<'t when 't :> TextBox>() =
    inherit TemplatedControlBuilder<'t>()

    [<CustomOperation("acceptsReturn")>]
    member _.acceptsReturn<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x<bool>(TextBox.AcceptsReturnProperty, value, ValueNone) ]

    [<CustomOperation("acceptsTab")>]
    member _.acceptsTab<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x<bool>(TextBox.AcceptsTabProperty, value, ValueNone) ]        

    [<CustomOperation("caretIndex")>]
    member _.caretIndex<'t>(x: Types.AvaloniaNode<'t>, value: int) =
        Types.dependencyProperty x<int>(TextBox.CaretIndexProperty, value, ValueNone) ]                
                    
    [<CustomOperation("isReadOnly")>]
    member _.isReadOnly<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x<bool>(TextBox.IsReadOnlyProperty, value, ValueNone) ]

    [<CustomOperation("horizontalContentAlignment")>]
    member _.horizontalContentAlignment<'t>(x: Types.AvaloniaNode<'t>, value: HorizontalAlignment) =
        Types.dependencyProperty x<HorizontalAlignment>(TextBox.HorizontalContentAlignmentProperty, value, ValueNone) ]

    [<CustomOperation("passwordChar")>]
    member _.passwordChar<'t>(x: Types.AvaloniaNode<'t>, value: char) =
        Types.dependencyProperty x<char>(TextBox.PasswordCharProperty, value, ValueNone) ]
        
    [<CustomOperation("selectionBrush")>]
    member _.selectionBrush<'t>(x: Types.AvaloniaNode<'t>, value: IBrush) =
        Types.dependencyProperty x<IBrush>(TextBox.SelectionBrushProperty, value, ValueNone) ]
        
    [<CustomOperation("selectionForegroundBrush")>]
    member _.selectionForegroundBrush<'t>(x: Types.AvaloniaNode<'t>, value: IBrush) =
        Types.dependencyProperty x<IBrush>(TextBox.SelectionForegroundBrushProperty, value, ValueNone) ]  
        
    [<CustomOperation("caretBrush")>]
    member _.caretBrush<'t>(x: Types.AvaloniaNode<'t>, value: IBrush) =
        Types.dependencyProperty x<IBrush>(TextBox.CaretBrushProperty, value, ValueNone) ]
        
    [<CustomOperation("selectionStart")>]
    member _.selectionStart<'t>(x: Types.AvaloniaNode<'t>, value: int) =
        Types.dependencyProperty x<int>(TextBox.SelectionStartProperty, value, ValueNone) ]     
        
    [<CustomOperation("selectionEnd")>]
    member _.selectionEnd<'t>(x: Types.AvaloniaNode<'t>, value: int) =
        Types.dependencyProperty x<int>(TextBox.SelectionEndProperty, value, ValueNone) ]     
        
    [<CustomOperation("maxLength")>]
    member _.maxLength<'t>(x: Types.AvaloniaNode<'t>, value: int) =
        Types.dependencyProperty x<int>(TextBox.MaxLengthProperty, value, ValueNone) ]     
        
    [<CustomOperation("text")>]
    member _.text<'t>(x: Types.AvaloniaNode<'t>, value: string) =
        Types.dependencyProperty x<string>(TextBox.TextProperty, value, ValueNone) ]
        
    [<CustomOperation("onTextChanged")>]
    member _.onTextChanged<'t>(x: Types.AvaloniaNode<'t>, func: string -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<string>(TextBox.TextProperty, func) ]
        
    [<CustomOperation("textAlignment")>]
    member _.textAlignment<'t>(x: Types.AvaloniaNode<'t>, alignment: TextAlignment) =
        Types.dependencyProperty x<TextAlignment>(TextBox.TextAlignmentProperty, alignment, ValueNone) ]
        
    [<CustomOperation("textWrapping")>]
    member _.textWrapping<'t>(x: Types.AvaloniaNode<'t>, value: TextWrapping) =
        Types.dependencyProperty x<TextWrapping>(TextBox.TextWrappingProperty, value, ValueNone) ]
        
    [<CustomOperation("useFloatingWatermark")>]
    member _.useFloatingWatermark<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x<bool>(TextBox.UseFloatingWatermarkProperty, value, ValueNone) ]
        
    [<CustomOperation("newLine")>]
    member _.newLine<'t>(x: Types.AvaloniaNode<'t>, value: string) =
        Types.dependencyProperty x<string>(TextBox.NewLineProperty, value, ValueNone) ]

    [<CustomOperation("verticalContentAlignment")>]
    member _.verticalContentAlignment<'t>(x: Types.AvaloniaNode<'t>, value: VerticalAlignment) =
        Types.dependencyProperty x<VerticalAlignment>(TextBox.VerticalContentAlignmentProperty, value, ValueNone) ]
        
    [<CustomOperation("watermark")>]
    member _.watermark<'t>(x: Types.AvaloniaNode<'t>, value: string) =
        Types.dependencyProperty x<string>(TextBox.WatermarkProperty, value, ValueNone) ]