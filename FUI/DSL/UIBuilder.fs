module FUI.UIBuilder

open System.Collections.Generic
open FUI.ObservableCollection

type Element =
    { Attributes: Builder.Builder<KeyValuePair<string, obj>>
      Children: Builder.Builder<obj> }
    
    member inline x.mapAttrs f =
        { x with Attributes = f x.Attributes }
    
    member inline x.attr (name: string) value =
        x.mapAttrs (Builder.appendStatic (KeyValuePair(name, value)))


type UIBuilder<'t>() =
    member inline _.Zero() =
        { Attributes = Builder.empty; Children = Builder.empty }
        
    member inline _.Delay(f) = f ()

    member inline x.Yield() = x.Zero()
            
    member _.Yield(child: obj) =
        match child with
        | null ->
            { Attributes = Builder.empty
              Children = Builder.empty }
        | :? Element as element ->
            element
        | :? list<obj> as children ->
            { Attributes = Builder.empty
              Children = Builder.init children }
        | :? KeyValuePair<string, obj> as pair ->
            { Attributes = Builder.init [ pair ]
              Children = Builder.empty }
        | _ ->
            { Attributes = Builder.empty
              Children = Builder.init [ child ] }

    member _.Combine(a: Element, b: Element) =
        { Attributes = Builder.append a.Attributes b.Attributes
          Children = Builder.append a.Children b.Children }

    member x.For(s: Element, f) =
        x.Combine(s, f ())
        
    member x.For(list: IReadOnlyObservableCollection<'a>, f: 'a -> Element) =
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
            
    member x.For(list: 'a seq, f: 'a -> Element) =
        let elements = Seq.map f list
        { Attributes = elements |> Seq.map (fun i -> i.Attributes) |> Builder.concat
          Children =  elements |> Seq.map (fun i -> i.Children) |> Builder.concat }
    
    // Common Attributes
    [<CustomOperation("attr")>]
    member inline _.Attr(s: Element, n: string, v) = s.attr n v