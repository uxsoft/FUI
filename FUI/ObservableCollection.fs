module FUI.ObservableCollection

open FUI.CollectionChange

type IReadOnlyObservableCollection =
    inherit System.Collections.IEnumerable
    
    abstract member IndexOf: obj -> int
    abstract member Get: int -> obj
    abstract member Count : int with get
    abstract member OnChanged : IEvent<CollectionChange<obj>>
    
type IReadOnlyObservableCollection<'t> =
    inherit System.Collections.Generic.IEnumerable<'t>
    inherit IReadOnlyObservableCollection

    abstract member IndexOf: 't -> int
    abstract member Get: int -> 't
    abstract member OnChanged : IEvent<CollectionChange<'t>>

type IObservableCollection<'t> =
    inherit IReadOnlyObservableCollection<'t>
    
    abstract member Clear: unit -> unit
    abstract member Remove: int -> unit
    abstract member Insert: int -> 't -> unit
    abstract member Set: int -> 't -> unit
    abstract member Move: int -> int -> unit

type ObservableCollection<'t>(source: System.Collections.Generic.IList<'t>) =
    let items = source
    let event = Event<CollectionChange<'t>>()
    
    new (source: 't seq) = ObservableCollection(ResizeArray(source))
    new () = ObservableCollection(ResizeArray())
    

    member this.Clear() =
        let change = Clear
        Change.commit items change
        event.Trigger change
        
    member this.Insert index item =
        let change = Insert(index, item)
        Change.commit items change
        event.Trigger change
        
    member this.Move oldIndex newIndex =
        let change = Move(oldIndex, newIndex, items.[oldIndex])
        Change.commit items change
        event.Trigger change
        
    member this.Remove index =
        let change = Remove(index, items.[index])
        Change.commit items change
        event.Trigger change
        
    member this.Set index item =
        let change = Replace(index, items.[index], item)
        Change.commit items change
        event.Trigger change
        
    member this.Add item =
        let change = Insert(items.Count, item)
        Change.commit items change
        event.Trigger change
    
    member this.IndexOf item = items.IndexOf item
    member this.Get index = items.[index]
    member this.Item
        with get index = this.Get index
        and set index value = this.Set index value
    member this.Count = items.Count
    member this.OnChanged = event.Publish
    
    interface IObservableCollection<'t> with
        member this.Clear() = this.Clear()
        member this.Get index = this.Get index
        member this.Get index = box (this.Get index)
        member this.IndexOf item = this.IndexOf item
        member this.IndexOf (item: obj): int =
            match item with
            | :? 't as typedItem -> this.IndexOf(typedItem)
            | _ -> -1
            
        member this.Insert index item = this.Insert index item
        member this.Count = this.Count
        member this.Move oldIndex newIndex = this.Move oldIndex newIndex
        member this.OnChanged = this.OnChanged
        member this.OnChanged = this.OnChanged |> Event.map Change.box
        member this.Remove index = this.Remove index
        member this.Set index item = this.Set index item
        member this.GetEnumerator() = items.GetEnumerator()
        member this.GetEnumerator() = (items :> System.Collections.IEnumerable).GetEnumerator()
 
type 'T ocol = ObservableCollection<'T>

