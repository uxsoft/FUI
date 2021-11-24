namespace FUI.WinUI

open FUI.WinUI.Runtime
open FUI.ObservableValue
open Microsoft.UI.Xaml.Controls
open Microsoft.UI.Xaml
open System
open Microsoft.UI.Xaml.Controls.Primitives
open Microsoft.UI.Xaml.Media
open Windows.UI.Text

type ComboBoxBuilder(controlType: Type) =
    inherit SelectorBuilder(controlType)

    [<CustomOperation("Description")>]
    member _.Description(x, v: 'v) =
        Runtime.dependencyProperty x (nameof ComboBox.DescriptionProperty) ComboBox.DescriptionProperty v
    
    [<CustomOperation("Description")>]
    member _.Description(x, v: 'v IObservableValue) =
        Runtime.dependencyProperty x (nameof ComboBox.DescriptionProperty) ComboBox.DescriptionProperty v
    
    
    [<CustomOperation("Header")>]
    member _.Header(x, v: 'v) =
        Runtime.dependencyProperty x (nameof ComboBox.HeaderProperty) ComboBox.HeaderProperty v
        
    [<CustomOperation("Header")>]
    member _.Header(x, v: 'v IObservableValue) =
        Runtime.dependencyProperty x (nameof ComboBox.HeaderProperty) ComboBox.HeaderProperty v
    
    
    [<CustomOperation("HeaderTemplate")>]
    member _.HeaderTemplate(x, v: DataTemplate) =
        Runtime.dependencyProperty x (nameof ComboBox.HeaderTemplateProperty) ComboBox.HeaderTemplateProperty v
        
    [<CustomOperation("HeaderTemplate")>]
    member _.HeaderTemplate(x, v: DataTemplate IObservableValue) =
        Runtime.dependencyProperty x (nameof ComboBox.HeaderTemplateProperty) ComboBox.HeaderTemplateProperty v
    
    
    [<CustomOperation("IsDropDownOpen")>]
    member _.IsDropDownOpen(x, v: bool) =
        Runtime.dependencyProperty x (nameof ComboBox.IsDropDownOpenProperty) ComboBox.IsDropDownOpenProperty v
        
    [<CustomOperation("IsDropDownOpen")>]
    member _.IsDropDownOpen(x, v: bool IObservableValue) =
        Runtime.dependencyProperty x (nameof ComboBox.IsDropDownOpenProperty) ComboBox.IsDropDownOpenProperty v
    
    
    [<CustomOperation("IsEditable")>]
    member _.IsEditable(x, v: bool) =
        Runtime.dependencyProperty x (nameof ComboBox.IsEditableProperty) ComboBox.IsEditableProperty v
        
    [<CustomOperation("IsEditable")>]
    member _.IsEditable(x, v: bool IObservableValue) =
        Runtime.dependencyProperty x (nameof ComboBox.IsEditableProperty) ComboBox.IsEditableProperty v
    
    
    [<CustomOperation("IsTextSearchEnabled")>]
    member _.IsTextSearchEnabled(x, v: bool) =
        Runtime.dependencyProperty x (nameof ComboBox.IsTextSearchEnabledProperty) ComboBox.IsTextSearchEnabledProperty v
        
    [<CustomOperation("IsTextSearchEnabled")>]
    member _.IsTextSearchEnabled(x, v: bool IObservableValue) =
        Runtime.dependencyProperty x (nameof ComboBox.IsTextSearchEnabledProperty) ComboBox.IsTextSearchEnabledProperty v
    
    
    [<CustomOperation("LightDismissOverlayMode")>]
    member _.LightDismissOverlayMode(x, v: LightDismissOverlayMode) =
        Runtime.dependencyProperty x (nameof ComboBox.LightDismissOverlayModeProperty) ComboBox.LightDismissOverlayModeProperty v
        
    [<CustomOperation("LightDismissOverlayMode")>]
    member _.LightDismissOverlayMode(x, v: LightDismissOverlayMode IObservableValue) =
        Runtime.dependencyProperty x (nameof ComboBox.LightDismissOverlayModeProperty) ComboBox.LightDismissOverlayModeProperty v
    
    
    [<CustomOperation("MaxDropDownHeight")>]
    member _.MaxDropDownHeight(x, v: double) =
        Runtime.dependencyProperty x (nameof ComboBox.MaxDropDownHeightProperty) ComboBox.MaxDropDownHeightProperty v
        
    [<CustomOperation("MaxDropDownHeight")>]
    member _.MaxDropDownHeight(x, v: double IObservableValue) =
        Runtime.dependencyProperty x (nameof ComboBox.MaxDropDownHeightProperty) ComboBox.MaxDropDownHeightProperty v
    
    
    [<CustomOperation("PlaceholderForeground")>]
    member _.PlaceholderForeground(x, v: Brush) =
        Runtime.dependencyProperty x (nameof ComboBox.PlaceholderForegroundProperty) ComboBox.PlaceholderForegroundProperty v
        
    [<CustomOperation("PlaceholderForeground")>]
    member _.PlaceholderForeground(x, v: Brush IObservableValue) =
        Runtime.dependencyProperty x (nameof ComboBox.PlaceholderForegroundProperty) ComboBox.PlaceholderForegroundProperty v
    
    
    [<CustomOperation("PlaceholderText")>]
    member _.PlaceholderText(x, v: string) =
        Runtime.dependencyProperty x (nameof ComboBox.PlaceholderTextProperty) ComboBox.PlaceholderTextProperty v
        
    [<CustomOperation("PlaceholderText")>]
    member _.PlaceholderText(x, v: string IObservableValue) =
        Runtime.dependencyProperty x (nameof ComboBox.PlaceholderTextProperty) ComboBox.PlaceholderTextProperty v
    
    
    [<CustomOperation("SelectionChangedTrigger")>]
    member _.SelectionChangedTrigger(x, v: ComboBoxSelectionChangedTrigger) =
        Runtime.dependencyProperty x (nameof ComboBox.SelectionChangedTriggerProperty) ComboBox.SelectionChangedTriggerProperty v
        
    [<CustomOperation("SelectionChangedTrigger")>]
    member _.SelectionChangedTrigger(x, v: ComboBoxSelectionChangedTrigger IObservableValue) =
        Runtime.dependencyProperty x (nameof ComboBox.SelectionChangedTriggerProperty) ComboBox.SelectionChangedTriggerProperty v
    
    
    [<CustomOperation("TextBoxStyle")>]
    member _.TextBoxStyle(x, v: Style) =
        Runtime.dependencyProperty x (nameof ComboBox.TextBoxStyleProperty) ComboBox.TextBoxStyleProperty v
        
    [<CustomOperation("TextBoxStyle")>]
    member _.TextBoxStyle(x, v: Style IObservableValue) =
        Runtime.dependencyProperty x (nameof ComboBox.TextBoxStyleProperty) ComboBox.TextBoxStyleProperty v
    
    
    [<CustomOperation("Text")>]
    member _.Text(x, v: string) =
        Runtime.dependencyProperty x (nameof ComboBox.TextProperty) ComboBox.TextProperty v
        
    [<CustomOperation("Text")>]
    member _.Text(x, v: string IObservableValue) =
        Runtime.dependencyProperty x (nameof ComboBox.TextProperty) ComboBox.TextProperty v
        
        
    [<CustomOperation("DropDownClosed")>]
    member _.DropDownClosed(x, v) =
        Runtime.event x "DropDownClosed" v (fun (c: ComboBox) -> c.add_DropDownClosed) (fun (c: ComboBox) -> c.remove_DropDownClosed)
        
    [<CustomOperation("DropDownOpened")>]
    member _.DropDownOpened(x, v) =
        Runtime.event x "DropDownOpened" v (fun (c: ComboBox) -> c.add_DropDownOpened) (fun (c: ComboBox) -> c.remove_DropDownOpened)
        
    [<CustomOperation("TextSubmitted")>]
    member _.TextSubmitted(x, v) =
        Runtime.event x "TextSubmitted" v (fun (c: ComboBox) -> c.add_TextSubmitted) (fun (c: ComboBox) -> c.remove_TextSubmitted)
        
