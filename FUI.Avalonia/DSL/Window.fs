module FUI.Avalonia.Window

open Avalonia.Controls
open FUI.Avalonia.Patcher

type WindowBuilder<'t when 't :> Window and 't : equality>() =
    inherit TopLevel.TopLevelBuilder<'t>()
    member inline this.Run x =            
        this.RunWithChild x (fun window child -> window.Content <- child)
        
    [<CustomOperation("title")>]
    member inline _.title(x: Types.AvaloniaNode<'t>, v: string) =
        Types.dependencyProperty x Window.TitleProperty v
        
//TODO window builder