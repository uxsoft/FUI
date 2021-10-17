module FUI.HotReload.HotReload

open System
open System.Diagnostics
open System.IO
open System.Reactive.Concurrency
open System.Reflection
open System.Text.Json
open System.Reactive.Linq
open FUI.HotReload.Json

type IHotReloadable =
    abstract member GetModel: unit -> obj
    abstract member SetView: 'view -> unit
    
    /// Hydrated accepts current
    abstract member Accept: IHotReloadable -> unit 

let transferModel<'t> previousModel (defaultThunk: unit -> 't) =
    try
        let options = JsonSerializerOptions()
        options.Converters.Add(JsonObservablesConverter())
        
        let json = JsonSerializer.Serialize(previousModel, options)
        let model = JsonSerializer.Deserialize<'t>(json, options)
        
        match box model with
        | null -> defaultThunk()
        | _ -> model
    with err -> defaultThunk()

let watchCode (assemblyPath: string) =
    let path (str: string) = str.Replace("/", string Path.DirectorySeparatorChar)
    
    let projDir =
        path "/bin/"
        |> assemblyPath.LastIndexOf
        |> assemblyPath.Remove
        
    let hotDir = Path.Combine(projDir, path "bin/Hot/")
    let hotFile =
        assemblyPath.Replace(
            path "/bin/",
            path "/bin/Hot/")
    
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

let watchHotAssemblies (hotFile: string, chain: IDisposable list) =
    let hotDir = Path.GetDirectoryName hotFile
    
    if Directory.Exists(hotDir) = false then
        Directory.CreateDirectory(hotDir) |> ignore
    
    let watcher =
        new FileSystemWatcher(
            Path = hotDir,
            Filter = Path.GetFileName(hotFile),
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
    
let reload (current: IHotReloadable) (scheduler: IScheduler) (hotFile: string, event: IEvent<FileSystemEventHandler, FileSystemEventArgs>, chain: IDisposable list) =
    let disposable =
        event 
            .ObserveOn(scheduler)
            .Throttle(TimeSpan.FromSeconds(0.1))
            .Select(fun e -> hydrate hotFile)
            .Subscribe(fun hydrated -> hydrated.Accept current)
        
    chain @ [ disposable ]

let hotReload (current: IHotReloadable) (scheduler: IScheduler) =
    let assemblyPath = current.GetType().Assembly.Location
    
    let disposables = 
        assemblyPath
        |> watchCode 
        |> watchHotAssemblies
        |> reload current scheduler
    
    disposables