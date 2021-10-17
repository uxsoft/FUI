module FUI.Tests.EventsTests

open System
open Xunit

[<Fact>]
let ``Events Execution Order`` () =
    let event = Event<unit>()
    let collector = ResizeArray()
    
    event.Publish.Add(fun _ -> collector.Add(1))
    event.Publish.Add(fun _ -> collector.Add(2))
    event.Publish.Add(fun _ -> collector.Add(3))
    event.Publish.Add(fun _ -> collector.Add(4))
    event.Publish.Add(fun _ -> collector.Add(5))
    event.Publish.Add(fun _ -> collector.Add(6))
    event.Publish.Add(fun _ -> collector.Add(7))
    event.Publish.Add(fun _ -> collector.Add(8))
    event.Publish.Add(fun _ -> collector.Add(9))

    event.Trigger()
    
    Assert.Equal([1..9], collector)

type IntHandler = delegate of int -> unit
    
[<Fact>]
let ``Events Unsubscribe`` () =
    let event = Event<int>()
    let collector = ResizeArray()
    
    let handler = Handler<int>(fun sender -> (fun i -> collector.Add(1)))
    event.Publish.AddHandler(handler)
    
    event.Trigger 1
    Assert.Equal([1], collector)
    
    event.Publish.RemoveHandler(handler)

    event.Trigger 2
    
    Assert.Equal([1], collector)