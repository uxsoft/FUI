module FUI.Avalonia.TextBlock
open Avalonia
open Avalonia.Media
open FUI.Avalonia.Patcher
open FUI.Avalonia.Control

open Avalonia.Controls

type TextBlockBuilder<'t when 't :> TextBlock and 't : equality>() =
    inherit ControlBuilder<'t>()
    
    member this.Run x =
        this.RunWithChild<'t> x (fun textBlock text ->
            textBlock.Text <- string text)
        
    /// string | ObservableValue<string>
    [<CustomOperation("text")>] 
    member _.text<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TextBlock.TextProperty value
        
    /// IBrush | ObservableValue<IBrush>
    [<CustomOperation("background")>] 
    member _.background<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TextBlock.BackgroundProperty value
    
    /// FontFamily | ObservableValue<FontFamily>
    [<CustomOperation("fontFamily")>] 
    member _.fontFamily<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TextBlock.FontFamilyProperty value
        
    /// double | ObservableValue<double>
    [<CustomOperation("fontSize")>] 
    member _.fontSize<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TextBlock.FontSizeProperty value
        
    /// FontStyle | ObservableValue<FontStyle>
    [<CustomOperation("fontStyle")>] 
    member _.fontStyle<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TextBlock.FontStyleProperty value
        
    /// FontWeight | ObservableValue<FontWeight>
    [<CustomOperation("fontWeight")>] 
    member _.fontWeight<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TextBlock.FontWeightProperty value
        
    /// IBrush | ObservableValue<IBrush>
    [<CustomOperation("foreground")>] 
    member _.foreground<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TextBlock.ForegroundProperty value

    /// float | ObservableValue<float>
    [<CustomOperation("lineHeight")>] 
    member _.lineHeight<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TextBlock.LineHeightProperty value
        
    /// int | ObservableValue<int>
    [<CustomOperation("maxLines")>] 
    member _.maxLines<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TextBlock.MaxLinesProperty value

    /// Thickness | ObservableValue<Thickness>
    [<CustomOperation("padding")>] 
    member _.padding<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TextBlock.PaddingProperty value

    /// TextAlignment | ObservableValue<TextAlignment>
    [<CustomOperation("textAlignment")>] 
    member _.textAlignment<'t, 'v>(x, alignment: 'v) =
        Types.dependencyProperty x TextBlock.TextAlignmentProperty alignment

    /// TextDecorationCollection | ObservableValue<TextDecorationCollection>
    [<CustomOperation("textDecorations")>] 
    member _.textDecorations<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TextBlock.TextDecorationsProperty value

    /// TextTrimming | ObservableValue<TextTrimming>
    [<CustomOperation("textTrimming")>] 
    member _.textTrimming<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TextBlock.TextTrimmingProperty value
        
    /// TextWrapping | ObservableValue<TextWrapping>
    [<CustomOperation("textWrapping")>] 
    member _.textWrapping<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TextBlock.TextWrappingProperty value