module FUI.Tests.BuilderTests

open FUI
open FUI.ObservableCollection
open Xunit

[<Fact>]
let ``Builder.appendStatic`` () =
    let result =
        Builder.empty
        |> Builder.appendStatic 1
        |> Builder.appendStatic 2
        |> Builder.appendStatic 3
        |> Builder.build
    
    Assert.Equal([1..3], result)

[<Fact>]
let ``Builder.appendStatics`` () =
    let result =
        Builder.empty
        |> Builder.appendStatic 1
        |> Builder.appendStatics [2..4]
        |> Builder.appendStatic 5
        |> Builder.build
    
    Assert.Equal([1..5], result)
    
[<Fact>]
let ``Builder.appendObservable`` () =
    let a = ObservableCollection [3..5]
    let result =
        Builder.empty
        |> Builder.appendStatic 1
        |> Builder.appendStatic 2
        |> Builder.appendObservable a
        |> Builder.build
    
    Assert.Equal([1..5], result)
    
    a.Insert 3 6
    Assert.Equal([1..6], result)
    
[<Fact>]
let ``Builder.append`` () =
    let a = Builder.init [1; 2]
    let b = Builder.init [3; 4]
    let c = Builder.append a b
    let d =
        c
        |> Builder.appendStatic 5
        |> Builder.build
    
    Assert.Equal([1..5], d)

[<Fact>]
let ``Builder.concat`` () =
    let a = Builder.init [1; 2]
    let b = Builder.init [3; 4]
    let c = Builder.concat [a; b]
    let d =
        c
        |> Builder.appendStatic 5
        |> Builder.build
    
    Assert.Equal([1..5], d)

[<Fact>]
let ``Builder.map`` () =
    let a = Builder.init [1..5]
    let b =
        a
        |> Builder.map (fun i -> i * 2)
        |> Builder.build
    
    Assert.Equal([2; 4; 6; 8; 10], b)