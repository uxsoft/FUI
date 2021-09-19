open BenchmarkDotNet.Running
open FUI.UIBenchmarks

[<EntryPoint>]
let main argv =
    let summary = BenchmarkSwitcher([| typeof<UIBenchmarks> |]).Run(argv)
    0 // return an integer exit code