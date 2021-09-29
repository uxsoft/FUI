module FUI.Avalonia.Window

open Avalonia.Controls
open FUI.UiBuilder

type WindowBuilder<'t when 't :> Window>() =
    inherit TopLevel.TopLevelBuilder<'t>()
    member inline this.Run x =            
        this.RunWithChild x (fun window child -> window.Content <- child)
        
    [<CustomOperation("title")>]
    member inline _.title(x: Node<_, _>, v: string) =
        Types.dependencyProperty Window.TitleProperty v
        
//TODO window builder