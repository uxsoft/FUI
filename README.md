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

## License
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2Fuxsoft%2FFUI.svg?type=large)](https://app.fossa.com/projects/git%2Bgithub.com%2Fuxsoft%2FFUI?ref=badge_large)