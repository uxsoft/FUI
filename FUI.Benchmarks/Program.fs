open BenchmarkDotNet.Running
open FUI.Benchmarks.Benchmark

[<EntryPoint>]
let main argv =
    let summary = BenchmarkRunner.Run<Benchmarks>()
    0 // return an integer exit code