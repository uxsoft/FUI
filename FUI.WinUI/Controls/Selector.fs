namespace FUI.WinUI

open FUI.WinUI.Runtime
open FUI.ObservableValue
open Microsoft.UI.Xaml.Controls
open Microsoft.UI.Xaml
open System
open Microsoft.UI.Xaml.Controls.Primitives
open Microsoft.UI.Xaml.Media
open Windows.UI.Text

type SelectorBuilder(controlType: Type) =
    inherit ItemsControlBuilder(controlType)
    
        
    [<CustomOperation("CharacterSpacing")>]
    member _.CharacterSpacing(x, v: int) =
        dependencyProperty x (nameof TextBlock.CharacterSpacingProperty) TextBlock.CharacterSpacingProperty v


    [<CustomOperation("IsSynchronizedWithCurrentItem")>]
    member _.IsSynchronizedWithCurrentItem(x, v: bool) =
        dependencyProperty x (nameof Selector.IsSynchronizedWithCurrentItemProperty) Selector.IsSynchronizedWithCurrentItemProperty v
    
    [<CustomOperation("IsSynchronizedWithCurrentItem")>]
    member _.IsSynchronizedWithCurrentItem(x, v: bool IObservableValue) =
        dependencyProperty x (nameof Selector.IsSynchronizedWithCurrentItemProperty) Selector.IsSynchronizedWithCurrentItemProperty v
    
        
    [<CustomOperation("SelectedIndex")>]
    member _.SelectedIndex(x, v: int) =
        dependencyProperty x (nameof Selector.SelectedIndexProperty) Selector.SelectedIndexProperty v
    
    [<CustomOperation("SelectedIndex")>]
    member _.SelectedIndex(x, v: int IObservableValue) =
        dependencyProperty x (nameof Selector.SelectedIndexProperty) Selector.SelectedIndexProperty v
    
        
    [<CustomOperation("SelectedItem")>]
    member _.SelectedItem(x, v: 'v) =
        dependencyProperty x (nameof Selector.SelectedItemProperty) Selector.SelectedItemProperty v
    
    
    [<CustomOperation("SelectedValuePath")>]
    member _.SelectedValuePath(x, v: string) =
        dependencyProperty x (nameof Selector.SelectedValuePathProperty) Selector.SelectedValuePathProperty v
    
    [<CustomOperation("SelectedValuePath")>]
    member _.SelectedValuePath(x, v: string IObservableValue) =
        dependencyProperty x (nameof Selector.SelectedValuePathProperty) Selector.SelectedValuePathProperty v
    
        
    [<CustomOperation("SelectedValue")>]
    member _.SelectedValue(x, v: 'v) =
        dependencyProperty x (nameof Selector.SelectedValueProperty) Selector.SelectedValueProperty v

    [<CustomOperation("SelectedValue")>]
    member _.SelectedValue(x, v: 'v IObservableValue) =
        dependencyProperty x (nameof Selector.SelectedValueProperty) Selector.SelectedValueProperty v
        
    [<CustomOperation("SelectionChanged")>]
    member _.SelectionChanged(x, v) =
        event x "SelectionChanged" v (fun (c: Selector) -> c.SelectionChanged.AddHandler) (fun (c: Selector) -> c.SelectionChanged.RemoveHandler)
        