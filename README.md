# FUI
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2Fuxsoft%2FFUI.svg?type=shield)](https://app.fossa.com/projects/git%2Bgithub.com%2Fuxsoft%2FFUI?ref=badge_shield)
[![codecov](https://codecov.io/gh/uxsoft/FUI/branch/master/graph/badge.svg?token=ZHM5GSQ1T7)](https://codecov.io/gh/uxsoft/FUI)


## Goals
- Declarative
    - Describes how the UI should look like with F#, let the framework figure out what changes to the UI need to be made 
- Hot Reload
    - Model and output of View function can be serialised to JSON
- Performant
    - Avoid Virtual DOM and diffing by taking a Reactive approach
- Scalable
    -  Able to decompose big application to components with precalculated lenses to the global model and update methods
- Multi Platform
    - The following platforms should be supported through modular bindings
        - FsBolero/Blazor
        - Avalonia
        - Maui
        - WinUI 3

## Declarative DSL 

```fsharp
type Model =
    { Counter: int oval
      Items: int ocol }
    
let init () =
    { Counter = oval 0
      Items = ocol [1; 2; 3] }
    
let view () =
    let model = init ()
    
    StackPanel {
        TextBlock {
            let txt = (model.Counter |> Ov.map string)
            txt
        }
        Button {
            onClick (fun _ _ ->
                model.Items.Add (model.Items.Count + 1)
                model.Counter.Update (fun v -> v + 1))
            "+"
        }
        Button {
            onClick (fun _ _ ->
                model.Items.Remove (model.Items.Count - 1)
                model.Counter.Update (fun v -> v - 1)) 
            "-"
        }
        Button {
            onClick (fun _ _ ->
                model.Items.Clear()
                model.Counter.Update (fun _ -> 0)) 
            "reset"
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
```

## License
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2Fuxsoft%2FFUI.svg?type=large)](https://app.fossa.com/projects/git%2Bgithub.com%2Fuxsoft%2FFUI?ref=badge_large)
