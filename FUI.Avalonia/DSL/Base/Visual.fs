module FUI.Avalonia.Visual

open Avalonia
open FUI.Avalonia
open FUI.UiBuilder
open Avalonia.Media
        
type VisualBuilder<'t when 't :> Visual>() =
    inherit StyledElement.StyledElementBuilder<'t>()

    [<CustomOperation("clipToBounds")>]
    member _.clipToBounds<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty Visual.ClipToBoundsProperty value
    
    [<CustomOperation("clip")>]
    member _.clip<'t>(x: Node<_, _>, mask: Geometry) =
        Types.dependencyProperty Visual.ClipProperty mask
        
    [<CustomOperation("isVisible")>]
    member _.isVisible<'t>(x: Node<_, _>, visible: bool) =
        Types.dependencyProperty Visual.IsVisibleProperty visible

    [<CustomOperation("opacity")>]
    member _.opacity<'t>(x: Node<_, _>, value: float) =
        Types.dependencyProperty Visual.IsVisibleProperty value
  
    [<CustomOperation("opacityMask")>]
    member _.opacityMask<'t>(x: Node<_, _>, value: IBrush) =
        Types.dependencyProperty Visual.OpacityMaskProperty value

    [<CustomOperation("renderTransform")>]
    member _.renderTransform<'t>(x: Node<_, _>, transform: Transform) =
        Types.dependencyProperty Visual.RenderTransformProperty transform

    [<CustomOperation("renderTransformOrigin")>]
    member _.renderTransformOrigin<'t>(x: Node<_, _>, origin: RelativePoint) =
        Types.dependencyProperty Visual.RenderTransformOriginProperty origin
        
    [<CustomOperation("zIndex")>]
    member _.zIndex<'t>(x: Node<_, _>, index: int) =
        Types.dependencyProperty Visual.ZIndexProperty index