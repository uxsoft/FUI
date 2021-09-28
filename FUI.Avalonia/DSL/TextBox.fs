module Avalonia.FuncUI.Experiments.DSL.TextBox

open Avalonia.Controls
open FUI.UiBuilder
open Avalonia.FuncUI.Experiments.DSL.TemplatedControl
open Avalonia.Layout
open Avalonia.Media
open Avalonia.FuncUI.Builder

type TextBoxBuilder<'t when 't :> TextBox>() =
    inherit TemplatedControlBuilder<'t>()

    [<CustomOperation("acceptsReturn")>]
    member _.acceptsReturn<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(TextBox.AcceptsReturnProperty, value, ValueNone) ]

    [<CustomOperation("acceptsTab")>]
    member _.acceptsTab<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(TextBox.AcceptsTabProperty, value, ValueNone) ]        

    [<CustomOperation("caretIndex")>]
    member _.caretIndex<'t>(x: Node<_, _>, value: int) =
        Types.dependencyProperty<int>(TextBox.CaretIndexProperty, value, ValueNone) ]                
                    
    [<CustomOperation("isReadOnly")>]
    member _.isReadOnly<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(TextBox.IsReadOnlyProperty, value, ValueNone) ]

    [<CustomOperation("horizontalContentAlignment")>]
    member _.horizontalContentAlignment<'t>(x: Node<_, _>, value: HorizontalAlignment) =
        Types.dependencyProperty<HorizontalAlignment>(TextBox.HorizontalContentAlignmentProperty, value, ValueNone) ]

    [<CustomOperation("passwordChar")>]
    member _.passwordChar<'t>(x: Node<_, _>, value: char) =
        Types.dependencyProperty<char>(TextBox.PasswordCharProperty, value, ValueNone) ]
        
    [<CustomOperation("selectionBrush")>]
    member _.selectionBrush<'t>(x: Node<_, _>, value: IBrush) =
        Types.dependencyProperty<IBrush>(TextBox.SelectionBrushProperty, value, ValueNone) ]
        
    [<CustomOperation("selectionForegroundBrush")>]
    member _.selectionForegroundBrush<'t>(x: Node<_, _>, value: IBrush) =
        Types.dependencyProperty<IBrush>(TextBox.SelectionForegroundBrushProperty, value, ValueNone) ]  
        
    [<CustomOperation("caretBrush")>]
    member _.caretBrush<'t>(x: Node<_, _>, value: IBrush) =
        Types.dependencyProperty<IBrush>(TextBox.CaretBrushProperty, value, ValueNone) ]
        
    [<CustomOperation("selectionStart")>]
    member _.selectionStart<'t>(x: Node<_, _>, value: int) =
        Types.dependencyProperty<int>(TextBox.SelectionStartProperty, value, ValueNone) ]     
        
    [<CustomOperation("selectionEnd")>]
    member _.selectionEnd<'t>(x: Node<_, _>, value: int) =
        Types.dependencyProperty<int>(TextBox.SelectionEndProperty, value, ValueNone) ]     
        
    [<CustomOperation("maxLength")>]
    member _.maxLength<'t>(x: Node<_, _>, value: int) =
        Types.dependencyProperty<int>(TextBox.MaxLengthProperty, value, ValueNone) ]     
        
    [<CustomOperation("text")>]
    member _.text<'t>(x: Node<_, _>, value: string) =
        Types.dependencyProperty<string>(TextBox.TextProperty, value, ValueNone) ]
        
    [<CustomOperation("onTextChanged")>]
    member _.onTextChanged<'t>(x: Node<_, _>, func: string -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<string>(TextBox.TextProperty, func) ]
        
    [<CustomOperation("textAlignment")>]
    member _.textAlignment<'t>(x: Node<_, _>, alignment: TextAlignment) =
        Types.dependencyProperty<TextAlignment>(TextBox.TextAlignmentProperty, alignment, ValueNone) ]
        
    [<CustomOperation("textWrapping")>]
    member _.textWrapping<'t>(x: Node<_, _>, value: TextWrapping) =
        Types.dependencyProperty<TextWrapping>(TextBox.TextWrappingProperty, value, ValueNone) ]
        
    [<CustomOperation("useFloatingWatermark")>]
    member _.useFloatingWatermark<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(TextBox.UseFloatingWatermarkProperty, value, ValueNone) ]
        
    [<CustomOperation("newLine")>]
    member _.newLine<'t>(x: Node<_, _>, value: string) =
        Types.dependencyProperty<string>(TextBox.NewLineProperty, value, ValueNone) ]

    [<CustomOperation("verticalContentAlignment")>]
    member _.verticalContentAlignment<'t>(x: Node<_, _>, value: VerticalAlignment) =
        Types.dependencyProperty<VerticalAlignment>(TextBox.VerticalContentAlignmentProperty, value, ValueNone) ]
        
    [<CustomOperation("watermark")>]
    member _.watermark<'t>(x: Node<_, _>, value: string) =
        Types.dependencyProperty<string>(TextBox.WatermarkProperty, value, ValueNone) ]