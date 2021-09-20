module FUI.CompositeObservableCollection

open FUI.ObservableCollection
open FUI.CollectionChange

type CompositeObservableCollection<'t when 't : equality>(source: IReadOnlyObservableCollection<IReadOnlyObservableCollection<'t>>) =
    let cache = ResizeArray(source)
    let event = Event<CollectionChange<'t>>()
    
    let projectIndex index =
        source
        |> Seq.take index
        |> Seq.sumBy (fun i -> i.Count)
    
    let projectIndexOf (col: IReadOnlyObservableCollection<'t>) =
        source
        |> Seq.takeWhile (fun i -> i <> col)
        |> Seq.sumBy (fun i -> i.Count)
    
    let iterate() =
        seq {
            let mutable masterIndex = 0
            for col in source do
                let mutable slaveIndex = 0
                for item in col do
                    yield (masterIndex, col, slaveIndex, item)
                    masterIndex <- masterIndex + 1
                    slaveIndex <- slaveIndex + 1
        } 
    
    let onItemChanged (source: IReadOnlyObservableCollection<'t>) (change: CollectionChange<'t>) =
        event.Trigger (Change.map id (fun index -> projectIndexOf source + index) change)
    
    let onCollectionChanged (sourceChange: CollectionChange<IReadOnlyObservableCollection<'t>>) =
        // The change in `source` already happened
        // Reverse-engineer what happened
        match sourceChange with
        | Insert(index, item) ->
            let index' = projectIndex index
            Change.commit cache sourceChange
            
            for i = 0 to item.Count - 1 do
                event.Trigger (Insert(index' + i, item.Get i))
                
        | Remove(index, item) ->
            let index' = projectIndex index
            Change.commit cache sourceChange
            
            for i = item.Count - 1 downto 0 do
                event.Trigger (Remove(index' + i, item.Get i))
    
    do
        source.OnChanged.Add onCollectionChanged
        for col in source do
            col.OnChanged.Add (onItemChanged col)

    new (collections: IReadOnlyObservableCollection<'t> seq) =
        CompositeObservableCollection(ObservableCollection(collections))
        
    new (collections: IReadOnlyObservableCollection seq) =
        CompositeObservableCollection(Seq.toArray collections)
        
    member this.Count = source |> Seq.sumBy (fun col -> col.Count)
    
    member this.Get index =
        let _, _, _, item = iterate() |> Seq.item index
        item
        
    member this.IndexOf item =
        iterate()
        |> Seq.tryFind (fun (_, _, _, i) -> i = item)
        |> Option.map(fun (masterIndex, _, _, _) -> masterIndex)
        |> Option.defaultValue -1
    
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
            