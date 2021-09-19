module FUI.Tests.CompositeObservableCollectionTest

open FUI
open FUI.ObservableCollection
open Xunit
open Xunit

[<Fact>]
let ``Oc.append`` () =
    let mutable counter = 0
    let a = ObservableCollection([1..5])
    let b = ObservableCollection([6..10])
    
    let c = Oc.append a b    
    c.OnChanged.Add(function
        | CollectionChange.Remove _ ->
            if counter < 2 then counter <- counter + 1
            else failwith "Remove should be the first change"
        | CollectionChange.Insert _ ->
            if counter < 4 then counter <- counter + 1
            else failwith "Insert should be the second change")
    
    Assert.Equal([1; 2; 3; 4; 5; 6; 7; 8; 9; 10], c)
    
    // remove
    a.Remove(0) // [ 2; 3; 4; 5 ]
    b.Remove(4) // [ 6; 7; 8; 9; ]
    Assert.Equal([2; 3; 4; 5; 6; 7; 8; 9], c)
    
    Assert.Equal(3, c.IndexOf 5)
    Assert.Equal(5, c.IndexOf 7)
    Assert.Equal(-1, c.IndexOf 10)
    Assert.Equal(4, c.Get 2)
    Assert.Equal(8, c.Get 6)
    Assert.Equal(8, c.Count)
    
    // add
    a.Insert 0 10 // [ 10; 2; 3; 4; 5 ]
    b.Insert 3 1 // [ 6; 7; 8; 1; 9 ]
    Assert.Equal([10; 2; 3; 4; 5; 6; 7; 8; 1; 9], c)
    
    Assert.Equal(4, c.IndexOf 5)
    Assert.Equal(6, c.IndexOf 7)
    Assert.Equal(-1, c.IndexOf 11)
    Assert.Equal(3, c.Get 2)
    Assert.Equal(7, c.Get 6)
    Assert.Equal(10, c.Count)
    
[<Fact>]
let ``Oc.concat`` () =
    let mutable counter = 0
    let a = ObservableCollection([1..5])
    let b = ObservableCollection([6..10])
    
    let c = Oc.concat [a; b]    
    c.OnChanged.Add(function
        | CollectionChange.Remove _ ->
            if counter < 2 then counter <- counter + 1
            else failwith "Remove should be the first change"
        | CollectionChange.Insert _ ->
            if counter < 4 then counter <- counter + 1
            else failwith "Insert should be the second change")
    
    Assert.Equal([1; 2; 3; 4; 5; 6; 7; 8; 9; 10], c)
    
    // remove
    a.Remove(0) // [ 2; 3; 4; 5 ]
    b.Remove(4) // [ 6; 7; 8; 9; ]
    Assert.Equal([2; 3; 4; 5; 6; 7; 8; 9], c)
    
    Assert.Equal(3, c.IndexOf 5)
    Assert.Equal(5, c.IndexOf 7)
    Assert.Equal(-1, c.IndexOf 10)
    Assert.Equal(4, c.Get 2)
    Assert.Equal(8, c.Get 6)
    Assert.Equal(8, c.Count)
    
    // add
    a.Insert 0 10 // [ 10; 2; 3; 4; 5 ]
    b.Insert 3 1 // [ 6; 7; 8; 1; 9 ]
    Assert.Equal([10; 2; 3; 4; 5; 6; 7; 8; 1; 9], c)
    
    Assert.Equal(4, c.IndexOf 5)
    Assert.Equal(6, c.IndexOf 7)
    Assert.Equal(-1, c.IndexOf 11)
    Assert.Equal(3, c.Get 2)
    Assert.Equal(7, c.Get 6)
    Assert.Equal(10, c.Count)
    
[<Fact>]
let ``Oc.flatten`` () =
    let mutable counter = 0
    let a = ObservableCollection([1..5])
    let b = ObservableCollection([6..10])
    let c = ObservableCollection([11..15])
    let d = ObservableCollection([a :> IReadOnlyObservableCollection<int>; b :> IReadOnlyObservableCollection<int>])
    
    let e = Oc.flatten d
    
    e.OnChanged.Add(fun _ -> counter <- counter + 1)
    
    Assert.Equal([1..10], e)
    
    d.Remove 0
    Assert.Equal([6; 7; 8; 9; 10], e)
    Assert.Equal(5, e.Count)
    Assert.Equal(8, e.Get 2)
    Assert.Equal(-1, e.IndexOf 1)
    Assert.Equal(1, e.IndexOf 7)
    Assert.Equal(5, counter)
    
    d.Insert 0 c
    Assert.Equal([11; 12; 13; 14; 15; 6; 7; 8; 9; 10], e)
    Assert.Equal(10, e.Count)
    Assert.Equal(13, e.Get 2)
    Assert.Equal(-1, e.IndexOf 1)
    Assert.Equal(6, e.IndexOf 7)
    Assert.Equal(10, counter) 
    
    d.Move 0 1
    Assert.Equal([6..15], e)
    Assert.Equal(10, e.Count)
    Assert.Equal(8, e.Get 2)
    Assert.Equal(-1, e.IndexOf 1)
    Assert.Equal(1, e.IndexOf 7)
    Assert.Equal(20, counter)
    
    d.Set 0 a
    Assert.Equal([1; 2; 3; 4; 5; 11; 12; 13; 14; 15], e)
    Assert.Equal(10, e.Count)
    Assert.Equal(3, e.Get 2)
    Assert.Equal(-1, e.IndexOf 6)
    Assert.Equal(5, e.IndexOf 11)
    Assert.Equal(30, counter)
    
    d.Clear()
    Assert.Equal([], e)
    Assert.Equal(0, e.Count)
    Assert.Equal(-1, e.IndexOf 1)
    Assert.Equal(40, counter)
    
[<Fact>]
let ``Cartesian Product`` () =
    let a = ObservableCollection([1; 2; 3])
    let b = a |> Oc.map (fun i -> ObservableCollection(Array.create i i) :> IReadOnlyObservableCollection<int>)
    let c = b |> Oc.flatten
    let d = ResizeArray(c)
    
    c.OnChanged.Add(Change.commit d)
   
    Assert.Equal([1; 2; 2; 3; 3; 3], c)
    Assert.Equal(c, d)
    
    a.Add 4
    Assert.Equal([1; 2; 2; 3; 3; 3; 4; 4; 4; 4], c)
    Assert.Equal(c, d)
    
    a.Remove(1)
    Assert.Equal([1; 3; 3; 3; 4; 4; 4; 4], c)
    Assert.Equal(c, d)
    
    a.Move 2 0
    Assert.Equal([4; 4; 4; 4; 1; 3; 3; 3], c)
    Assert.Equal(c, d)
    
    a.Set 1 2
    Assert.Equal([4; 4; 4; 4; 2; 2; 3; 3; 3], c)
    Assert.Equal(c, d)
    
    a.Clear()
    Assert.Equal([], c)
    Assert.Equal([], d)