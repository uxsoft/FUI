module FUI.Oc

open System.Collections.ObjectModel
open FUI.CollectionChange
open FUI.ObservableCollection
open FUI.CompositeObservableCollection

let empty<'t> = ObservableCollection<'t>([])

let toSeq' (col: IReadOnlyObservableCollection) =
    seq { for i in col do i }

type MappedReadOnlyObservableCollection<'a, 'b when 'b : equality>(f: 'a -> 'b, source: IReadOnlyObservableCollection<'a>) =
    interface IReadOnlyObservableCollection<'b> with
        member this.Count = source.Count
        member this.Get (index: int) = f (source.Get index)
        member this.Get (index: int): obj = source.Get index |> f |> box
        member this.GetEnumerator(): System.Collections.Generic.IEnumerator<'b> =
            (source |> Seq.map f).GetEnumerator()
        member this.GetEnumerator(): System.Collections.IEnumerator =
            ((source |> Seq.map f) :> System.Collections.IEnumerable).GetEnumerator()
        member this.IndexOf (item: 'b): int =
            source |> Seq.findIndex (fun i -> item = f i)
        member this.IndexOf (item: obj): int =
            source |> toSeq' |> Seq.findIndex (fun i -> item.Equals(f (i :?> 'a)))
        member this.OnChanged : IEvent<CollectionChange<'b>> =
            Event.map (Change.map f id) source.OnChanged
        member this.OnChanged : IEvent<CollectionChange<obj>> =
            Event.map (fun c -> c |> Change.map f id |> Change.box) source.OnChanged
        
type MappedReadOnlyObservableCollection<'b when 'b : equality>(f: obj -> 'b, source: IReadOnlyObservableCollection) =
    interface IReadOnlyObservableCollection<'b> with
        member this.Count = source.Count
        member this.Get (index: int) = f (source.Get index)
        member this.Get (index: int): obj = source.Get index |> f |> box
        member this.GetEnumerator(): System.Collections.Generic.IEnumerator<'b> =
            (source |> toSeq' |> Seq.map f).GetEnumerator()
        member this.GetEnumerator(): System.Collections.IEnumerator =
            ((source |> toSeq' |> Seq.map f) :> System.Collections.IEnumerable).GetEnumerator()
        member this.IndexOf (item: 'b): int =
            source |> toSeq' |> Seq.findIndex (fun i -> item = f i)
        member this.IndexOf (item: obj): int =
            source |> toSeq' |> Seq.findIndex (fun i -> item.Equals(f i))
        member this.OnChanged : IEvent<CollectionChange<'b>> =
            Event.map (Change.map f id) source.OnChanged
        member this.OnChanged : IEvent<CollectionChange<obj>> =
            Event.map (fun c -> c |> Change.map f id |> Change.box) source.OnChanged

let map f (col: IReadOnlyObservableCollection<'a>) =
    MappedReadOnlyObservableCollection<'a, 'b>(f, col) :> IReadOnlyObservableCollection<'b>
    
let map' (f: obj -> 'b) (col: IReadOnlyObservableCollection) =
    MappedReadOnlyObservableCollection<'b>(f, col) :> IReadOnlyObservableCollection<'b>

let append (a: IReadOnlyObservableCollection<'t>) (b: IReadOnlyObservableCollection<'t>) =
    CompositeObservableCollection([| a; b |]) :> IReadOnlyObservableCollection<'t>

let append' (a: IReadOnlyObservableCollection) (b: IReadOnlyObservableCollection) =
    CompositeObservableCollection([| a; b |]) :> IReadOnlyObservableCollection
    
let concat (collections: IReadOnlyObservableCollection<'t> seq) =
    CompositeObservableCollection(collections) :> IReadOnlyObservableCollection<'t>

let concat' (collections: IReadOnlyObservableCollection seq) =
    CompositeObservableCollection(collections) :> IReadOnlyObservableCollection
    
let flatten (collections: IReadOnlyObservableCollection<IReadOnlyObservableCollection<'t>>)  =
    CompositeObservableCollection(collections) :> IReadOnlyObservableCollection<'t>
   
type FilteredReadOnlyObservableCollection<'t when 't : equality>(f: 't -> bool, source: IReadOnlyObservableCollection<'t>) =
    let filteredSource() =
        source
        |> Seq.filter f
        |> Seq.toArray
    
    let mutable itemsCache = filteredSource() 
            
    do source.OnChanged.Add(fun _ -> itemsCache <- filteredSource())
    
    interface IReadOnlyObservableCollection<'t> with
        member this.Count = itemsCache.Length
        member this.Get (index: int) : 't = itemsCache.[index]
        member this.Get (index: int): obj = itemsCache.[index] |> box
        member this.GetEnumerator(): System.Collections.Generic.IEnumerator<'t> =
            (itemsCache :> System.Collections.Generic.IEnumerable<'t>).GetEnumerator()
        member this.GetEnumerator(): System.Collections.IEnumerator =
            (itemsCache :> System.Collections.IEnumerable).GetEnumerator()
        member this.IndexOf (item: 't): int =
            itemsCache
            |> Seq.tryFindIndex (fun i -> item = i)
            |> Option.defaultValue -1
        member this.IndexOf (item: obj): int =
            itemsCache
            |> Seq.map box
            |> Seq.tryFindIndex item.Equals
            |> Option.defaultValue -1
            
        member this.OnChanged : IEvent<CollectionChange<'t>> =
            source.OnChanged
            |> Event.filter (Change.filter f) 
            
        member this.OnChanged : IEvent<CollectionChange<obj>> =
            source.OnChanged
            |> Event.filter (Change.filter f)
            |> Event.map Change.box
    
let filter f (col: IReadOnlyObservableCollection<'t>) =
    FilteredReadOnlyObservableCollection<'t>(f, col) :> IReadOnlyObservableCollection<'t>