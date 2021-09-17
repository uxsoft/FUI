# FUI

## Goals
- Declarative
    - Describes how the UI should look like with F#, let the framework figure out what changes to the UI need to be made 
- Hot Reload
    - Model and output of View function can be serialised to JSON
- Performant
    - Avoid virtual dom and diffing as much as possible
- Scalable
    -  Able to decompose big application to components with precalculated lenses to the global model and update methods