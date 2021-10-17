module FUI.Avalonia.Layoutable

open Avalonia
open FUI.UiBuilder
open FUI.Avalonia
open Avalonia.Layout
          
type LayoutableBuilder<'t when 't :> Layoutable and 't : equality>() =
    inherit Visual.VisualBuilder<'t>()
    
    /// double | ObservableValue<double>
    [<CustomOperation("width")>]
    member _.width<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Layoutable.WidthProperty value
        
    /// double | ObservableValue<double>
    [<CustomOperation("height")>]
    member _.height<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Layoutable.HeightProperty value
        
    /// double | ObservableValue<double>
    [<CustomOperation("minWidth")>]
    member _.minWidth<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Layoutable.MinWidthProperty value
        
    /// double | ObservableValue<double>
    [<CustomOperation("minHeight")>]
    member _.minHeight<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Layoutable.MinHeightProperty value
  
    /// double | ObservableValue<double>
    [<CustomOperation("maxWidth")>]
    member _.maxWidth<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Layoutable.MaxWidthProperty value
        
    /// double | ObservableValue<double>
    [<CustomOperation("maxHeight")>]
    member _.maxHeight<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Layoutable.MaxHeightProperty value
        
    /// Thickness | ObservableValue<Thickness>
    [<CustomOperation("margin")>]
    member _.margin<'t, 'v>(x, margin: 'v) =
        Types.dependencyProperty x Layoutable.MarginProperty margin
        
    /// HorizontalAlignment | ObservableValue<HorizontalAlignment>
    [<CustomOperation("horizontalAlignment")>]
    member _.horizontalAlignment<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Layoutable.HorizontalAlignmentProperty value

    /// VerticalAlignment | ObservableValue<VerticalAlignment>
    [<CustomOperation("verticalAlignment")>]
    member _.verticalAlignment<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Layoutable.VerticalAlignmentProperty value
       
    /// bool | ObservableValue<bool>
    [<CustomOperation("useLayoutRounding")>]
    member _.useLayoutRounding<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x Layoutable.UseLayoutRoundingProperty value