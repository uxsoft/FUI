module Tests

open FUI.ObservableValue
open Xunit

[<Fact>]
let ``ObservableValue is reporting changes`` () =
    let mutable counter = 0    
    let a = oval 1
    a.OnChanged.Add(fun () -> counter <- counter + 1)
    
    a.Value <- 2
    
    a.Update (fun prevState ->
        Assert.Equal(2, prevState)
        prevState + 1)
    
    Assert.Equal(2, counter)
    Assert.Equal(3, a.Value)
    
    