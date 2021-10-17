module FUI.Avalonia.Visual

open Avalonia
open FUI.Avalonia
open FUI.UiBuilder
open Avalonia.Media
        
type VisualBuilder<'t when 't :> Visual and 't : equality>() =
    inherit StyledElement.StyledElementBuilder<'t>()

    /// bool | ObservableValue<bool>
    [<CustomOperation("clipToBounds")>]
    member _.clipToBounds<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Visual.ClipToBoundsProperty value
    
    /// Geometry | ObservableValue<Geometry>
    [<CustomOperation("clip")>]
    member _.clip<'t, 'v>(x, mask: 'v) =
        Types.dependencyProperty x Visual.ClipProperty mask
        
    /// bool | ObservableValue<bool>
    [<CustomOperation("isVisible")>]
    member _.isVisible<'t, 'v>(x, visible: 'v) =
        Types.dependencyProperty x Visual.IsVisibleProperty visible

    /// float | ObservableValue<float>
    [<CustomOperation("opacity")>]
    member _.opacity<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Visual.IsVisibleProperty value
  
    /// IBrush | ObservableValue<IBrush>
    [<CustomOperation("opacityMask")>]
    member _.opacityMask<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Visual.OpacityMaskProperty value

    /// Transform | ObservableValue<Transform>
    [<CustomOperation("renderTransform")>]
    member _.renderTransform<'t, 'v>(x, transform: 'v) =
        Types.dependencyProperty x Visual.RenderTransformProperty transform

    /// RelativePoint | ObservableValue<RelativePoint>
    [<CustomOperation("renderTransformOrigin")>]
    member _.renderTransformOrigin<'t, 'v>(x, origin: 'v) =
        Types.dependencyProperty x Visual.RenderTransformOriginProperty origin
        
    /// int | ObservableValue<int>
    [<CustomOperation("zIndex")>]
    member _.zIndex<'t, 'v>(x, index: 'v) =
        Types.dependencyProperty x Visual.ZIndexProperty index