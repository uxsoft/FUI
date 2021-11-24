namespace FUI.WinUI

open FUI.UiBuilder
open FUI.WinUI.Runtime
open Microsoft.UI.Xaml
open System

type WindowBuilder(controlType: Type) =
    inherit UiBuilder()

    member this.Run x =            
        this.RunWithChild<Window> x controlType (fun window child -> window.Content <- Runtime.toUIElement child)

    [<CustomOperation("Title")>]
    member _.Title(x, v: string) =
        let setter (a: Window, v') = a.Title <- unbox<string> v'
        let factory () = box ""
        Runtime.property x ("Title") v setter factory
        
    [<CustomOperation("ExtendsContentIntoTitleBar")>]
    member _.ExtendsContentIntoTitleBar(x, v: bool) =
        let setter (a: Window, v') = a.ExtendsContentIntoTitleBar <- unbox<bool> v'
        let factory () = box ""
        Runtime.property x ("ExtendsContentIntoTitleBar") v setter factory
        

//    [<CustomOperation("Activated")>]
//    member _.Activated(x, v) =
//        Runtime.event x "Activated" (fun (c: Window) ->  c.Activated.AddHandler) (fun (c: Window) -> c.Activated.RemoveHandler)
//        
//    [<CustomOperation("Closed")>]
//    member _.Closed(x, v) =
//        Runtime.event x "Closed" (fun (c: Window) ->  c.Closed.AddHandler) (fun (c: Window) -> c.Closed.RemoveHandler)
//        
//    [<CustomOperation("SizeChanged")>]
//    member _.SizeChanged(x, v) =
//        Runtime.event x "SizeChanged" (fun (c: Window) ->  c.SizeChanged.AddHandler) (fun (c: Window) -> c.SizeChanged.RemoveHandler)
//        
//    [<CustomOperation("VisibilityChanged")>]
//    member _.VisibilityChanged(x, v) =
//        Runtime.event x "VisibilityChanged" (fun (c: Window) ->  c.VisibilityChanged.AddHandler) (fun (c: Window) -> c.VisibilityChanged.RemoveHandler)