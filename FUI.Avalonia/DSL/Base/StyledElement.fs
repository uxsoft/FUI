namespace Avalonia.FuncUI.Experiments.DSL.StyledElement

open Avalonia
open FUI.Avalonia
open FUI.UiBuilder
open Avalonia.FuncUI.Builder
open Avalonia.Styling
open Avalonia.Controls
open Avalonia.FuncUI.Experiments.DSL.Animatable
        
type StyledElementBuilder<'t when 't :> StyledElement>() =
    inherit AnimatableBuilder<'t>()
    
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
        let getter : ('t -> obj) = (fun control -> control.Classes :> obj)
        let setter : ('t * obj -> unit) = (fun (control, value) -> control.Classes <- (value :?> Classes))
        
        Types.property<'t> "Classes" (Classes value) getter setter (fun () -> Classes())

    /// Use 'classes' instead when possible.
    [<CustomOperation("styles")>]
    member _.styles<'t>(x: Node<_, _>, value: Styles) =
        let getter : ('t -> Styles) = (fun control -> control.Styles)
        let setter : ('t * Styles -> unit) = 
            (fun (control, value) -> 
                 control.Styles.Clear()
                 control.Styles.AddRange(value))

        Types.property "Styles" value getter setter (fun () -> Styles())

    [<CustomOperation("resources")>]
    member _.resources<'t>(x: Node<_, _>, value: IResourceDictionary) =
        let getter : ('t -> IResourceDictionary) = (fun control -> control.Resources)
        let setter : ('t * IResourceDictionary -> unit) = (fun (control, value) -> control.Resources <- value)
        let factory = fun () -> ResourceDictionary() :> IResourceDictionary
        
        Types.property "Resources" value getter setter factory