module FUI.Avalonia.TemplatedControl

open FUI.UiBuilder
open FUI.Avalonia.Control
open Avalonia
open Avalonia.Media
open Avalonia.Controls.Primitives
open Avalonia.Controls.Templates

type TemplatedControlBuilder<'t when 't :> TemplatedControl>() =
    inherit ControlBuilder<'t>()
    
    [<CustomOperation("background")>] 
    member _.background<'t>(x: Node<_, _>, value: IBrush) =
        Types.dependencyProperty TemplatedControl.BackgroundProperty value

    [<CustomOperation("borderBrush")>] 
    member _.borderBrush<'t>(x: Node<_, _>, value: IBrush) =
        Types.dependencyProperty TemplatedControl.BorderBrushProperty value
        
    [<CustomOperation("borderThickness")>] 
    member _.borderThickness<'t>(x: Node<_, _>, value: Thickness) =
        Types.dependencyProperty TemplatedControl.BorderThicknessProperty value
        
    [<CustomOperation("fontFamily")>] 
    member _.fontFamily<'t>(x: Node<_, _>, value: FontFamily) =
        Types.dependencyProperty TemplatedControl.FontFamilyProperty value
        
    [<CustomOperation("fontSize")>] 
    member _.fontSize<'t>(x: Node<_, _>, value: double) =
        Types.dependencyProperty TemplatedControl.FontSizeProperty value
        
    [<CustomOperation("fontStyle")>] 
    member _.fontStyle<'t>(x: Node<_, _>, value: FontStyle) =
        Types.dependencyProperty TemplatedControl.FontStyleProperty value

    [<CustomOperation("fontWeight")>] 
    member _.fontWeight<'t>(x: Node<_, _>, value: FontWeight) =
        Types.dependencyProperty TemplatedControl.FontWeightProperty value
        
    [<CustomOperation("foreground")>] 
    member _.foreground<'t>(x: Node<_, _>, value: IBrush) =
        Types.dependencyProperty TemplatedControl.ForegroundProperty value
        
    [<CustomOperation("padding")>] 
    member _.padding<'t>(x: Node<_, _>, value: Thickness) =
        Types.dependencyProperty TemplatedControl.PaddingProperty value

    [<CustomOperation("template")>] 
    member _.template<'t>(x: Node<_, _>, value: IControlTemplate) =
        Types.dependencyProperty TemplatedControl.TemplateProperty value
    
    [<CustomOperation("isTemplateFocusTarget")>] 
    member _.isTemplateFocusTarget<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty TemplatedControl.IsTemplateFocusTargetProperty value