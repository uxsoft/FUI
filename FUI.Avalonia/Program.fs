module FUI.Avalonia.Program

open Avalonia
open Avalonia.Themes.Fluent
open Avalonia.Controls.ApplicationLifetimes
open FUI.Avalonia.DSL

let createMainWindow () =    
    Window {
        title "Counter Example"
        height 400.
        width 400.
        
        Counter.view ()
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