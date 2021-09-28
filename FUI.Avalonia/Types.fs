module FUI.Avalonia.Types

open Avalonia.Controls

type PropertyMeta<'t> =
    { Getter: 't -> obj
      Setter: 't * obj -> unit }
  
type EventMeta =
    { Subscribe: unit -> unit
      Unsubscribe: unit -> unit }

type AttributeMeta<'t> =
    | Property of PropertyMeta<'t>
    | DependencyProperty of Avalonia.AvaloniaProperty
    | Event of IEvent<obj>
    
type Attribute<'t> =
    { Name: string
      Value: obj
      Meta: AttributeMeta<'t> }
    
let dependencyProperty (dp: Avalonia.AvaloniaProperty) v =
    { Name = dp.Name
      Value = v
      Meta = DependencyProperty dp }
   
let property<'t> name value getter setter factory =
    { Name = name
      Value = value
      Meta = Property
          { Getter = getter
            Setter = setter } }
    
let event =
    ()
    
type AvaloniaNode<'t> = 