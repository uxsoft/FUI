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
    
    Change.commit items (Remove(2, -1))
    Assert.Equal([1..5], items)