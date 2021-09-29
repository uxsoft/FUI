module FUI.Avalonia.Layoutable

open Avalonia
open FUI.UiBuilder
open FUI.Avalonia
open Avalonia.Layout
          
type LayoutableBuilder<'t when 't :> Layoutable>() =
    inherit Visual.VisualBuilder<'t>()
    
    [<CustomOperation("width")>]
    member _.width<'t>(x: Node<_, _>, value: double) =
        Types.dependencyProperty Layoutable.WidthProperty value
        
    [<CustomOperation("height")>]
    member _.height<'t>(x: Node<_, _>, value: double) =
        Types.dependencyProperty Layoutable.HeightProperty value
        
    [<CustomOperation("minWidth")>]
    member _.minWidth<'t>(x: Node<_, _>, value: double) =
        Types.dependencyProperty Layoutable.MinWidthProperty value
        
    [<CustomOperation("minHeight")>]
    member _.minHeight<'t>(x: Node<_, _>, value: double) =
        Types.dependencyProperty Layoutable.MinHeightProperty value
  
    [<CustomOperation("maxWidth")>]
    member _.maxWidth<'t>(x: Node<_, _>, value: double) =
        Types.dependencyProperty Layoutable.MaxWidthProperty value
        
    [<CustomOperation("maxHeight")>]
    member _.maxHeight<'t>(x: Node<_, _>, value: double) =
        Types.dependencyProperty Layoutable.MaxHeightProperty value
        
    [<CustomOperation("margin")>]
    member _.margin<'t>(x: Node<_, _>, margin: Thickness) =
        Types.dependencyProperty Layoutable.MarginProperty margin
        
    [<CustomOperation("horizontalAlignment")>]
    member _.horizontalAlignment<'t>(x: Node<_, _>, value: HorizontalAlignment) =
        Types.dependencyProperty Layoutable.HorizontalAlignmentProperty value

    [<CustomOperation("verticalAlignment")>]
    member _.verticalAlignment<'t>(x: Node<_, _>, value: VerticalAlignment) =
        Types.dependencyProperty Layoutable.VerticalAlignmentProperty value
       
    [<CustomOperation("useLayoutRounding")>]
    member _.useLayoutRounding<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty Layoutable.UseLayoutRoundingProperty value