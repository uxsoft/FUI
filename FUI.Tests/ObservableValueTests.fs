module FUI.Tests.ObservableValueTests

open Xunit
open FUI
open FUI.ObservableValue

[<Fact>]
let ``ObservableValue`` () =
    let mutable counter = 0    
    let a = oval 1
    a.OnChanged.Add(fun () -> counter <- counter + 1)
    
    a.Value <- 2
    
    a.Update (fun prevState ->
        Assert.Equal(2, prevState)
        prevState + 1)
    
    Assert.Equal(2, counter)
    Assert.Equal(3, a.Value)
    
[<Fact>]
let ``Ov.iter`` () =
    let mutable counter = 0    
    let a = oval 1
    
    let onChange value =
        counter <- counter + 1
        match counter with
        | 1 -> Assert.Equal(1, value)
        | 2 -> Assert.Equal(2, value)
        | _ -> failwith "should never happen"
    
    a |> Ov.iter onChange
    
    a.Value <- 2
    
    Assert.Equal(2, counter)
    
[<Fact>]
let ``Ov.map`` () =
    let mutable counter = 0
    let a = oval 1
    let b = a |> Ov.map (fun i -> i * 3)
        
    b.OnChanged.Add(fun () ->
        counter <- counter + 1
        match counter with
        | 1 -> Assert.Equal(6, b.Value)
        | 2 -> Assert.Equal(9, b.Value)
        | _ -> failwith "should never happen")
    
    a.Value <- 2
    a.Value <- 3
    
    Assert.Equal(2, counter)
    Assert.Equal(3, a.Value)
    Assert.Equal(9, b.Value)
   
[<Fact>]
let ``Ov.toObservableCollection`` () =
    let mutable counter = 0
    let a = oval 1
    let b = a |> Ov.toObservableCollection
        
    Assert.Equal([1], b)
        
    b.OnChanged.Add(fun change ->
        counter <- counter + 1)
    
    a.Value <- 2
    a.Value <- 3
    
    Assert.Equal(2, counter)
    Assert.Equal(3, a.Value)
    Assert.Equal([3], b)