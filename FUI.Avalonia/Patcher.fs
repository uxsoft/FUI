module FUI.Avalonia.Patcher

open System
open System.Collections.Generic
open System.Threading
open FUI
open FUI.ObservableCollection
open FUI.ObservableValue
open FUI.UiBuilder
open FUI.Avalonia.Types

let addAttribute<'t when 't : equality> (control: obj) (attribute: IAttribute) =
    (attribute :?> Attribute).Set control
    
let removeAttribute<'t when 't : equality> (control: obj) (attribute: IAttribute) =
    (attribute :?> Attribute).Clear control

// DSL Avalonia Platform
type UiBuilder with
    member _.RunWithChildren<'t when 't : equality> (x: Node) (setChildren: 't -> IReadOnlyObservableCollection<obj> -> unit) =
        try
            let control = Activator.CreateInstance<'t>()

            let attributes = x.Attributes |> Builder.build
            let children = x.Children |> Builder.build
             
            attributes
            |> Oc.iter (addAttribute control) (removeAttribute control)
                
            setChildren control children
                 
            control 
        with e ->
            printfn $"{e}"
            reraise()
            
    member this.RunWithChild<'t when 't : equality> (x: Node) (setChild: 't -> obj -> unit) =
        let setChild (control: 't) (children: IReadOnlyObservableCollection<obj>) =
            //TODO Oc.head 
            let set () = 
                children
                |> Seq.tryHead
                |> Option.iter (fun child ->
                    match child with
                    | :? IObservableValue as ov ->
                        Ov.iter' (setChild control) ov
                    | _ -> setChild control child)
            
            set()
            children.OnChanged.Add (fun _ -> set())
            
        this.RunWithChildren<'t> x setChild
        
    member this.RunChildless<'t when 't : equality> (x: Node) =
        this.RunWithChildren<'t> x (fun _ _ -> ())
