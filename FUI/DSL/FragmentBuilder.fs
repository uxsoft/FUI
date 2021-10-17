module FUI.FragmentBuilder

open FUI.UiBuilder

type FragmentBuilder() =
    inherit UiBuilder()

    member _.Run (x: Node) = 
        Builder.build x.Children
    
let Fragment = FragmentBuilder()