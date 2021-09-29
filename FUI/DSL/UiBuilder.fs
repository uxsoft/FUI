module FUI.UiBuilder

open System.Collections.Generic
open FUI.ObservableCollection

type Node<'child, 'attr> =
    { Attributes: Builder.Builder<'attr>
      Children: Builder.Builder<'child> }

type UiBuilder<'t when 't : equality>() =
    member inline _.Zero() =
        { Attributes = Builder.empty
          Children = Builder.empty }
        
    member inline _.Delay(f) = f ()

    member inline x.Yield() = x.Zero()
            
    member _.Yield(child: obj) =
        match child with
        | null ->
            { Attributes = Builder.empty
              Children = Builder.empty }
        | :? Node<'child, 'attr> as element ->
            element
        | :? list<'child> as children ->
            { Attributes = Builder.empty
              Children = Builder.init children }
        | :? 'attr as attr ->
            { Attributes = Builder.init [ attr ]
              Children = Builder.empty }
        | :? 'child as child ->
            { Attributes = Builder.empty
              Children = Builder.init [ child ] }
        | _ ->
            printfn $"Attempt to yield %O{child} failed"
            { Attributes = Builder.empty
              Children = Builder.empty }

    member _.Combine(a: Node<_, _>, b: Node<_, _>) =
        { Attributes = Builder.append a.Attributes b.Attributes
          Children = Builder.append a.Children b.Children }

    member x.For(s: Node<_, _>, f) =
        x.Combine(s, f ())
        
    member x.For(list: IReadOnlyObservableCollection<'a>, f: 'a -> Node<_, _>) =
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
            
    member x.For(list: 'a seq, f: 'a -> Node<_, _>) =
        let elements = Seq.map f list
        { Attributes = elements |> Seq.map (fun i -> i.Attributes) |> Builder.concat
          Children =  elements |> Seq.map (fun i -> i.Children) |> Builder.concat }
        
let attr prop (node: Node<_, _>) =
    { node with Attributes = node.Attributes |> Builder.appendStatic prop }