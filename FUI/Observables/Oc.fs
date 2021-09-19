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
    let items =
        source
        |> Seq.map (fun i -> i, f i)
        |> ResizeArray
    let event = Event<CollectionChange<'t>>()
        
    let projectIndex index =
        items
        |> Seq.take index
        |> Seq.sumBy (fun (_, f) -> if f then 1 else 0)
    
    let filteredItems () =
        items
        |> Seq.filter snd
        |> Seq.map fst
        |> Seq.toArray
                    
    let onSourceChanged (sourceChange: CollectionChange<'t>) =
        match sourceChange with
        | Clear ->
            Change.commit items Clear
            event.Trigger Clear
            
        | Insert(index, item) ->
            let passes = f item
            let index' = projectIndex index
            
            Change.commit items (Insert(index, (item, passes)))
            if passes then 
                event.Trigger (Insert(index', item))
                
        | Remove(index, item) ->
            let passes = f item
            let index' = projectIndex index
            
            Change.commit items (Remove(index, (item, passes)))
            if passes then 
                event.Trigger (Remove(index', item))
                
        | Replace(index, oldItem, item) ->
            let passes = f item
            let passed = f oldItem
            let index' = projectIndex index
            
            Change.commit items (Replace(index, (oldItem, f oldItem), (item, passes)))
            if passed || passes then // we could be removing or adding an element we care about
                event.Trigger (Replace(index', oldItem, item))
                
        | Move(oldIndex, newIndex, item) ->
            let passes = f item
            
            let oldIndex' = projectIndex oldIndex
            Change.commit items (Move(oldIndex, newIndex, (item, passes)))
            let newIndex' = projectIndex newIndex
            
            if passes then 
                event.Trigger (Move(oldIndex', newIndex', item))
        
    do source.OnChanged.Add onSourceChanged
    
    interface IReadOnlyObservableCollection<'t> with
        member this.Count = items |> Seq.sumBy (fun (_, f) -> if f then 1 else 0)
        member this.Get (index: int) : 't =
            filteredItems()
            |> Seq.item index
            
        member this.Get (index: int): obj =
            filteredItems()
            |> Seq.item index
            |> box
            
        member this.GetEnumerator(): System.Collections.Generic.IEnumerator<'t> =
            (filteredItems() :> System.Collections.Generic.IEnumerable<'t>).GetEnumerator()
        member this.GetEnumerator(): System.Collections.IEnumerator =
            (filteredItems() :> System.Collections.IEnumerable).GetEnumerator()
        
        member this.IndexOf (item: 't): int =
            filteredItems()
            |> Seq.tryFindIndex (fun i -> item = i)
            |> Option.defaultValue -1
            
        member this.IndexOf (item: obj): int =
            filteredItems()
            |> Seq.tryFindIndex item.Equals
            |> Option.defaultValue -1
             
        member this.OnChanged : IEvent<CollectionChange<'t>> =
            event.Publish
            
        member this.OnChanged : IEvent<CollectionChange<obj>> =
            event.Publish
            |> Event.map Change.box
    
let filter f (col: IReadOnlyObservableCollection<'t>) =
    FilteredReadOnlyObservableCollection<'t>(f, col) :> IReadOnlyObservableCollection<'t>