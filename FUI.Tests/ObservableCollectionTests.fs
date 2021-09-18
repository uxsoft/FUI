module FUI.Tests.ObservableCollectionTests

open Xunit
open FUI
open FUI.ObservableCollection
open FUI.CollectionChange

[<Fact>]
let ``ObservableCollection.Get`` () =
    let mutable counter = 0
    let a = ocol [1..5] :> IObservableCollection<int>
    
    a.OnChanged.Add(function
        | _ -> counter <- counter + 1)

    let result = a.Get 1
    
    Assert.Equal(2, result)
    Assert.Equal([1..5], a)
    Assert.Equal(0, counter)
    
[<Fact>]
let ``ObservableCollection.IndexOf`` () =
    let mutable counter = 0
    let a = ocol [1..5] :> IObservableCollection<int>
    
    a.OnChanged.Add(function
        | _ -> counter <- counter + 1)

    Assert.Equal(1, a.IndexOf 2)
    Assert.Equal(-1, a.IndexOf 9)
        
    Assert.Equal([1..5], a)
    Assert.Equal(0, counter)
    
[<Fact>]
let ``ObservableCollection.Count`` () =
    let mutable counter = 0
    let a = ocol [1..5] :> IObservableCollection<int>
    
    a.OnChanged.Add(function
        | _ -> counter <- counter + 1)

    let result = a.Count
    
    Assert.Equal(5, result)
    Assert.Equal([1..5], a)
    Assert.Equal(0, counter)
    
[<Fact>]
let ``IObservableCollection.Contains`` () =
    let mutable counter = 0
    let a = ocol [1..5] :> IObservableCollection<int>
    
    a.OnChanged.Add(function
        | _ -> counter <- counter + 1)

    Assert.Equal(true, a.Contains 2)
    Assert.Equal(false, a.Contains 9)
        
    Assert.Equal([1..5], a)
    Assert.Equal(0, counter)
    
[<Fact>]
let ``ObservableCollection.Clear`` () =
    let mutable counter = 0
    let a = ocol [1..5] :> IObservableCollection<int>
    
    a.OnChanged.Add(function
        | Clear -> counter <- counter + 1
        | _ -> failwith "Wrong change")

    a.Clear()
    
    Assert.Equal([], a)
    Assert.Equal(1, counter)
    
[<Fact>]
let ``ObservableCollection.Insert`` () =
    let mutable counter = 0
    let a = ocol [1..5] :> IObservableCollection<int>
    
    a.OnChanged.Add(function
        | Insert _ -> counter <- counter + 1
        | _ -> failwith "Wrong change")

    a.Insert 0 6
    
    Assert.Equal([6; 1; 2; 3; 4; 5], a)
    Assert.Equal(1, counter)
    
[<Fact>]
let ``ObservableCollection.Move`` () =
    let mutable counter = 0
    let a = ocol [1..5] :> IObservableCollection<int>
    
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
    let a = ocol [1..5] :> IObservableCollection<int>
    
    a.OnChanged.Add(function
        | Remove _ -> counter <- counter + 1
        | _ -> failwith "Wrong change")

    a.Remove(0)
    
    Assert.Equal([2; 3; 4; 5], a)
    Assert.Equal(1, counter)
    
[<Fact>]
let ``ObservableCollection.Set`` () =
    let mutable counter = 0
    let a = ocol [1..5] :> IObservableCollection<int>
    
    a.OnChanged.Add(function
        | Replace _ -> counter <- counter + 1
        | _ -> failwith "Wrong change")

    a.Set 4 9
    a.Set 0 8
    
    Assert.Equal([8; 2; 3; 4; 9], a)
    Assert.Equal(2, counter)
    
[<Fact>]
let ``ObservableCollection.Add`` () =
    let mutable counter = 0
    let a = ocol [1..5]
    
    a.OnChanged.Add(function
        | Insert _ -> counter <- counter + 1
        | _ -> failwith "Wrong change")

    a.Add(9)
    
    Assert.Equal([1; 2; 3; 4; 5; 9], a)
    Assert.Equal(1, counter)
    
[<Fact>]
let ``ObservableCollection.Item`` () =
    let mutable counter = 0
    let a = ocol [1..5]
    
    a.OnChanged.Add(function
        | Replace _ -> counter <- counter + 1
        | _ -> failwith "Wrong change")

    let result = a.[0]
    a.[0] <- 9
    
    Assert.Equal(1, result)
    Assert.Equal([9; 2; 3; 4; 5], a)
    Assert.Equal(1, counter)
    
[<Fact>]
let ``IReadOnlyCollection`` () =
    let a = ocol ()
    a.Add 9
    
    let b = a :> IReadOnlyObservableCollection<int>
    let c = a :> IReadOnlyObservableCollection
    
    Assert.Equal(box 9, c.Get 0)
    Assert.Equal(0, c.IndexOf (box 9))
    
    for i in c do
        Assert.Equal(box 9, i)
        
[<Fact>]
let ``Oc.map`` () =
    let a = ocol [1..5]
    let b = Oc.map (fun i -> i * 2) a
    
    Assert.Equal(5, b.Count)
    Assert.Equal(6, b.Get 2)
    Assert.Equal(3, b.IndexOf 8)
    
    b.OnChanged.Add(function
        | Insert(index, item) -> Assert.Equal(18, item)
        | _ -> failwith "Wrong change")
    a.Add 9
    
    Assert.Equal([2; 4; 6; 8; 10; 18], b)
    
[<Fact>]
let ``Oc.filter`` () =
    let a = ocol [1..5]
    let b = Oc.filter (fun i -> i % 2 = 0) a
    
    Assert.Equal(2, b.Count)
    Assert.Equal(4, b.Get 1)
    Assert.Equal(1, b.IndexOf 4)
    
    b.OnChanged.Add(function
        | Insert(_, item) -> Assert.Equal(8, item)
        | _ -> failwith "Wrong change")
    a.Add 8
    a.Add 9
    
    Assert.Equal([2; 4; 8], b)
    
