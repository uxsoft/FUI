module Avalonia.FuncUI.Experiments.DSL.TemplatedControl

open FUI.UiBuilder
open Avalonia.FuncUI.Experiments.DSL.Control
open Avalonia
open Avalonia.FuncUI.Builder
open Avalonia.Media
open Avalonia.Controls.Primitives
open Avalonia.Controls.Templates

type TemplatedControlBuilder<'t when 't :> TemplatedControl>() =
    inherit ControlBuilder<'t>()
    
    [<CustomOperation("background")>] 
    member _.background<'t>(x: Node<_, _>, value: IBrush) =
        Types.dependencyProperty<IBrush>(TemplatedControl.BackgroundProperty, value, ValueNone) ]

    [<CustomOperation("borderBrush")>] 
    member _.borderBrush<'t>(x: Node<_, _>, value: IBrush) =
        Types.dependencyProperty<IBrush>(TemplatedControl.BorderBrushProperty, value, ValueNone) ]
        
    [<CustomOperation("borderThickness")>] 
    member _.borderThickness<'t>(x: Node<_, _>, value: Thickness) =
        Types.dependencyProperty<Thickness>(TemplatedControl.BorderThicknessProperty, value, ValueNone) ]
        
    [<CustomOperation("fontFamily")>] 
    member _.fontFamily<'t>(x: Node<_, _>, value: FontFamily) =
        Types.dependencyProperty<FontFamily>(TemplatedControl.FontFamilyProperty, value, ValueNone) ]
        
    [<CustomOperation("fontSize")>] 
    member _.fontSize<'t>(x: Node<_, _>, value: double) =
        Types.dependencyProperty<double>(TemplatedControl.FontSizeProperty, value, ValueNone) ]
        
    [<CustomOperation("fontStyle")>] 
    member _.fontStyle<'t>(x: Node<_, _>, value: FontStyle) =
        Types.dependencyProperty<FontStyle>(TemplatedControl.FontStyleProperty, value, ValueNone) ]

    [<CustomOperation("fontWeight")>] 
    member _.fontWeight<'t>(x: Node<_, _>, value: FontWeight) =
        Types.dependencyProperty<FontWeight>(TemplatedControl.FontWeightProperty, value, ValueNone) ]
        
    [<CustomOperation("foreground")>] 
    member _.foreground<'t>(x: Node<_, _>, value: IBrush) =
        Types.dependencyProperty<IBrush>(TemplatedControl.ForegroundProperty, value, ValueNone) ]
        
    [<CustomOperation("padding")>] 
    member _.padding<'t>(x: Node<_, _>, value: Thickness) =
        Types.dependencyProperty<Thickness>(TemplatedControl.PaddingProperty, value, ValueNone) ]

    [<CustomOperation("template")>] 
    member _.template<'t>(x: Node<_, _>, value: IControlTemplate) =
        Types.dependencyProperty<IControlTemplate>(TemplatedControl.TemplateProperty, value, ValueNone) ]  
    
    [<CustomOperation("isTemplateFocusTarget")>] 
    member _.isTemplateFocusTarget<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(TemplatedControl.IsTemplateFocusTargetProperty, value, ValueNone) ]  