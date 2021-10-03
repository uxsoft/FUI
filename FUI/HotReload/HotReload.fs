module FUI.HotReload.HotReload

open System
open System.Diagnostics
open System.IO
open System.Reactive.Subjects
open System.Reflection
open System.Text.Json
open FUI.HotReload.Json

type IHotReloadable =
    abstract member Accept: IHotReloadable -> unit 
    

let transferModel<'t> previousModel =
    try
        let options = JsonSerializerOptions()
        options.Converters.Add(JsonObservablesConverter())
        
        let json = JsonSerializer.Serialize(previousModel, options)
        let model = JsonSerializer.Deserialize<'t>(json, options)
        
        match box model with
        | null -> None
        | _ -> Some model
    with err -> None

let compileOnChange (assemblyPath: string) =
    let projDir =
        Path.Combine("", "bin", "")
        |> assemblyPath.LastIndexOf
        |> assemblyPath.Remove
        
    let hotDir = Path.Combine(projDir, "bin", "Hot")
    let hotFile = Path.Combine(hotDir, Path.GetFileName(assemblyPath))
    
    if Directory.Exists(hotDir) then
        Directory.Delete(hotDir, true)
    
    Directory.CreateDirectory(hotDir) |> ignore

    let proc =
        new Process(
            StartInfo = ProcessStartInfo(
                FileName = "dotnet",
                Arguments = $"watch msbuild /p:BaseOutputPath={hotDir}",
                UseShellExecute = true,
                CreateNoWindow = true,
                RedirectStandardOutput = false,
                RedirectStandardError = false,
                WorkingDirectory = projDir))
    
    if proc.Start() = false then
        failwith "Failed to start dotnet watch"
    
    (hotFile, [proc :> IDisposable])

let notifyOnCompile (hotFile: string, chain: IDisposable list) =
    let hotDir = Path.GetDirectoryName hotFile
    let watcher =
        new FileSystemWatcher(
            Path = hotDir,
            Filter = hotFile,
            IncludeSubdirectories = true,
            EnableRaisingEvents = true)
    
    (hotFile, watcher.Changed, chain @ [ watcher :> IDisposable ])

let hydrate (hotFile: string) =
    let assemblyBytes = File.ReadAllBytes(hotFile)
    let assembly = Assembly.Load(assemblyBytes)
    
    let interfaceType = typeof<IHotReloadable>
    let reloadables =
        assembly.GetTypes()
        |> Seq.filter(interfaceType.IsAssignableFrom)
        |> Seq.toList

    let reloadable =
        reloadables
        |> List.tryHead
        |> Option.defaultWith (fun _ -> failwith $"No implementation of {nameof IHotReloadable} found")
    
    let instance = Activator.CreateInstance(reloadable)
    instance :?> IHotReloadable
    
let reload (reloadable: IHotReloadable) =
    ()
    
let subscribeHydrateAndReload (hotFile: string, event: IEvent<FileSystemEventHandler, FileSystemEventArgs>, chain: IDisposable list) =
    let disposable =
        event 
        |> Event.map (fun _ -> hydrate hotFile)
        |> (fun e -> e.Subscribe reload)
        
    chain @ [ disposable ]

let hotReload (view: IHotReloadable) =
    let assemblyPath = view.GetType().Assembly.Location
    
    let disposables = 
        assemblyPath
        |> compileOnChange 
        |> notifyOnCompile
        |> subscribeHydrateAndReload
    
    disposables