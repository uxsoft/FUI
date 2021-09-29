module FUI.Avalonia.TemplatedControl

open FUI.UiBuilder
open FUI.Avalonia.Control
open Avalonia
open Avalonia.Media
open Avalonia.Controls.Primitives
open Avalonia.Controls.Templates

type TemplatedControlBuilder<'t when 't :> TemplatedControl and 't : equality>() =
    inherit ControlBuilder<'t>()
    
    [<CustomOperation("background")>] 
    member _.background<'t>(x: Types.AvaloniaNode<'t>, value: IBrush) =
        Types.dependencyProperty x TemplatedControl.BackgroundProperty value

    [<CustomOperation("borderBrush")>] 
    member _.borderBrush<'t>(x: Types.AvaloniaNode<'t>, value: IBrush) =
        Types.dependencyProperty x TemplatedControl.BorderBrushProperty value
        
    [<CustomOperation("borderThickness")>] 
    member _.borderThickness<'t>(x: Types.AvaloniaNode<'t>, value: Thickness) =
        Types.dependencyProperty x TemplatedControl.BorderThicknessProperty value
        
    [<CustomOperation("fontFamily")>] 
    member _.fontFamily<'t>(x: Types.AvaloniaNode<'t>, value: FontFamily) =
        Types.dependencyProperty x TemplatedControl.FontFamilyProperty value
        
    [<CustomOperation("fontSize")>] 
    member _.fontSize<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x TemplatedControl.FontSizeProperty value
        
    [<CustomOperation("fontStyle")>] 
    member _.fontStyle<'t>(x: Types.AvaloniaNode<'t>, value: FontStyle) =
        Types.dependencyProperty x TemplatedControl.FontStyleProperty value

    [<CustomOperation("fontWeight")>] 
    member _.fontWeight<'t>(x: Types.AvaloniaNode<'t>, value: FontWeight) =
        Types.dependencyProperty x TemplatedControl.FontWeightProperty value
        
    [<CustomOperation("foreground")>] 
    member _.foreground<'t>(x: Types.AvaloniaNode<'t>, value: IBrush) =
        Types.dependencyProperty x TemplatedControl.ForegroundProperty value
        
    [<CustomOperation("padding")>] 
    member _.padding<'t>(x: Types.AvaloniaNode<'t>, value: Thickness) =
        Types.dependencyProperty x TemplatedControl.PaddingProperty value

    [<CustomOperation("template")>] 
    member _.template<'t>(x: Types.AvaloniaNode<'t>, value: IControlTemplate) =
        Types.dependencyProperty x TemplatedControl.TemplateProperty value
    
    [<CustomOperation("isTemplateFocusTarget")>] 
    member _.isTemplateFocusTarget<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x TemplatedControl.IsTemplateFocusTargetProperty value