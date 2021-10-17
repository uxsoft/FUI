namespace FUI

open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Jobs
open FUI
open FUI.ObservableCollection
open FUI.ObservableValue
open FUI.Avalonia.DSL
open FUI.IfBuilder

[<SimpleJob(invocationCount = 50)>]
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
            {| Counter = var 0
               Items = col [1; 2; 3] |}
            
        let view () =
            StackPanel {
                Label {
                    let txt = (model.Counter |> Ov.map string)
                    txt
                }
                Button {
                    onClick (fun _ -> ())
                    "+"
                }
                Button {
                    onClick (fun _ -> ()) 
                    "-"
                }
                
                let isEven = model.Counter |> Ov.map (fun i -> (i % 2) = 0)
                If (isEven) {
                    Label { "even" }
                }
                Else (isEven) {
                    Label { "odd" }
                }
        
                for i in model.Items do
                    for j in model.Items do
                        Label { $"item-{i}-{j}" }
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