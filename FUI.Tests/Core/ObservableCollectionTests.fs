module FUI.Tests.ObservableCollectionTests

open Xunit
open FUI
open FUI.ObservableCollection
open FUI.CollectionChange

[<Fact>]
let ``ObservableCollection.Get`` () =
    let mutable counter = 0
    let a = col [1..5] :> IObservableCollection<int>
    
    a.OnChanged.Add(function
        | _ -> counter <- counter + 1)

    let result = a.Get 1
    
    Assert.Equal(2, result)
    Assert.Equal([1..5], a)
    Assert.Equal(0, counter)
    
[<Fact>]
let ``ObservableCollection.IndexOf`` () =
    let mutable counter = 0
    let a = col [1..5] :> IObservableCollection<int>
    
    a.OnChanged.Add(function
        | _ -> counter <- counter + 1)

    Assert.Equal(1, a.IndexOf 2)
    Assert.Equal(-1, a.IndexOf 9)
        
    Assert.Equal([1..5], a)
    Assert.Equal(0, counter)
    
[<Fact>]
let ``ObservableCollection.Count`` () =
    let mutable counter = 0
    let a = col [1..5] :> IObservableCollection<int>
    
    a.OnChanged.Add(function
        | _ -> counter <- counter + 1)

    let result = a.Count
    
    Assert.Equal(5, result)
    Assert.Equal([1..5], a)
    Assert.Equal(0, counter)
    
[<Fact>]
let ``IObservableCollection.Contains`` () =
    let mutable counter = 0
    let a = col [1..5] :> IObservableCollection<int>
    
    a.OnChanged.Add(function
        | _ -> counter <- counter + 1)

    Assert.Equal(true, a.Contains 2)
    Assert.Equal(false, a.Contains 9)
        
    Assert.Equal([1..5], a)
    Assert.Equal(0, counter)
    
[<Fact>]
let ``ObservableCollection.Clear`` () =
    let mutable counter = 0
    let a = col [1..5] :> IObservableCollection<int>
    
    a.OnChanged.Add(fun _ -> counter <- counter + 1)
    a.Clear()
    
    Assert.Equal([], a)
    Assert.Equal(5, counter)
    
[<Fact>]
let ``ObservableCollection.Insert`` () =
    let mutable counter = 0
    let a = col [1..5] :> IObservableCollection<int>
    
    a.OnChanged.Add(function
        | Insert _ -> counter <- counter + 1
        | _ -> failwith "Wrong change")

    a.Insert 0 6
    
    Assert.Equal([6; 1; 2; 3; 4; 5], a)
    Assert.Equal(1, counter)
    
[<Fact>]
let ``ObservableCollection.Move`` () =
    let mutable counter = 0
    let a = col [1..5] :> IObservableCollection<int>
    
    a.OnChanged.Add(fun _ -> counter <- counter + 1)
    
    a.Move 1 4
    a.Move 2 0
    
    Assert.Equal([4; 1; 3; 5; 2], a)
    Assert.Equal(4, counter)
    
[<Fact>]
let ``ObservableCollection.Remove`` () =
    let mutable counter = 0
    let a = col [1..5] :> IObservableCollection<int>
    
    a.OnChanged.Add(fun _ -> counter <- counter + 1)

    a.Remove(0)
    
    Assert.Equal([2; 3; 4; 5], a)
    Assert.Equal(1, counter)
    
[<Fact>]
let ``ObservableCollection.Set`` () =
    let mutable counter = 0
    let a = col [1..5] :> IObservableCollection<int>
    
    a.OnChanged.Add(fun _ -> counter <- counter + 1)
    
    a.Set 4 9
    a.Set 0 8
    
    Assert.Equal([8; 2; 3; 4; 9], a)
    Assert.Equal(4, counter)
    
[<Fact>]
let ``ObservableCollection.Add`` () =
    let mutable counter = 0
    let a = col [1..5]
    
    a.OnChanged.Add(function
        | Insert _ -> counter <- counter + 1
        | _ -> failwith "Wrong change")

    a.Add(9)
    
    Assert.Equal([1; 2; 3; 4; 5; 9], a)
    Assert.Equal(1, counter)
    
[<Fact>]
let ``ObservableCollection.Item`` () =
    let mutable counter = 0
    let a = col [1..5]
    
    a.OnChanged.Add(fun _ -> counter <- counter + 1)
    
    let result = a.[0]
    a.[0] <- 9
    
    Assert.Equal(1, result)
    Assert.Equal([9; 2; 3; 4; 5], a)
    Assert.Equal(2, counter)
    
[<Fact>]
let ``IReadOnlyCollection`` () =
    let a = col ()
    a.Add 9
    
    let b = a :> IReadOnlyObservableCollection<int>
    let c = a :> IReadOnlyObservableCollection
    
    Assert.Equal(box 9, c.Get 0)
    Assert.Equal(0, c.IndexOf (box 9))
    
    for i in c do
        Assert.Equal(box 9, i)
        
[<Fact>]
let ``Oc.map`` () =
    let a = col [1..5]
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
    let a = col [1..5]
    let b = Oc.filter (fun i -> i % 2 = 0) a
    let c = ResizeArray(b)
    
    Assert.Equal(2, b.Count)
    Assert.Equal(4, b.Get 1)
    Assert.Equal(1, b.IndexOf 4)
    Assert.Equal(-1, b.IndexOf -1)
    
    b.OnChanged.Add(Change.commit c)
    
    a.Add 8
    a.Add 9
    // [1; 2; 3; 4; 5; 8; 9]
    Assert.Equal([2; 4; 8], b)
    Assert.Equal(b, c)
    
    a.Remove 0
    a.Remove 0
    // [3; 4; 5; 8; 9]
    Assert.Equal([4; 8], b)
    Assert.Equal(b, c)
    
    a.Move 2 0
    a.Move 2 4
    
    // [5; 3; 8; 9; 4]
    Assert.Equal([8; 4], b)
    Assert.Equal(b, c)
    
    a.Set 2 1
    a.Set 0 6
    // [6; 3; 1; 9; 4]
    Assert.Equal([6; 4], b)
    Assert.Equal(b, c)    
    
[<Fact>]
let ``Oc.iter`` () =
    let a = col [1..5]
    let b = ResizeArray<int>()
    
    a |> Oc.iter (fun i -> b.Add i) (fun i -> b.Add -i)
    
    a.Remove 0
    a.Insert 4 9
    Assert.Equal([1; 2; 3; 4; 5; -1; 9], b)