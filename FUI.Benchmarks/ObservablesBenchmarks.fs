module FUI.Benchmarks.ObservablesBenchmarks

open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Jobs
open FUI
open FUI.ObservableCollection

[<SimpleJob(RuntimeMoniker.Net50)>]
type ObservablesBenchmarks() =
    
    [<Benchmark>]
    member _.CartesianProduct() =
        let a = ObservableCollection([1..5])
        let b = a |> Oc.map (fun i -> ObservableCollection(Array.create i i) :> IReadOnlyObservableCollection<int>)
        let c = b |> Oc.flatten
        let d = ResizeArray(c)
        
        c.OnChanged.Add(Change.commit d)
        a.Add 6
        a.Remove(1)
        a.Move 2 0
        a.Set 1 2
        a.Clear()