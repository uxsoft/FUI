open BenchmarkDotNet.Configs
open BenchmarkDotNet.Running
open FUI

[<EntryPoint>]
let main argv =
    let summary = BenchmarkRunner.Run<Benchmarks>(DebugInProcessConfig())
    0 // return an integer exit code