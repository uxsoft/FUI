module Avalonia.FuncUI.Experiments.DSL.Visual

open Avalonia
open FUI.UiBuilder
open Avalonia.FuncUI.Experiments.DSL.StyledElement
open Avalonia.Media
open Avalonia.FuncUI.Builder
        
type VisualBuilder<'t when 't :> Visual>() =
    inherit StyledElementBuilder<'t>()

    [<CustomOperation("clipToBounds")>]
    member _.clipToBounds<'t>(x: Node<_, _>, value: bool) =
        x @@ [  AttrBuilder<'t>.CreateProperty<bool>(Visual.ClipToBoundsProperty, value, ValueNone) ]
    
    [<CustomOperation("clip")>]
    member _.clip<'t>(x: Node<_, _>, mask: Geometry) =
        x @@ [  AttrBuilder<'t>.CreateProperty<Geometry>(Visual.ClipProperty, mask, ValueNone) ]
        
    [<CustomOperation("isVisible")>]
    member _.isVisible<'t>(x: Node<_, _>, visible: bool) =
        x @@ [  AttrBuilder<'t>.CreateProperty<bool>(Visual.IsVisibleProperty, visible, ValueNone) ]

    [<CustomOperation("opacity")>]
    member _.opacity<'t>(x: Node<_, _>, value: float) =
        x @@ [  AttrBuilder<'t>.CreateProperty<float>(Visual.IsVisibleProperty, value, ValueNone) ]
  
    [<CustomOperation("opacityMask")>]
    member _.opacityMask<'t>(x: Node<_, _>, value: IBrush) =
        x @@ [  AttrBuilder<'t>.CreateProperty<IBrush>(Visual.OpacityMaskProperty, value, ValueNone) ]

    [<CustomOperation("renderTransform")>]
    member _.renderTransform<'t>(x: Node<_, _>, transform: Transform) =
        x @@ [  AttrBuilder<'t>.CreateProperty<Transform>(Visual.RenderTransformProperty, transform, ValueNone) ]

    [<CustomOperation("renderTransformOrigin")>]
    member _.renderTransformOrigin<'t>(x: Node<_, _>, origin: RelativePoint) =
        x @@ [  AttrBuilder<'t>.CreateProperty<RelativePoint>(Visual.RenderTransformOriginProperty, origin, ValueNone) ]
        
    [<CustomOperation("zIndex")>]
    member _.zIndex<'t>(x: Node<_, _>, index: int) =
        x @@ [  AttrBuilder<'t>.CreateProperty<int>(Visual.ZIndexProperty, index, ValueNone) ]