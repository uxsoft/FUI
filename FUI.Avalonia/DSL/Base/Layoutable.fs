module FUI.Avalonia.Layoutable

open Avalonia
open FUI.UiBuilder
open FUI.Avalonia
open Avalonia.Layout
          
type LayoutableBuilder<'t when 't :> Layoutable and 't : equality>() =
    inherit Visual.VisualBuilder<'t>()
    
    [<CustomOperation("width")>]
    member _.width<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x Layoutable.WidthProperty value
        
    [<CustomOperation("height")>]
    member _.height<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x Layoutable.HeightProperty value
        
    [<CustomOperation("minWidth")>]
    member _.minWidth<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x Layoutable.MinWidthProperty value
        
    [<CustomOperation("minHeight")>]
    member _.minHeight<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x Layoutable.MinHeightProperty value
  
    [<CustomOperation("maxWidth")>]
    member _.maxWidth<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x Layoutable.MaxWidthProperty value
        
    [<CustomOperation("maxHeight")>]
    member _.maxHeight<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x Layoutable.MaxHeightProperty value
        
    [<CustomOperation("margin")>]
    member _.margin<'t>(x: Types.AvaloniaNode<'t>, margin: Thickness) =
        Types.dependencyProperty x Layoutable.MarginProperty margin
        
    [<CustomOperation("horizontalAlignment")>]
    member _.horizontalAlignment<'t>(x: Types.AvaloniaNode<'t>, value: HorizontalAlignment) =
        Types.dependencyProperty x Layoutable.HorizontalAlignmentProperty value

    [<CustomOperation("verticalAlignment")>]
    member _.verticalAlignment<'t>(x: Types.AvaloniaNode<'t>, value: VerticalAlignment) =
        Types.dependencyProperty x Layoutable.VerticalAlignmentProperty value
       
    [<CustomOperation("useLayoutRounding")>]
    member _.useLayoutRounding<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x Layoutable.UseLayoutRoundingProperty value