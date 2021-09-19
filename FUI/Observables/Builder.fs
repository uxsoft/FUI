module FUI.Builder

open FUI.ObservableCollection

type Builder<'t> = Block.Block<'t> list * 't list

let empty : Builder<'t> = [], []

let close ((closed, incoming): Builder<'t>) : Builder<'t> =
    if List.length incoming > 0 then
        closed @ [ Block.Static incoming ], []
    else closed, []    

let appendStatic (value: 't) ((closed, incoming): Builder<'t>) =
    closed, incoming @ [ value ]

let appendStatics (values: 't list) ((closed, incoming): Builder<'t>) =
    closed, incoming @ values 

let appendObservable (col) (builder: Builder<'t>) =
    let closed', _ = close builder
    closed' @ [ Block.Observable col ], []

let appendBlock (block: Block.Block<'t>) (builder: Builder<'t>) : Builder<'t> =    
    match block with
    | Block.Static col ->
        appendStatics col builder
    | Block.Observable col ->
        appendObservable col builder
    
let init (items: 't list) : Builder<'t> = 
    [], items
    
let append (a: Builder<'t>) (b: Builder<'t>) : Builder<'t> =
    let a, _ = close a
    let b, incoming = b
    a @ b, incoming
    
let build (builder: Builder<'t>) =
    let closed, _ = close builder
    let collections =
        closed
        |> List.map (function
            | Block.Static col ->
                ObservableCollection<'t>(col) :> IReadOnlyObservableCollection<'t>
            | Block.Observable col ->
                col)
    
    Oc.concat collections
   
let map (f: 'a -> 'b) (builder: Builder<'a>) : Builder<'b> =
    let closed, incoming = builder
    (closed |> List.map (Block.map f)), (incoming |> List.map f)

let concat (builders: Builder<'a> seq) =
    let closed =
        builders
        |> Seq.map close
        |> Seq.map fst
        |> Seq.concat
        |> Seq.toList
        
    closed, []