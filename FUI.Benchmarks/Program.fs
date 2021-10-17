open BenchmarkDotNet.Configs
open BenchmarkDotNet.Running
open FUI

[<EntryPoint>]
let main argv =
#if DEBUG
    let summary = BenchmarkRunner.Run<Benchmarks>(DebugInProcessConfig())
#else 
    let summary = BenchmarkRunner.Run<Benchmarks>()
#endif
    0 // return an integer exit code