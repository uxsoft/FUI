namespace FUI.Avalonia.StyledElement

open Avalonia
open FUI.Avalonia
open FUI.UiBuilder
open Avalonia.Styling
open Avalonia.Controls
        
type StyledElementBuilder<'t when 't :> StyledElement>() =
    inherit Animatable.AnimatableBuilder<'t>()
    
    [<CustomOperation("dataContext")>]
    member _.dataContext<'t>(x: Node<_, _>, dataContext: obj) =
        Types.dependencyProperty StyledElement.DataContextProperty dataContext
        
    [<CustomOperation("name")>]
    member _.name<'t>(x: Node<_, _>, name: string) =
        Types.dependencyProperty StyledElement.NameProperty name
        
    [<CustomOperation("templatedParent")>]
    member _.templatedParent<'t>(x: Node<_, _>, template: ITemplatedControl) =
        Types.dependencyProperty StyledElement.TemplatedParentProperty template
        
    [<CustomOperation("classes")>]
    member _.classes<'t>(x: Node<_, _>, value: string list) =
        let getter : ('t -> obj) = (fun control -> box control.Classes)
        let setter : ('t * obj -> unit) = (fun (control, value) -> control.Classes <- (unbox<Classes> value))
        
        Types.property<'t> "Classes" (Classes value) getter setter (fun () -> Classes() |> box)

    /// Use 'classes' instead when possible.
    [<CustomOperation("styles")>]
    member _.styles<'t>(x: Node<_, _>, value: Styles) =
        let getter : ('t -> obj) = (fun control -> box control.Styles)
        let setter : ('t * obj -> unit) = 
            (fun (control, value) -> 
                 control.Styles.Clear()
                 control.Styles.AddRange(unbox<Styles> value))

        Types.property "Styles" value getter setter (fun () -> Styles() |> box)

    [<CustomOperation("resources")>]
    member _.resources<'t>(x: Node<_, _>, value: IResourceDictionary) =
        let getter : ('t -> obj) = (fun control -> box control.Resources)
        let setter : ('t * obj -> unit) = (fun (control, value) -> control.Resources <- unbox<IResourceDictionary> value)
        let factory = fun () -> ResourceDictionary() |> box
        
        Types.property "Resources" value getter setter factory