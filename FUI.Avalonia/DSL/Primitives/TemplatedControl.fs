module FUI.Avalonia.TemplatedControl

open FUI.UiBuilder
open FUI.Avalonia.Control
open Avalonia
open Avalonia.Media
open Avalonia.Controls.Primitives
open Avalonia.Controls.Templates

type TemplatedControlBuilder<'t when 't :> TemplatedControl and 't : equality>() =
    inherit ControlBuilder<'t>()
    
    /// IBrush | ObservableValue<IBrush>
    [<CustomOperation("background")>]
    member _.background<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TemplatedControl.BackgroundProperty value

    /// IBrush | ObservableValue<IBrush>
    [<CustomOperation("borderBrush")>] 
    member _.borderBrush<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TemplatedControl.BorderBrushProperty value
        
    /// Thickness | ObservableValue<Thickness>
    [<CustomOperation("borderThickness")>] 
    member _.borderThickness<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TemplatedControl.BorderThicknessProperty value
        
    /// FontFamily | ObservableValue<FontFamily>
    [<CustomOperation("fontFamily")>] 
    member _.fontFamily<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TemplatedControl.FontFamilyProperty value
        
    /// double | ObservableValue<double>
    [<CustomOperation("fontSize")>] 
    member _.fontSize<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TemplatedControl.FontSizeProperty value
        
    /// FontStyle | ObservableValue<FontStyle>
    [<CustomOperation("fontStyle")>] 
    member _.fontStyle<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TemplatedControl.FontStyleProperty value

    /// FontWeight | ObservableValue<FontWeight>
    [<CustomOperation("fontWeight")>] 
    member _.fontWeight<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TemplatedControl.FontWeightProperty value
        
    /// IBrush | ObservableValue<IBrush>
    [<CustomOperation("foreground")>] 
    member _.foreground<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TemplatedControl.ForegroundProperty value
        
    /// Thickness | ObservableValue<Thickness>
    [<CustomOperation("padding")>] 
    member _.padding<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TemplatedControl.PaddingProperty value

    /// IControlTemplate | ObservableValue<IControlTemplate>
    [<CustomOperation("template")>] 
    member _.template<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TemplatedControl.TemplateProperty value
    
    /// bool | ObservableValue<bool>
    [<CustomOperation("isTemplateFocusTarget")>] 
    member _.isTemplateFocusTarget<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x TemplatedControl.IsTemplateFocusTargetProperty value