module FUI.Avalonia.Helpers

open Avalonia.Controls

[<CustomEquality; NoComparison>]
type PropertyAccessor =
    { Name: string
      Getter: (IControl -> obj) voption
      Setter: (IControl * obj -> unit) voption }
    
    override this.Equals (other: obj) : bool =
        match other with
        | :? PropertyAccessor as other -> this.Name = other.Name
        | _ -> false
        
    override this.GetHashCode () =
        this.Name.GetHashCode()

type Accessor =
    | InstanceProperty of PropertyAccessor
    | AvaloniaProperty of Avalonia.AvaloniaProperty   

[<CustomEquality; NoComparison>]
type Property =
    { Accessor: Accessor
      Value: obj
      DefaultValueFactory: (unit -> obj) voption
      Comparer: (obj * obj -> bool) voption }
    
    override this.Equals (other: obj) : bool =
        match other with
        | :? Property as other ->
            match this.Accessor.Equals other.Accessor with
            | true ->
                match this.Comparer with
                | ValueSome comparer -> comparer(this.Value, other.Value)
                | ValueNone -> this.Value = other.Value
                
            | false ->
                false
            
        | _ ->
            false
        
    override this.GetHashCode () =
        (this.Accessor, this.Value).GetHashCode()
