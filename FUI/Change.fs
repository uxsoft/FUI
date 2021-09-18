module FUI.Change

open FUI.CollectionChange

let commit (items: System.Collections.Generic.IList<'t>) (change: CollectionChange<'t>) =
    match change with
    | Clear ->
        items.Clear()
    | Insert (index, item) ->
        items.Insert(index, item)
    | Move (oldIndex, newIndex, removedItem) ->
        let item = items.[oldIndex]
        items.RemoveAt oldIndex
        items.Insert(newIndex, item)
    | Remove (index, _) ->
        items.RemoveAt index
    | Replace (index, _, item) ->
        items.[index] <- item
           
let map (mapItem: 'a -> 'b) (mapIndex: int -> int) (change: CollectionChange<'a>) =
    match change with    
    | Clear ->
        Clear
    | Insert(index, item) ->
        Insert(mapIndex index, mapItem item)
    | Move(oldIndex, newIndex, item) ->
        Move(mapIndex oldIndex, mapIndex newIndex, mapItem item)
    | Remove(index, item) ->
        Remove(mapIndex index, mapItem item)
    | Replace(index, oldItem, item) ->
        Replace(mapIndex index, mapItem oldItem, mapItem item)

let cast<'a, 'b> (change: CollectionChange<'a>) =
    map (fun i -> (box i) :?> 'b) id change
    
let box (change: CollectionChange<'t>) =
    map box id change
    
let filter (f: 't -> bool) (change: CollectionChange<'t>) =
    match change with    
    | Clear -> true
    | Insert(_, item) -> f item
    | Move(_, _, item) -> f item
    | Remove(_, item) -> f item
    | Replace(_, _, item) -> f item