module FUI.CompositeObservableCollection

open System
open FUI.ObservableCollection
open FUI.CollectionChange

let private random = Random()

type CompositeObservableCollection<'t when 't : equality>(source: IReadOnlyObservableCollection<IReadOnlyObservableCollection<'t>>) =
    let cId = random.Next()
    let event = Event<CollectionChange<'t>>()
    
    let handlers = System.Collections.Generic.Dictionary<IReadOnlyObservableCollection<'t>, Handler<CollectionChange<'t>>>()
    
    let addHandler col f =
        let handler = Handler<CollectionChange<'t>>(f)
        handlers.[col] <- handler
        col.OnChanged.AddHandler handler
    
    let removeHandler col =
        let a = handlers |> Seq.map (fun i -> obj.ReferenceEquals(i, col))
        let handler = handlers.[col]
        handlers.Remove col |> ignore
        col.OnChanged.RemoveHandler handler
    
    let items = source |> Seq.map (fun i -> i, ResizeArray i) |> ResizeArray
    
    let projectIndex index =
        items
        |> Seq.take index
        |> Seq.sumBy (fun (i, cache) -> cache.Count)
    
    let projectIndexOf (col: IReadOnlyObservableCollection<'t>) =
        items
        |> Seq.takeWhile (fun (i, cache) -> i <> col)
        |> Seq.sumBy (fun (i, cache) -> cache.Count)
    
    let iterateSources() =
        seq {
            let mutable masterIndex = 0
            for col in source do
                let mutable slaveIndex = 0
                for item in col do
                    yield (masterIndex, col, slaveIndex, item)
                    masterIndex <- masterIndex + 1
                    slaveIndex <- slaveIndex + 1
        }
        
    let iterateItems() =
        items |> Seq.collect snd
    
    let onItemChanged (col: IReadOnlyObservableCollection<'t>) sender (change: CollectionChange<'t>) =
        match change with
        | Insert(index, item) ->
            let index' = projectIndexOf col + index
            
            let i, cache = items |> Seq.find (fun (i, cache) -> obj.ReferenceEquals(i, col))
            cache.Insert(index, item)
            
            event.Trigger(Insert(index', item))
            
        | Remove(index, item) ->
            let index' = projectIndexOf col + index
            
            let i, cache = items |> Seq.find (fun (i, cache) -> obj.ReferenceEquals(i, col))
            cache.RemoveAt(index)
            
            event.Trigger(Remove(index', item))
    
    let onCollectionChanged (change: CollectionChange<IReadOnlyObservableCollection<'t>>) =
        match change with
        | Insert(colIndex, col) ->
            addHandler col (onItemChanged col)
            
            let index' = projectIndex colIndex
            items.Insert(colIndex, (col, ResizeArray col))
            
            for i = 0 to col.Count - 1 do
                event.Trigger (Insert(index' + i, col.Get i))
                
        | Remove(colIndex, col) ->
            removeHandler col
            
            let index' = projectIndex colIndex
            items.RemoveAt(colIndex)
            
            for i = col.Count - 1 downto 0 do
                event.Trigger (Remove(index' + i, col.Get i))
    
    let initHandlers () =
        source.OnChanged.Add onCollectionChanged
        for col in source do
            addHandler col (onItemChanged col)
    
    do initHandlers()

    new (collections: IReadOnlyObservableCollection<'t> seq) =
        CompositeObservableCollection(ObservableCollection(collections))
        
    new (collections: IReadOnlyObservableCollection seq) =
        CompositeObservableCollection(Seq.toArray collections)
        
    member this.Count =
        items |> Seq.sumBy (fun (i, cache) -> cache.Count)
    
    member this.Get index =
        iterateItems()
        |> Seq.item index
        
    member this.IndexOf item =
        iterateItems()
        |> Seq.tryFindIndex (fun i -> i = item)
        |> Option.defaultValue -1
    
    override this.ToString() = $"C{cId}: %A{this}"
    
    interface IReadOnlyObservableCollection<'t> with
        member this.Count = this.Count
        member this.Get (index: int): 't = this.Get index
        member this.Get (index: int): obj = box (this.Get index)
        member this.IndexOf (item: 't): int = this.IndexOf item
        member this.IndexOf (item: obj): int = this.IndexOf (item :?> 't)
        member this.OnChanged : IEvent<CollectionChange<'t>> = event.Publish
        member this.OnChanged : IEvent<CollectionChange<obj>> = event.Publish |> Event.map Change.box
        member this.GetEnumerator(): System.Collections.Generic.IEnumerator<'t> =
            (iterateItems() :> System.Collections.Generic.IEnumerable<'t>).GetEnumerator()
        member this.GetEnumerator(): System.Collections.IEnumerator =
            (iterateItems() :> System.Collections.IEnumerable).GetEnumerator()
            