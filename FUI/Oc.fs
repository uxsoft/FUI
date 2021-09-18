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
    interface IReadOnlyObservableCollection<'t> with
        member this.Count = source.Count
        member this.Get (index: int) : 't =
            source
            |> Seq.filter f
            |> Seq.item index
            
        member this.Get (index: int): obj =
            source
            |> Seq.filter f
            |> Seq.item index
            |> box
            
        member this.GetEnumerator(): System.Collections.Generic.IEnumerator<'t> =
            (source |> Seq.filter f).GetEnumerator()
        member this.GetEnumerator(): System.Collections.IEnumerator =
            ((source |> Seq.filter f) :> System.Collections.IEnumerable).GetEnumerator()
        member this.IndexOf (item: 't): int =
            source
            |> Seq.filter f
            |> Seq.findIndex (fun i -> item = i)
        member this.IndexOf (item: obj): int =
            source
            |> Seq.filter f
            |> Seq.map box
            |> Seq.findIndex item.Equals
            
        member this.OnChanged : IEvent<CollectionChange<'t>> =
            Event.filter (Change.filter f) source.OnChanged
        member this.OnChanged : IEvent<CollectionChange<obj>> =
            Event.map (fun c -> c |> Change.map f id |> Change.box) source.OnChanged

    
let filter f (col: IReadOnlyObservableCollection<'t>) =
    FilteredReadOnlyObservableCollection<'t>(f, col) :> IReadOnlyObservableCollection<'t>