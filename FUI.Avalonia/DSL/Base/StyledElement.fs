module FUI.Avalonia.StyledElement

open Avalonia
open FUI.Avalonia
open FUI.UiBuilder
open Avalonia.Styling
open Avalonia.Controls
        
type StyledElementBuilder<'t when 't :> StyledElement and 't : equality>() =
    inherit Animatable.AnimatableBuilder<'t>()
    
    [<CustomOperation("dataContext")>]
    member _.dataContext<'t>(x: Types.AvaloniaNode<'t>, dataContext: obj) =
        Types.dependencyProperty x StyledElement.DataContextProperty dataContext
        
    [<CustomOperation("name")>]
    member _.name<'t>(x: Types.AvaloniaNode<'t>, name: string) =
        Types.dependencyProperty x StyledElement.NameProperty name
        
    [<CustomOperation("templatedParent")>]
    member _.templatedParent<'t>(x: Types.AvaloniaNode<'t>, template: ITemplatedControl) =
        Types.dependencyProperty x StyledElement.TemplatedParentProperty template
        
    [<CustomOperation("classes")>]
    member _.classes<'t>(x: Types.AvaloniaNode<'t>, value: string list) =
        let getter : ('t -> obj) = (fun control -> box control.Classes)
        let setter : ('t * obj -> unit) = (fun (control, value) -> control.Classes <- (unbox<Classes> value))
        
        Types.property x "Classes" (Classes value) getter setter (fun () -> Classes() |> box)

    /// Use 'classes' instead when possible.
    [<CustomOperation("styles")>]
    member _.styles<'t>(x: Types.AvaloniaNode<'t>, value: Styles) =
        let getter : ('t -> obj) = (fun control -> box control.Styles)
        let setter : ('t * obj -> unit) = 
            (fun (control, value) -> 
                 control.Styles.Clear()
                 control.Styles.AddRange(unbox<Styles> value))

        Types.property x "Styles" value getter setter (fun () -> Styles() |> box)

    [<CustomOperation("resources")>]
    member _.resources<'t>(x: Types.AvaloniaNode<'t>, value: IResourceDictionary) =
        let getter : ('t -> obj) = (fun control -> box control.Resources)
        let setter : ('t * obj -> unit) = (fun (control, value) -> control.Resources <- unbox<IResourceDictionary> value)
        let factory = fun () -> ResourceDictionary() |> box
        
        Types.property x "Resources" value getter setter factory