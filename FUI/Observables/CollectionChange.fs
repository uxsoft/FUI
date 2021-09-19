module FUI.CollectionChange

type CollectionChange<'t> =
    | Remove of int * 't
    | Insert of int * 't
