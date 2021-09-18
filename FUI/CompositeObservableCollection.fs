module FUI.CompositeObservableCollection

open FUI.ObservableCollection
open FUI.CollectionChange

type CompositeObservableCollection<'t when 't : equality>(collections: IReadOnlyObservableCollection<IReadOnlyObservableCollection<'t>>) =
    let collections = collections
    let event = Event<CollectionChange<'t>>()
    
    let iterate() =
        seq {
            let mutable masterIndex = 0
            for col in collections do
                let mutable slaveIndex = 0
                for item in col do
                    yield (masterIndex, col, slaveIndex, item)
                    masterIndex <- masterIndex + 1
                    slaveIndex <- slaveIndex + 1
        } 
    
    let start i =
        collections
        |> Seq.take i
        |> Seq.sumBy (fun i -> i.Count)
    
    let startOf (col: IReadOnlyObservableCollection<'t>) =
        collections
        |> Seq.takeWhile (fun i -> i <> col)
        |> Seq.sumBy (fun i -> i.Count)
    
    let mapEvent (source: IReadOnlyObservableCollection<'t>) (change: CollectionChange<'t>) : CollectionChange<'t> =
        change
        |> Change.map id (fun index -> startOf source + index)
        
    let onItemChanged (source: IReadOnlyObservableCollection<'t>) (change: CollectionChange<'t>) =
        match change with
        | Clear ->
            for i in (source.Count - 1)..0 do
                event.Trigger (Remove(i, source.Get i))
        | _ -> event.Trigger (mapEvent source change)
    
    let onCollectionChanged (change: CollectionChange<IReadOnlyObservableCollection<'t>>) =
        match change with
        | Clear ->
            event.Trigger Clear
        | Insert(index, item) ->
            let startIndex = start index
            for i in 0..(item.Count - 1) do
                event.Trigger (Insert(startIndex + i, item.Get i))
        | Move(oldIndex, newIndex, item) ->
            let oldIndex' = start oldIndex
            let newIndex' = startOf item
            for i in 0..(item.Count - 1) do
                event.Trigger (Move(oldIndex', newIndex' + i, item.Get i))
        | Remove(index, item) ->
            let startIndex = start index
            for i in (item.Count - 1)..0 do
                event.Trigger (Remove(startIndex + i, item.Get i))
        | Replace(index, oldItem, item) ->
            let startIndex = start index
            for i in (oldItem.Count - 1)..0 do
                event.Trigger (Remove(startIndex + i, oldItem.Get i))
            for i in 0..(item.Count - 1) do
                event.Trigger (Insert(startIndex + i, item.Get i))
    
    do
        collections.OnChanged.Add onCollectionChanged
        for col in collections do
            col.OnChanged.Add (onItemChanged col)
        

    new (collections: IReadOnlyObservableCollection<'t> seq) =
        CompositeObservableCollection(ObservableCollection(collections))
    
    new (collections: IReadOnlyObservableCollection seq) =
        CompositeObservableCollection(Seq.toArray collections)        
    member this.Count = collections |> Seq.sumBy (fun col -> col.Count)
    member this.Get index =
        let _, _, _, item = iterate() |> Seq.item index
        item
        
    member this.IndexOf item =
        let masterIndex, _, _, _ = iterate() |> Seq.find (fun (_, _, _, i) -> i = item)
        masterIndex
    
    interface IReadOnlyObservableCollection<'t> with
        member this.Count = this.Count
        member this.Get (index: int): 't = this.Get index
        member this.Get (index: int): obj = box (this.Get index)
        member this.IndexOf (item: 't): int = this.IndexOf item
        member this.IndexOf (item: obj): int = this.IndexOf (item :?> 't)
        member this.OnChanged : IEvent<CollectionChange<'t>> = event.Publish
        member this.OnChanged : IEvent<CollectionChange<obj>> = event.Publish |> Event.map Change.box
        member this.GetEnumerator(): System.Collections.Generic.IEnumerator<'t> =
            (iterate() |> Seq.map (fun (_, _, _, i) -> i)).GetEnumerator()
        member this.GetEnumerator(): System.Collections.IEnumerator =
            ((iterate() |> Seq.map (fun (_, _, _, i) -> i)) :> System.Collections.IEnumerable).GetEnumerator()
            