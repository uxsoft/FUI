module FUI.IfBuilder

open System.Collections.Generic
open FUI.ObservableCollection
open FUI.UiBuilder
open FUI.ObservableValue

type IfBuilder<'t when 't : equality>(q: IObservableValue<bool>) =
    inherit UiBuilder<'t>()
    
    member _.Run (x: Node<_, _>) =
        let sourceAttributes = x.Attributes |> Builder.build
        let sourceChildren = x.Children |> Builder.build
        
        let ifAttributes = ObservableCollection([ sourceAttributes ])
        let ifChildren = ObservableCollection([ sourceChildren ])
                
        let refreshAttributes() =
            ifAttributes.Set 0 (
                if q.Value then sourceAttributes
                else Oc.empty :> IReadOnlyObservableCollection<KeyValuePair<string,obj>>)
            
        let refreshChildren() =
            ifChildren.Set 0 (
                if q.Value then sourceChildren
                else Oc.empty :> IReadOnlyObservableCollection<obj>)
        
        q.OnChanged.Add(refreshAttributes)
        q.OnChanged.Add(refreshChildren)
        refreshAttributes()
        refreshChildren()
        
        { Attributes = Builder.empty |> Builder.appendObservable (Oc.flatten ifAttributes)
          Children = Builder.empty |> Builder.appendObservable (Oc.flatten ifChildren) }
    
let If (q: IObservableValue<bool>) = IfBuilder q

let Else (q: IObservableValue<bool>) = IfBuilder (q |> Ov.map not)