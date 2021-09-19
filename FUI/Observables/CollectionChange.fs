module FUI.CollectionChange

type CollectionChange<'t> =
    | Clear
    | Remove of int * 't
    | Insert of int * 't
    | Replace of int * 't * 't
    | Move of int * int * 't