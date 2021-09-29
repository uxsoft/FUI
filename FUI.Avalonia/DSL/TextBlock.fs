module FUI.Avalonia.TextBlock
open FUI.UiBuilder
open FUI.Avalonia.Control

open Avalonia
open Avalonia.Controls
open Avalonia.Media    
open Avalonia.FuncUI.Builder
open Avalonia.FuncUI.Types

let create (attrs: IAttr<TextBlock> list): IView<TextBlock> =
    ViewBuilder.Create<TextBlock>(attrs)

type TextBlockBuilder<'t when 't :> TextBlock>() =
    inherit ControlBuilder<'t>()
    
    override _.Flatten x =
        match x.Children |> List.tryLast with
        | None -> x.Attributes
        | Some lastChild ->
            x.Attributes @ [ AttrBuilder<'t>.CreateProperty(TextBlock.TextProperty, lastChild.ToString(), ValueNone) ]
        
    [<CustomOperation("text")>] 
    member _.text<'t>(x: Node<_, _>, value: string) =
        Types.dependencyProperty<string>(TextBlock.TextProperty, value, ValueNone) ]
        
    [<CustomOperation("background")>] 
    member _.background<'t>(x: Node<_, _>, value: IBrush) =
        Types.dependencyProperty<IBrush>(TextBlock.BackgroundProperty, value, ValueNone) ]
    
    [<CustomOperation("fontFamily")>] 
    member _.fontFamily<'t>(x: Node<_, _>, value: FontFamily) =
        Types.dependencyProperty<FontFamily>(TextBlock.FontFamilyProperty, value, ValueNone) ]
        
    [<CustomOperation("fontSize")>] 
    member _.fontSize<'t>(x: Node<_, _>, value: double) =
        Types.dependencyProperty<double>(TextBlock.FontSizeProperty, value, ValueNone) ]
        
    [<CustomOperation("fontStyle")>] 
    member _.fontStyle<'t>(x: Node<_, _>, value: FontStyle) =
        Types.dependencyProperty<FontStyle>(TextBlock.FontStyleProperty, value, ValueNone) ]
        
    [<CustomOperation("fontWeight")>] 
    member _.fontWeight<'t>(x: Node<_, _>, value: FontWeight) =
        Types.dependencyProperty<FontWeight>(TextBlock.FontWeightProperty, value, ValueNone) ]
        
    [<CustomOperation("foreground")>] 
    member _.foreground<'t>(x: Node<_, _>, value: IBrush) =
        Types.dependencyProperty<IBrush>(TextBlock.ForegroundProperty, value, ValueNone) ]

    [<CustomOperation("lineHeight")>] 
    member _.lineHeight<'t>(x: Node<_, _>, value: float) =
        Types.dependencyProperty<float>(TextBlock.LineHeightProperty, value, ValueNone) ]
        
    [<CustomOperation("maxLines")>] 
    member _.maxLines<'t>(x: Node<_, _>, value: int) =
        Types.dependencyProperty<int>(TextBlock.MaxLinesProperty, value, ValueNone) ]

    [<CustomOperation("padding")>] 
    member _.padding<'t>(x: Node<_, _>, value: Thickness) =
        Types.dependencyProperty<Thickness>(TextBlock.PaddingProperty, value, ValueNone) ]

    [<CustomOperation("textAlignment")>] 
    member _.textAlignment<'t>(x: Node<_, _>, alignment: TextAlignment) =
        Types.dependencyProperty<TextAlignment>(TextBlock.TextAlignmentProperty, alignment, ValueNone) ]

    [<CustomOperation("textDecorations")>] 
    member _.textDecorations<'t>(x: Node<_, _>, value: TextDecorationCollection) =
        Types.dependencyProperty<TextDecorationCollection>(TextBlock.TextDecorationsProperty, value, ValueNone) ]

    [<CustomOperation("textTrimming")>] 
    member _.textTrimming<'t>(x: Node<_, _>, value: TextTrimming) =
        Types.dependencyProperty<TextTrimming>(TextBlock.TextTrimmingProperty, value, ValueNone) ]
        
    [<CustomOperation("textWrapping")>] 
    member _.textWrapping<'t>(x: Node<_, _>, value: TextWrapping) =
        Types.dependencyProperty<TextWrapping>(TextBlock.TextWrappingProperty, value, ValueNone) ]