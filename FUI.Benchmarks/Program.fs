open BenchmarkDotNet.Running
open FUI.Benchmarks.ObservablesBenchmarks
open FUI.Benchmarks.UIBenchmarks


[<EntryPoint>]
let main argv =
    let summary = BenchmarkSwitcher([| typeof<ObservablesBenchmarks>; typeof<UIBenchmarks> |]).Run(argv)
    0 // return an integer exit code