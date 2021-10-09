module FUI.Avalonia.Examples.Library

open Avalonia.Media

let random = System.Random()
let randomByte() = random.Next(256) |> byte

let randomColor() =
    Color(255uy, randomByte(), randomByte(), randomByte())