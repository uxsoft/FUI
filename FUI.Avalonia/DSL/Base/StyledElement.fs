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
        let getter : ('t -> obj) = (fun control -> box control.Classes)
        let setter : ('t * obj -> unit) = (fun (control, value) -> control.Classes <- (unbox<Classes> value))
        
        Types.property x "Classes" (Classes value) getter setter (fun () -> Classes() |> box)

    /// Use `classes` instead when possible.
    /// Styles | ObservableValue<Styles>
    [<CustomOperation("styles")>]
    member _.styles<'t, 'v>(x, value: 'v) =
        let getter : ('t -> obj) = (fun control -> box control.Styles)
        let setter : ('t * obj -> unit) = 
            (fun (control, value) -> 
                 control.Styles.Clear()
                 control.Styles.AddRange(unbox<Styles> value))

        Types.property x "Styles" value getter setter (fun () -> Styles() |> box)

    /// IResourceDictionary | ObservableValue<IResourceDictionary>
    [<CustomOperation("resources")>]
    member _.resources<'t, 'v>(x, value: 'v) =
        let getter : ('t -> obj) = (fun control -> box control.Resources)
        let setter : ('t * obj -> unit) = (fun (control, value) -> control.Resources <- unbox<IResourceDictionary> value)
        let factory = fun () -> ResourceDictionary() |> box
        
        Types.property x "Resources" value getter setter factory