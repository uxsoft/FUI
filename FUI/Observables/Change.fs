module FUI.Change

open FUI.CollectionChange

let commit (items: System.Collections.Generic.IList<'t>) (change: CollectionChange<'t>) =
    match change with
    | Insert (index, item) ->
        items.Insert(index, item)
    | Remove (index, _) ->
        items.RemoveAt index
           
let map (mapItem: 'a -> 'b) (mapIndex: int -> int) (change: CollectionChange<'a>) =
    match change with    
    | Insert(index, item) ->
        Insert(mapIndex index, mapItem item)
    | Remove(index, item) ->
        Remove(mapIndex index, mapItem item)

let cast<'a, 'b> (change: CollectionChange<'a>) =
    map (fun i -> (box i) :?> 'b) id change
    
let box (change: CollectionChange<'t>) =
    map box id change
    
let filter (f: 't -> bool) (change: CollectionChange<'t>) =
    match change with    
    | Insert(_, item) -> f item
    | Remove(_, item) -> f item