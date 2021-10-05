module FUI.Tests.TransferModel

open FUI.HotReload
open FUI.ObservableCollection
open FUI.ObservableValue
open Xunit

type StaticModel =
    { Str: string 
      Col: int list 
      Obj: {| ObjVal: string  |} } 


[<Fact>]
let ``Transfer static model`` () =
    let model : StaticModel = 
        { Str = "str"
          Col = [1; 2]
          Obj = {| ObjVal = "objVal" |} }
    
    let modelCopy = HotReload.transferModel<StaticModel> model (fun () -> failwith "Should not fall back")
    
    Assert.Equal(model, modelCopy)

type VarModel =
    { Str: string var } 
    
[<Fact>]
let ``Transfer model with ObservableValue`` () =
    let model : VarModel = 
        { Str = var "asd"  }
    
    let modelCopy = HotReload.transferModel<VarModel> model (fun () -> failwith "Should not fall back")
    
    Assert.Equal(model, modelCopy)
    
type ColModel =
    { Col: int col } 
    
[<Fact>]
let ``Transfer model with ObservableCollection`` () =
    let model : ColModel = 
        { Col = col [ 1; 2 ] }
    
    let modelCopy = HotReload.transferModel<ColModel> model (fun () -> failwith "Should not fall back")
    
    Assert.Equal(model, modelCopy)

type Model =
    { Str: string var
      Col: int col
      Obj: {| ObjVal: string var |} var } 

[<Fact>]
let ``Transfer complex model`` () =
    let model : Model = 
        { Str = var "str" 
          Col = col [ 1; 2 ]
          Obj = var {| ObjVal = var "objVal" |}  }
    
    let modelCopy = HotReload.transferModel<Model> model (fun () -> failwith "Should not fall back")
    
    Assert.Equal(model, modelCopy)