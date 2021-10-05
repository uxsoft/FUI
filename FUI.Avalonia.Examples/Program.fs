module FUI.Avalonia.Program

open Avalonia
open Avalonia.Controls
open Avalonia.Controls.Presenters
open Avalonia.Themes.Fluent
open Avalonia.Controls.ApplicationLifetimes
open Avalonia.Threading
open FUI.Avalonia.DSL
open FUI.HotReload.HotReload

type Hot() as this =
    inherit ContentPresenter()
    
    let model = Counter.init()
    do this.Content <- Counter.view model
    
    interface IHotReloadable with
        member this.Accept(old) =
            // hydrated accepts current
            let m = transferModel (old.GetModel()) Counter.init // Transfer existing model data to new model type
            let v = Counter.view m // Build UI using new view
            old.SetView v // Use old container to host new UI
            
        member this.GetModel() =
            box model
                    
        member this.SetView(view) =
            this.Content <- view

let createMainWindow () =    
    Window {
        title "Counter Example"
        height 400.
        width 400.
        
        let hot = Hot()
        hotReload hot AvaloniaScheduler.Instance |> ignore
        hot
    }
        
type App() =
    inherit Application()
    override this.Initialize() =
        this.Styles.Add(FluentTheme(baseUri = null, Mode = FluentThemeMode.Light))

    override this.OnFrameworkInitializationCompleted() =
        match this.ApplicationLifetime with
        | :? IClassicDesktopStyleApplicationLifetime as desktopLifetime ->            
            desktopLifetime.MainWindow <- createMainWindow()
        | _ -> ()
    
[<EntryPoint>]
let main(args: string[]) =
    AppBuilder
        .Configure<App>()
        .UsePlatformDetect()
        .UseSkia()
        .StartWithClassicDesktopLifetime(args)