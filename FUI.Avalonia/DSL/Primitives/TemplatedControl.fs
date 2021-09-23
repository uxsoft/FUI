module Avalonia.FuncUI.Experiments.DSL.TemplatedControl

open FUI.UIBuilder
open Avalonia.FuncUI.Experiments.DSL.Control
open Avalonia
open Avalonia.FuncUI.Builder
open Avalonia.Media
open Avalonia.Controls.Primitives
open Avalonia.Controls.Templates

type TemplatedControlBuilder<'t when 't :> TemplatedControl>() =
    inherit ControlBuilder<'t>()
    
    [<CustomOperation("background")>] 
    member _.background<'t>(x: Element, value: IBrush) =
        x @@ [ AttrBuilder<'t>.CreateProperty<IBrush>(TemplatedControl.BackgroundProperty, value, ValueNone) ]

    [<CustomOperation("borderBrush")>] 
    member _.borderBrush<'t>(x: Element, value: IBrush) =
        x @@ [ AttrBuilder<'t>.CreateProperty<IBrush>(TemplatedControl.BorderBrushProperty, value, ValueNone) ]
        
    [<CustomOperation("borderThickness")>] 
    member _.borderThickness<'t>(x: Element, value: Thickness) =
        x @@ [ AttrBuilder<'t>.CreateProperty<Thickness>(TemplatedControl.BorderThicknessProperty, value, ValueNone) ]
        
    [<CustomOperation("fontFamily")>] 
    member _.fontFamily<'t>(x: Element, value: FontFamily) =
        x @@ [ AttrBuilder<'t>.CreateProperty<FontFamily>(TemplatedControl.FontFamilyProperty, value, ValueNone) ]
        
    [<CustomOperation("fontSize")>] 
    member _.fontSize<'t>(x: Element, value: double) =
        x @@ [ AttrBuilder<'t>.CreateProperty<double>(TemplatedControl.FontSizeProperty, value, ValueNone) ]
        
    [<CustomOperation("fontStyle")>] 
    member _.fontStyle<'t>(x: Element, value: FontStyle) =
        x @@ [ AttrBuilder<'t>.CreateProperty<FontStyle>(TemplatedControl.FontStyleProperty, value, ValueNone) ]

    [<CustomOperation("fontWeight")>] 
    member _.fontWeight<'t>(x: Element, value: FontWeight) =
        x @@ [ AttrBuilder<'t>.CreateProperty<FontWeight>(TemplatedControl.FontWeightProperty, value, ValueNone) ]
        
    [<CustomOperation("foreground")>] 
    member _.foreground<'t>(x: Element, value: IBrush) =
        x @@ [ AttrBuilder<'t>.CreateProperty<IBrush>(TemplatedControl.ForegroundProperty, value, ValueNone) ]
        
    [<CustomOperation("padding")>] 
    member _.padding<'t>(x: Element, value: Thickness) =
        x @@ [ AttrBuilder<'t>.CreateProperty<Thickness>(TemplatedControl.PaddingProperty, value, ValueNone) ]

    [<CustomOperation("template")>] 
    member _.template<'t>(x: Element, value: IControlTemplate) =
        x @@ [ AttrBuilder<'t>.CreateProperty<IControlTemplate>(TemplatedControl.TemplateProperty, value, ValueNone) ]  
    
    [<CustomOperation("isTemplateFocusTarget")>] 
    member _.isTemplateFocusTarget<'t>(x: Element, value: bool) =
        x @@ [ AttrBuilder<'t>.CreateProperty<bool>(TemplatedControl.IsTemplateFocusTargetProperty, value, ValueNone) ]  