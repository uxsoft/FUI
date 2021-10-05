module FUI.Avalonia.Hot

open System
open Avalonia.Controls.Presenters
open FUI.HotReload.HotReload

//type HotModule<'model, 'view>(init: unit -> 'model, view: 'model -> 'view) as this =
//    inherit ContentPresenter()
//    
//    let model = init()
//    do this.Content <- view model
//    
//    interface IHotReloadable with
//        member this.Accept(current) =
//            // hydrated accepts current
//            let m = transferModel (current.GetModel()) init // Transfer existing model data to new model type
//            let v = view m // Build UI using new view
//            current.SetView v // Use old container to host new UI
//            
//        member this.GetModel() =
//            box model
//                    
//        member this.SetView(view) =
//            this.Content <- view

//type App<'model, 'view>(init: unit -> 'model, view: 'model -> 'view) as this =
//    inherit ContentPresenter()
//    
//    let model: 'model = init() 
//    do this.Content <- view model
//
//type HotApp<'model, 'view>(init: unit -> 'model, view: 'model -> 'view) as this =
//    inherit ContentPresenter()
//    
//    let disposables = ResizeArray<IDisposable>()
//    
//    let hot = HotModule(init, view)
//    
//    do this.Content <- hot
    
//#if DEBUG
//    do hotReload hot |> disposables.AddRange
//#endif
//    
//    interface IDisposable with
//        member this.Dispose() =
//            for d in disposables do
//                d.Dispose()