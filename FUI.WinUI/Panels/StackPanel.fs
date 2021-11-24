namespace FUI.WinUI

open FUI.ObservableValue
open Microsoft.UI.Xaml.Controls
open Microsoft.UI.Xaml
open System
open Microsoft.UI.Xaml.Media

type StackPanelBuilder(controlType: Type) =
    inherit PanelBuilder(controlType)
    
    [<CustomOperation("AreScrollSnapPointsRegular")>]
    member _.AreScrollSnapPointsRegular(x, v: bool) =
        Runtime.dependencyProperty x (nameof StackPanel.AreScrollSnapPointsRegularProperty) StackPanel.AreScrollSnapPointsRegularProperty v
    
    [<CustomOperation("AreScrollSnapPointsRegular")>]
    member _.AreScrollSnapPointsRegular(x, v: bool IObservableValue) =
        Runtime.dependencyProperty x (nameof StackPanel.AreScrollSnapPointsRegularProperty) StackPanel.AreScrollSnapPointsRegularProperty v
    
        
    [<CustomOperation("BackgroundSizing")>]
    member _.BackgroundSizing(x, v: BackgroundSizing) =
        Runtime.dependencyProperty x (nameof StackPanel.BackgroundSizingProperty) StackPanel.BackgroundSizingProperty v
    
    [<CustomOperation("BackgroundSizing")>]
    member _.BackgroundSizing(x, v: BackgroundSizing IObservableValue) =
        Runtime.dependencyProperty x (nameof StackPanel.BackgroundSizingProperty) StackPanel.BackgroundSizingProperty v
    
        
    [<CustomOperation("BorderBrush")>]
    member _.BorderBrush(x, v: Brush) =
        Runtime.dependencyProperty x (nameof StackPanel.BorderBrushProperty) StackPanel.BorderBrushProperty v
    
    [<CustomOperation("BorderBrush")>]
    member _.BorderBrush(x, v: Brush IObservableValue) =
        Runtime.dependencyProperty x (nameof StackPanel.BorderBrushProperty) StackPanel.BorderBrushProperty v
    
        
    [<CustomOperation("BorderThickness")>]
    member _.BorderThickness(x, v: Thickness) =
        Runtime.dependencyProperty x (nameof StackPanel.BorderThicknessProperty) StackPanel.BorderThicknessProperty v
    
    [<CustomOperation("BorderThickness")>]
    member _.BorderThickness(x, v: Thickness IObservableValue) =
        Runtime.dependencyProperty x (nameof StackPanel.BorderThicknessProperty) StackPanel.BorderThicknessProperty v
    
        
    [<CustomOperation("CornerRadius")>]
    member _.CornerRadius(x, v: CornerRadius) =
        Runtime.dependencyProperty x (nameof StackPanel.CornerRadiusProperty) StackPanel.CornerRadiusProperty v
    
    [<CustomOperation("CornerRadius")>]
    member _.CornerRadius(x, v: CornerRadius IObservableValue) =
        Runtime.dependencyProperty x (nameof StackPanel.CornerRadiusProperty) StackPanel.CornerRadiusProperty v
    
        
    [<CustomOperation("Orientation")>]
    member _.Orientation(x, v: Orientation) =
        Runtime.dependencyProperty x (nameof StackPanel.OrientationProperty) StackPanel.OrientationProperty v
    
    [<CustomOperation("Orientation")>]
    member _.Orientation(x, v: Orientation IObservableValue) =
        Runtime.dependencyProperty x (nameof StackPanel.OrientationProperty) StackPanel.OrientationProperty v
    
        
    [<CustomOperation("Padding")>]
    member _.Padding(x, v: Thickness) =
        Runtime.dependencyProperty x (nameof StackPanel.PaddingProperty) StackPanel.PaddingProperty v
    
    [<CustomOperation("Padding")>]
    member _.Padding(x, v: Thickness IObservableValue) =
        Runtime.dependencyProperty x (nameof StackPanel.PaddingProperty) StackPanel.PaddingProperty v
    
        
    [<CustomOperation("Spacing")>]
    member _.Spacing(x, v: double) =
        Runtime.dependencyProperty x (nameof StackPanel.SpacingProperty) StackPanel.SpacingProperty v
    
    [<CustomOperation("Spacing")>]
    member _.Spacing(x, v: double IObservableValue) =
        Runtime.dependencyProperty x (nameof StackPanel.SpacingProperty) StackPanel.SpacingProperty v
        

    [<CustomOperation("HorizontalSnapPointsChanged")>]
    member _.HorizontalSnapPointsChanged(x, v) =
        Runtime.event x "HorizontalSnapPointsChanged" v (fun (c: StackPanel) -> c.add_HorizontalSnapPointsChanged) (fun (c: StackPanel) -> c.remove_HorizontalSnapPointsChanged)
    
    [<CustomOperation("VerticalSnapPointsChanged")>]
    member _.VerticalSnapPointsChanged(x, v) =
        Runtime.event x "VerticalSnapPointsChanged" v (fun (c: StackPanel) -> c.add_VerticalSnapPointsChanged) (fun (c: StackPanel) -> c.remove_VerticalSnapPointsChanged)
