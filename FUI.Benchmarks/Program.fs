open BenchmarkDotNet.Running
open FUI

[<EntryPoint>]
let main argv =
    let summary = BenchmarkRunner.Run<Benchmarks>()
    0 // return an integer exit code