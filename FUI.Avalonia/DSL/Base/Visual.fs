module FUI.Avalonia.Visual

open Avalonia
open FUI.Avalonia
open FUI.UiBuilder
open Avalonia.Media
        
type VisualBuilder<'t when 't :> Visual and 't : equality>() =
    inherit StyledElement.StyledElementBuilder<'t>()

    [<CustomOperation("clipToBounds")>]
    member _.clipToBounds<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x Visual.ClipToBoundsProperty value
    
    [<CustomOperation("clip")>]
    member _.clip<'t>(x: Types.AvaloniaNode<'t>, mask: Geometry) =
        Types.dependencyProperty x Visual.ClipProperty mask
        
    [<CustomOperation("isVisible")>]
    member _.isVisible<'t>(x: Types.AvaloniaNode<'t>, visible: bool) =
        Types.dependencyProperty x Visual.IsVisibleProperty visible

    [<CustomOperation("opacity")>]
    member _.opacity<'t>(x: Types.AvaloniaNode<'t>, value: float) =
        Types.dependencyProperty x Visual.IsVisibleProperty value
  
    [<CustomOperation("opacityMask")>]
    member _.opacityMask<'t>(x: Types.AvaloniaNode<'t>, value: IBrush) =
        Types.dependencyProperty x Visual.OpacityMaskProperty value

    [<CustomOperation("renderTransform")>]
    member _.renderTransform<'t>(x: Types.AvaloniaNode<'t>, transform: Transform) =
        Types.dependencyProperty x Visual.RenderTransformProperty transform

    [<CustomOperation("renderTransformOrigin")>]
    member _.renderTransformOrigin<'t>(x: Types.AvaloniaNode<'t>, origin: RelativePoint) =
        Types.dependencyProperty x Visual.RenderTransformOriginProperty origin
        
    [<CustomOperation("zIndex")>]
    member _.zIndex<'t>(x: Types.AvaloniaNode<'t>, index: int) =
        Types.dependencyProperty x Visual.ZIndexProperty index