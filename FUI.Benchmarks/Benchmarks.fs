namespace FUI

open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Jobs
open FUI
open FUI.ObservableCollection
open FUI.ObservableValue
open FUI.Avalonia.DSL
open FUI.IfBuilder

[<SimpleJob(RuntimeMoniker.Net50, invocationCount = 100)>]
[<JsonExporterAttribute.FullCompressed>]
type Benchmarks() =
    
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
    
    [<Benchmark>]
    member _.CounterUI() =
        let model =
            {| Counter = oval 0
               Items = ocol [1; 2; 3] |}
            
        let view () =
            StackPanel {
                TextBlock {
                    let txt = (model.Counter |> Ov.map string)
                    txt
                }
                Button {
                    onClick (fun _ _ -> ())
                    "+"
                }
                Button {
                    onClick (fun _ _ -> ()) 
                    "-"
                }
                
                let isEven = model.Counter |> Ov.map (fun i -> (i % 2) = 0)
                If (isEven) {
                    TextBlock { "even" }
                }
                Else (isEven) {
                    TextBlock { "odd" }
                }
        
                for i in model.Items do
                    for j in model.Items do
                    TextBlock { $"item-{i}-{j}" }
            }
        
        let control = view ()
        model.Counter.Update (fun v -> v + 1)
        model.Counter.Update (fun v -> v - 1)
        model.Counter.Update (fun v -> v + 1)
        model.Items.Add (model.Items.Count + 1)
        model.Items.Add (model.Items.Count + 1)
        model.Items.Add (model.Items.Count + 1)
        model.Items.Remove 0
        model.Items.Remove (model.Items.Count - 1)
        model.Items.Clear()