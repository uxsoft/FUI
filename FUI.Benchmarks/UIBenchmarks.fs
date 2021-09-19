module FUI.UIBenchmarks

open BenchmarkDotNet.Attributes

type UIBenchmarks() =
    
    [<Benchmark>]
    member _.Benchmark1() =
        ()