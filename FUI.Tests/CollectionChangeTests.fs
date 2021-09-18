module FUI.Tests.CollectionChangeTests

open Xunit
open FUI
open FUI.CollectionChange
open Xunit

[<Fact>]
let ``Change.commit`` () =
    let items = ResizeArray([1; 2; 3; 4; 5])
    
    Change.commit items (Insert(2, 6))
    Assert.Equal([1; 2; 6; 3; 4; 5], items)
    
    Change.commit items (Move(2, 3, -1))
    Assert.Equal([1; 2; 3; 6; 4; 5], items)
    
    Change.commit items (Move(3, 2, -1))
    Assert.Equal([1; 2; 6; 3; 4; 5], items)
    
    Change.commit items (Replace(2, -1, 7))
    Assert.Equal([1; 2; 7; 3; 4; 5], items)
    
    Change.commit items (Remove(2, -1))
    Assert.Equal([1..5], items)
    
    Change.commit items (Clear)
    Assert.Equal([], items)