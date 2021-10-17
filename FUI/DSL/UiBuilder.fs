module FUI.UiBuilder

open System.Collections.Generic
open FUI.ObservableCollection
open FUI.ObservableValue

type IAttribute = interface end

type Node =
    { Attributes: Builder.Builder<IAttribute>
      Children: Builder.Builder<obj> }

type UiBuilder() =
    member inline _.Zero() =
        { Attributes = Builder.empty
          Children = Builder.empty }
        
    member inline _.Delay(f) = f ()
    
    member inline x.Yield() = x.Zero()
            
    //TODO Unit test Yield
    member this.Yield(child: obj) =
        match child with
        | null ->
            this.Zero()
        | :? Node as element ->
            element
        | :? list<obj> as children ->
            { Attributes = Builder.empty
              Children = Builder.init children }
        | :? IReadOnlyObservableCollection<obj> as children ->
            { Attributes = Builder.empty
              Children = Builder.appendObservable children Builder.empty } 
        | :? IAttribute as attr ->
            { Attributes = Builder.init [ attr ]
              Children = Builder.empty }
        | _ ->
            { Attributes = Builder.empty
              Children = Builder.init [ child ] }

    member _.Combine(a: Node, b: Node) =
        { Attributes = Builder.append a.Attributes b.Attributes
          Children = Builder.append a.Children b.Children }

    member x.For(s: Node, f) =
        x.Combine(s, f ())
        
    member x.For(list: IReadOnlyObservableCollection<'a>, f: 'a -> Node) =
        // TODO create an optimised (unzip?) operation in Oc module and use it
        let elements = list |> Oc.map f
        let attributes =
            elements
            |> Oc.map (fun i -> i.Attributes)
            |> Oc.map Builder.build
            |> Oc.flatten
            
        let children =
            elements
            |> Oc.map (fun i -> i.Children)
            |> Oc.map Builder.build
            |> Oc.flatten
            
        { Attributes = Builder.empty |> Builder.appendObservable attributes
          Children = Builder.empty |> Builder.appendObservable children }
        
    member x.For(var: IObservableValue<'a>, f: 'a -> Node) =
        x.For(var |> Ov.toObservableCollection, f)
            
    member x.For(list: 'a seq, f: 'a -> Node) =
        let elements = Seq.map f list
        { Attributes = elements |> Seq.map (fun i -> i.Attributes) |> Builder.concat
          Children =  elements |> Seq.map (fun i -> i.Children) |> Builder.concat }
        
let attr prop (node: Node) =
    { node with Attributes = node.Attributes |> Builder.appendStatic prop }