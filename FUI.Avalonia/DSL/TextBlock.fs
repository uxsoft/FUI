module FUI.Avalonia.TextBlock
open Avalonia
open Avalonia.Media
open FUI.Avalonia.Patcher
open FUI.Avalonia.Control

open Avalonia.Controls

type TextBlockBuilder<'t when 't :> TextBlock and 't : equality>() =
    inherit ControlBuilder<'t>()
    
    member this.Run x =
        this.RunWithChild x (fun textBlock text ->
            textBlock.Text <- string text)
        
    [<CustomOperation("text")>] 
    member _.text<'t>(x: Types.AvaloniaNode<'t>, value: string) =
        Types.dependencyProperty x TextBlock.TextProperty value
        
    [<CustomOperation("background")>] 
    member _.background<'t>(x: Types.AvaloniaNode<'t>, value: IBrush) =
        Types.dependencyProperty x TextBlock.BackgroundProperty value
    
    [<CustomOperation("fontFamily")>] 
    member _.fontFamily<'t>(x: Types.AvaloniaNode<'t>, value: FontFamily) =
        Types.dependencyProperty x TextBlock.FontFamilyProperty value
        
    [<CustomOperation("fontSize")>] 
    member _.fontSize<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x TextBlock.FontSizeProperty value
        
    [<CustomOperation("fontStyle")>] 
    member _.fontStyle<'t>(x: Types.AvaloniaNode<'t>, value: FontStyle) =
        Types.dependencyProperty x TextBlock.FontStyleProperty value
        
    [<CustomOperation("fontWeight")>] 
    member _.fontWeight<'t>(x: Types.AvaloniaNode<'t>, value: FontWeight) =
        Types.dependencyProperty x TextBlock.FontWeightProperty value
        
    [<CustomOperation("foreground")>] 
    member _.foreground<'t>(x: Types.AvaloniaNode<'t>, value: IBrush) =
        Types.dependencyProperty x TextBlock.ForegroundProperty value

    [<CustomOperation("lineHeight")>] 
    member _.lineHeight<'t>(x: Types.AvaloniaNode<'t>, value: float) =
        Types.dependencyProperty x TextBlock.LineHeightProperty value
        
    [<CustomOperation("maxLines")>] 
    member _.maxLines<'t>(x: Types.AvaloniaNode<'t>, value: int) =
        Types.dependencyProperty x TextBlock.MaxLinesProperty value

    [<CustomOperation("padding")>] 
    member _.padding<'t>(x: Types.AvaloniaNode<'t>, value: Thickness) =
        Types.dependencyProperty x TextBlock.PaddingProperty value

    [<CustomOperation("textAlignment")>] 
    member _.textAlignment<'t>(x: Types.AvaloniaNode<'t>, alignment: TextAlignment) =
        Types.dependencyProperty x TextBlock.TextAlignmentProperty alignment

    [<CustomOperation("textDecorations")>] 
    member _.textDecorations<'t>(x: Types.AvaloniaNode<'t>, value: TextDecorationCollection) =
        Types.dependencyProperty x TextBlock.TextDecorationsProperty value

    [<CustomOperation("textTrimming")>] 
    member _.textTrimming<'t>(x: Types.AvaloniaNode<'t>, value: TextTrimming) =
        Types.dependencyProperty x TextBlock.TextTrimmingProperty value
        
    [<CustomOperation("textWrapping")>] 
    member _.textWrapping<'t>(x: Types.AvaloniaNode<'t>, value: TextWrapping) =
        Types.dependencyProperty x TextBlock.TextWrappingProperty value