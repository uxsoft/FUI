module FUI.Benchmarks.UIBenchmarks

open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Jobs
open BenchmarkDotNet.Running

[<SimpleJob(RuntimeMoniker.Net50)>]
type UIBenchmarks() =
    
    [<Benchmark>]
    member _.Benchmark1() =
        ()