module FUI.Tests.ObservableCollectionTests

open Xunit
open FUI.ObservableCollection
open FUI.CollectionChange

[<Fact>]
let ``ObservableCollection.Get`` () =
    let mutable counter = 0
    let a = ocol [1..5]
    
    a.OnChanged.Add(function
        | _ -> counter <- counter + 1)

    let result = a.Get 1
    
    Assert.Equal(2, result)
    Assert.Equal([1..5], a)
    Assert.Equal(0, counter)
    
[<Fact>]
let ``ObservableCollection.IndexOf`` () =
    let mutable counter = 0
    let a = ocol [1..5]
    
    a.OnChanged.Add(function
        | _ -> counter <- counter + 1)

    let result = a.IndexOf 2
    
    Assert.Equal(1, result)
    Assert.Equal([1..5], a)
    Assert.Equal(0, counter)
    
[<Fact>]
let ``ObservableCollection.Count`` () =
    let mutable counter = 0
    let a = ocol [1..5]
    
    a.OnChanged.Add(function
        | _ -> counter <- counter + 1)

    let result = a.Count
    
    Assert.Equal(5, result)
    Assert.Equal([1..5], a)
    Assert.Equal(0, counter)
    
[<Fact>]
let ``ObservableCollection.Clear`` () =
    let mutable counter = 0
    let a = ocol [1..5]
    
    a.OnChanged.Add(function
        | Clear -> counter <- counter + 1
        | _ -> failwith "Wrong change")

    a.Clear()
    
    Assert.Equal([], a)
    Assert.Equal(1, counter)
    
[<Fact>]
let ``ObservableCollection.Insert`` () =
    let mutable counter = 0
    let a = ocol [1..5]
    
    a.OnChanged.Add(function
        | Insert _ -> counter <- counter + 1
        | _ -> failwith "Wrong change")

    a.Insert 0 6
    
    Assert.Equal([6; 1; 2; 3; 4; 5], a)
    Assert.Equal(1, counter)
    
[<Fact>]
let ``ObservableCollection.Move`` () =
    let mutable counter = 0
    let a = ocol [1..5]
    
    a.OnChanged.Add(function
        | Move _ -> counter <- counter + 1
        | _ -> failwith "Wrong change")

    a.Move 1 4
    a.Move 2 0
    
    Assert.Equal([4; 1; 3; 5; 2], a)
    Assert.Equal(2, counter)
    
[<Fact>]
let ``ObservableCollection.Remove`` () =
    let mutable counter = 0
    let a = ocol [1..5]
    
    a.OnChanged.Add(function
        | Remove _ -> counter <- counter + 1
        | _ -> failwith "Wrong change")

    a.Remove(0)
    
    Assert.Equal([2; 3; 4; 5], a)
    Assert.Equal(1, counter)
    
[<Fact>]
let ``ObservableCollection.Set`` () =
    let mutable counter = 0
    let a = ocol [1..5]
    
    a.OnChanged.Add(function
        | Replace _ -> counter <- counter + 1
        | _ -> failwith "Wrong change")

    a.Set 4 9
    a.Set 0 8
    
    Assert.Equal([8; 2; 3; 4; 9], a)
    Assert.Equal(2, counter)
    
[<Fact>]
let ``IReadOnlyCollection`` () =
    ()
    