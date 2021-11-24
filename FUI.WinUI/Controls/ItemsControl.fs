namespace FUI.WinUI

open FUI.WinUI.Runtime
open FUI.ObservableValue
open Microsoft.UI.Xaml.Controls
open Microsoft.UI.Xaml
open System
open Microsoft.UI.Xaml.Controls.Primitives
open Microsoft.UI.Xaml.Media
open Microsoft.UI.Xaml.Media.Animation
open Windows.UI.Text

type ItemsControlBuilder(controlType: Type) =
    inherit ControlBuilder(controlType)
        
    [<CustomOperation("DisplayMemberPath")>]
    member _.DisplayMemberPath(x, v: string) =
        dependencyProperty x (nameof ItemsControl.DisplayMemberPathProperty) ItemsControl.DisplayMemberPathProperty v
    
    [<CustomOperation("DisplayMemberPath")>]
    member _.DisplayMemberPath(x, v: string IObservableValue) =
        dependencyProperty x (nameof ItemsControl.DisplayMemberPathProperty) ItemsControl.DisplayMemberPathProperty v
    
        
    [<CustomOperation("GroupStyleSelector")>]
    member _.GroupStyleSelector(x, v: GroupStyleSelector) =
        dependencyProperty x (nameof ItemsControl.GroupStyleSelectorProperty) ItemsControl.GroupStyleSelectorProperty v
    
    [<CustomOperation("GroupStyleSelector")>]
    member _.GroupStyleSelector(x, v: GroupStyleSelector IObservableValue) =
        dependencyProperty x (nameof ItemsControl.GroupStyleSelectorProperty) ItemsControl.GroupStyleSelectorProperty v
    
        
    [<CustomOperation("IsGrouping")>]
    member _.IsGrouping(x, v: bool) =
        dependencyProperty x (nameof ItemsControl.IsGroupingProperty) ItemsControl.IsGroupingProperty v
    
    [<CustomOperation("IsGrouping")>]
    member _.IsGrouping(x, v: bool IObservableValue) =
        dependencyProperty x (nameof ItemsControl.IsGroupingProperty) ItemsControl.IsGroupingProperty v
    
        
    [<CustomOperation("ItemContainerStyle")>]
    member _.ItemContainerStyle(x, v: Style) =
        dependencyProperty x (nameof ItemsControl.ItemContainerStyleProperty) ItemsControl.ItemContainerStyleProperty v
    
    [<CustomOperation("ItemContainerStyle")>]
    member _.ItemContainerStyle(x, v: Style IObservableValue) =
        dependencyProperty x (nameof ItemsControl.ItemContainerStyleProperty) ItemsControl.ItemContainerStyleProperty v
    
        
    [<CustomOperation("ItemContainerStyleSelector")>]
    member _.ItemContainerStyleSelector(x, v: StyleSelector) =
        dependencyProperty x (nameof ItemsControl.ItemContainerStyleSelectorProperty) ItemsControl.ItemContainerStyleSelectorProperty v
    
    [<CustomOperation("ItemContainerStyleSelector")>]
    member _.ItemContainerStyleSelector(x, v: StyleSelector IObservableValue) =
        dependencyProperty x (nameof ItemsControl.ItemContainerStyleSelectorProperty) ItemsControl.ItemContainerStyleSelectorProperty v
    
        
    [<CustomOperation("ItemContainerTransitions")>]
    member _.ItemContainerTransitions(x, v: TransitionCollection) =
        dependencyProperty x (nameof ItemsControl.ItemContainerTransitionsProperty) ItemsControl.ItemContainerTransitionsProperty v
    
    [<CustomOperation("ItemContainerTransitions")>]
    member _.ItemContainerTransitions(x, v: TransitionCollection IObservableValue) =
        dependencyProperty x (nameof ItemsControl.ItemContainerTransitionsProperty) ItemsControl.ItemContainerTransitionsProperty v
    
        
    [<CustomOperation("ItemTemplate")>]
    member _.ItemTemplate(x, v: DataTemplate) =
        dependencyProperty x (nameof ItemsControl.ItemTemplateProperty) ItemsControl.ItemTemplateProperty v
    
    [<CustomOperation("ItemTemplate")>]
    member _.ItemTemplate(x, v: DataTemplate IObservableValue) =
        dependencyProperty x (nameof ItemsControl.ItemTemplateProperty) ItemsControl.ItemTemplateProperty v
    
        
    [<CustomOperation("ItemTemplateSelector")>]
    member _.ItemTemplateSelector(x, v: DataTemplateSelector) =
        dependencyProperty x (nameof ItemsControl.ItemTemplateSelectorProperty) ItemsControl.ItemTemplateSelectorProperty v
    
    [<CustomOperation("ItemTemplateSelector")>]
    member _.ItemTemplateSelector(x, v: DataTemplateSelector IObservableValue) =
        dependencyProperty x (nameof ItemsControl.ItemTemplateSelectorProperty) ItemsControl.ItemTemplateSelectorProperty v
    
        
    [<CustomOperation("ItemsPanel")>]
    member _.ItemsPanel(x, v: Panel) =
        dependencyProperty x (nameof ItemsControl.ItemsPanelProperty) ItemsControl.ItemsPanelProperty v
    
    [<CustomOperation("ItemsPanel")>]
    member _.ItemsPanel(x, v: Panel IObservableValue) =
        dependencyProperty x (nameof ItemsControl.ItemsPanelProperty) ItemsControl.ItemsPanelProperty v
    
        
    [<CustomOperation("ItemsSource")>]
    member _.ItemsSource(x, v: 'v) =
        dependencyProperty x (nameof ItemsControl.ItemsSourceProperty) ItemsControl.ItemsSourceProperty v
            
    [<CustomOperation("ItemsSource")>]
    member _.ItemsSource(x, v: 'v IObservableValue) =
        dependencyProperty x (nameof ItemsControl.ItemsSourceProperty) ItemsControl.ItemsSourceProperty v
        