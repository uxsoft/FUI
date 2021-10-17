module FUI.Avalonia.StyledElement

open Avalonia
open FUI.Avalonia
open FUI.UiBuilder
open Avalonia.Styling
open Avalonia.Controls
        
type StyledElementBuilder<'t when 't :> StyledElement and 't : equality>() =
    inherit Animatable.AnimatableBuilder<'t>()
    
    /// obj
    [<CustomOperation("dataContext")>]
    member _.dataContext<'t, 'v>(x, dataContext: 'v) =
        Types.dependencyProperty x StyledElement.DataContextProperty dataContext
        
    /// string | ObservableValue<string>
    [<CustomOperation("name")>]
    member _.name<'t, 'v>(x, name: 'v) =
        Types.dependencyProperty x StyledElement.NameProperty name
    
    /// ITemplatedControl | ObservableValue<ITemplatedControl>
    [<CustomOperation("templatedParent")>]
    member _.templatedParent<'t, 'v>(x, template: 'v) =
        Types.dependencyProperty x StyledElement.TemplatedParentProperty template

    /// string list
    [<CustomOperation("classes")>]
    member _.classes<'t>(x, value: string list) =
        let setter : ('t * obj -> unit) = (fun (control, value) -> control.Classes <- (unbox<Classes> value))
        let factory() = Classes() |> box
        Types.property x "Classes" (Classes value) setter factory

    /// Use `classes` instead when possible.
    /// Styles | ObservableValue<Styles>
    [<CustomOperation("styles")>]
    member _.styles<'t, 'v>(x, value: 'v) =
        let setter : ('t * obj -> unit) = 
            (fun (control, value) -> 
                 control.Styles.Clear()
                 control.Styles.AddRange(unbox<Styles> value))
        let factory() = Styles() |> box
        Types.property x "Styles" value setter factory

    /// IResourceDictionary | ObservableValue<IResourceDictionary>
    [<CustomOperation("resources")>]
    member _.resources<'t, 'v>(x, value: 'v) =
        let setter : ('t * obj -> unit) = (fun (control, value) -> control.Resources <- unbox<IResourceDictionary> value)
        let factory() = ResourceDictionary() |> box
        Types.property x "Resources" value setter factory