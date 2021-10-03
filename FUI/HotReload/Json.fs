module FUI.HotReload.Json

open System
open System.Text.Json
open System.Text.Json.Serialization
open FUI.ObservableCollection
open FUI.ObservableValue
    
type JsonColConverter<'T when 'T : comparison>() =
    inherit JsonConverter<ObservableCollection<'T>>()

    override _.Read(reader, _, options) =
        let value = JsonSerializer.Deserialize<List<'T>>(&reader, options)
        ObservableCollection value

    override _.Write(writer, value, options) =
        JsonSerializer.Serialize<seq<'T>>(writer, value, options)

type JsonVarConverter<'T when 'T : comparison>() =
    inherit JsonConverter<ObservableValue<'T>>()

    override _.Read(reader, _, options) =
        let value = JsonSerializer.Deserialize<'T>(&reader, options)
        ObservableValue value

    override _.Write(writer, value, options) =
        JsonSerializer.Serialize<'T>(writer, value.Value, options)
        
type JsonObservablesConverter() =
    inherit JsonConverterFactory()
    
    let isCol (t: Type) =
        if t.IsGenericType then
            t.GetGenericTypeDefinition() = typedefof<ObservableCollection<_>>
        else false
        
    let isVar (t: Type) =
        if t.IsGenericType then
            t.GetGenericTypeDefinition() = typedefof<ObservableValue<_>>
        else false
    
    override x.CanConvert(typeToConvert: Type) =
        isCol typeToConvert || isVar typeToConvert
        
    override x.CreateConverter(typeToConvert: Type, options: JsonSerializerOptions) =
        if isVar typeToConvert then
            let itemType = typeToConvert.GetGenericArguments().[0]
            let converterType = typedefof<JsonVarConverter<_>>.MakeGenericType([| itemType |])
            Activator.CreateInstance(converterType) :?> JsonConverter
            
        elif isCol typeToConvert then
            let itemType = typeToConvert.GetGenericArguments().[0]
            let converterType = typedefof<JsonColConverter<_>>.MakeGenericType([| itemType |])
            Activator.CreateInstance(converterType) :?> JsonConverter
            
        else
            null