module FUI.Block

open FUI
open FUI.ObservableCollection

type Block<'t> =
    | Static of 't list
    | Observable of IReadOnlyObservableCollection<'t>

let map (f: 'a -> 'b) (block: Block<'a>) : Block<'b> =
    match block with
    | Static col -> Static (List.map f col)
    | Observable col -> Observable (Oc.map f col)