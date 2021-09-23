module Avalonia.FuncUI.Experiments.DSL.Layoutable

open FUI.UIBuilder
open Avalonia.FuncUI.Experiments.DSL.Visual
open Avalonia.FuncUI.Builder
open Avalonia
open Avalonia.Layout
          
type LayoutableBuilder<'t when 't :> Layoutable>() =
    inherit VisualBuilder<'t>()
    
    [<CustomOperation("width")>]
    member _.width<'t>(x: Element, value: double) =
        x @@ [  AttrBuilder<'t>.CreateProperty<double>(Layoutable.WidthProperty, value, ValueNone) ]
        
    [<CustomOperation("height")>]
    member _.height<'t>(x: Element, value: double) =
        x @@ [  AttrBuilder<'t>.CreateProperty<double>(Layoutable.HeightProperty, value, ValueNone) ]
        
    [<CustomOperation("minWidth")>]
    member _.minWidth<'t>(x: Element, value: double) =
        x @@ [  AttrBuilder<'t>.CreateProperty<double>(Layoutable.MinWidthProperty, value, ValueNone) ]
        
    [<CustomOperation("minHeight")>]
    member _.minHeight<'t>(x: Element, value: double) =
        x @@ [  AttrBuilder<'t>.CreateProperty<double>(Layoutable.MinHeightProperty, value, ValueNone) ]
  
    [<CustomOperation("maxWidth")>]
    member _.maxWidth<'t>(x: Element, value: double) =
        x @@ [  AttrBuilder<'t>.CreateProperty<double>(Layoutable.MaxWidthProperty, value, ValueNone) ]
        
    [<CustomOperation("maxHeight")>]
    member _.maxHeight<'t>(x: Element, value: double) =
        x @@ [  AttrBuilder<'t>.CreateProperty<double>(Layoutable.MaxHeightProperty, value, ValueNone) ]
        
    [<CustomOperation("margin")>]
    member _.margin<'t>(x: Element, margin: Thickness) =
        x @@ [  AttrBuilder<'t>.CreateProperty<Thickness>(Layoutable.MarginProperty, margin, ValueNone) ]
        
    [<CustomOperation("horizontalAlignment")>]
    member _.horizontalAlignment<'t>(x: Element, value: HorizontalAlignment) =
        x @@ [  AttrBuilder<'t>.CreateProperty<HorizontalAlignment>(Layoutable.HorizontalAlignmentProperty, value, ValueNone) ]

    [<CustomOperation("verticalAlignment")>]
    member _.verticalAlignment<'t>(x: Element, value: VerticalAlignment) =
        x @@ [  AttrBuilder<'t>.CreateProperty<VerticalAlignment>(Layoutable.VerticalAlignmentProperty, value, ValueNone) ]
       
    [<CustomOperation("useLayoutRounding")>]
    member _.useLayoutRounding<'t>(x: Element, value: bool) =
        x @@ [  AttrBuilder<'t>.CreateProperty<bool>(Layoutable.UseLayoutRoundingProperty, value, ValueNone) ]