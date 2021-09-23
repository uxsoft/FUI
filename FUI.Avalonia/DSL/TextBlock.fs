module Avalonia.FuncUI.Experiments.DSL.TextBlock
open FUI.UIBuilder
open Avalonia.FuncUI.Experiments.DSL.Control

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
    member _.text<'t>(x: Element, value: string) =
        x @@ [ AttrBuilder<'t>.CreateProperty<string>(TextBlock.TextProperty, value, ValueNone) ]
        
    [<CustomOperation("background")>] 
    member _.background<'t>(x: Element, value: IBrush) =
        x @@ [ AttrBuilder<'t>.CreateProperty<IBrush>(TextBlock.BackgroundProperty, value, ValueNone) ]
    
    [<CustomOperation("fontFamily")>] 
    member _.fontFamily<'t>(x: Element, value: FontFamily) =
        x @@ [ AttrBuilder<'t>.CreateProperty<FontFamily>(TextBlock.FontFamilyProperty, value, ValueNone) ]
        
    [<CustomOperation("fontSize")>] 
    member _.fontSize<'t>(x: Element, value: double) =
        x @@ [ AttrBuilder<'t>.CreateProperty<double>(TextBlock.FontSizeProperty, value, ValueNone) ]
        
    [<CustomOperation("fontStyle")>] 
    member _.fontStyle<'t>(x: Element, value: FontStyle) =
        x @@ [ AttrBuilder<'t>.CreateProperty<FontStyle>(TextBlock.FontStyleProperty, value, ValueNone) ]
        
    [<CustomOperation("fontWeight")>] 
    member _.fontWeight<'t>(x: Element, value: FontWeight) =
        x @@ [ AttrBuilder<'t>.CreateProperty<FontWeight>(TextBlock.FontWeightProperty, value, ValueNone) ]
        
    [<CustomOperation("foreground")>] 
    member _.foreground<'t>(x: Element, value: IBrush) =
        x @@ [ AttrBuilder<'t>.CreateProperty<IBrush>(TextBlock.ForegroundProperty, value, ValueNone) ]

    [<CustomOperation("lineHeight")>] 
    member _.lineHeight<'t>(x: Element, value: float) =
        x @@ [ AttrBuilder<'t>.CreateProperty<float>(TextBlock.LineHeightProperty, value, ValueNone) ]
        
    [<CustomOperation("maxLines")>] 
    member _.maxLines<'t>(x: Element, value: int) =
        x @@ [ AttrBuilder<'t>.CreateProperty<int>(TextBlock.MaxLinesProperty, value, ValueNone) ]

    [<CustomOperation("padding")>] 
    member _.padding<'t>(x: Element, value: Thickness) =
        x @@ [ AttrBuilder<'t>.CreateProperty<Thickness>(TextBlock.PaddingProperty, value, ValueNone) ]

    [<CustomOperation("textAlignment")>] 
    member _.textAlignment<'t>(x: Element, alignment: TextAlignment) =
        x @@ [ AttrBuilder<'t>.CreateProperty<TextAlignment>(TextBlock.TextAlignmentProperty, alignment, ValueNone) ]

    [<CustomOperation("textDecorations")>] 
    member _.textDecorations<'t>(x: Element, value: TextDecorationCollection) =
        x @@ [ AttrBuilder<'t>.CreateProperty<TextDecorationCollection>(TextBlock.TextDecorationsProperty, value, ValueNone) ]

    [<CustomOperation("textTrimming")>] 
    member _.textTrimming<'t>(x: Element, value: TextTrimming) =
        x @@ [ AttrBuilder<'t>.CreateProperty<TextTrimming>(TextBlock.TextTrimmingProperty, value, ValueNone) ]
        
    [<CustomOperation("textWrapping")>] 
    member _.textWrapping<'t>(x: Element, value: TextWrapping) =
        x @@ [ AttrBuilder<'t>.CreateProperty<TextWrapping>(TextBlock.TextWrappingProperty, value, ValueNone) ]