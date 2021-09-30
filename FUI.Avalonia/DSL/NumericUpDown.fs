module FUI.Avalonia.NumericUpDown

open System.Globalization

open Avalonia.Controls
open FUI.Avalonia.TemplatedControl

type NumericUpDownBuilder<'t when 't :> NumericUpDown and 't : equality>() =
    inherit TemplatedControlBuilder<'t>()

    /// <summary>
    /// Sets a value indicating whether the <see cref="NumericUpDown"/> should allow to spin.
    /// </summary>
    [<CustomOperation("allowSpin")>]
    member _.allowSpin<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x NumericUpDown.AllowSpinProperty value

    /// <summary>
    /// Sets a value indicating whether the up and down buttons should be shown.
    /// </summary>
    [<CustomOperation("showButtonSpinner")>]
    member _.showButtonSpinner<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x NumericUpDown.ShowButtonSpinnerProperty value

    /// <summary>
    /// Sets current location of the <see cref="NumericUpDown"/>.
    /// </summary>
    [<CustomOperation("buttonSpinnerLocation")>]
    member _.buttonSpinnerLocation<'t>(x: Types.AvaloniaNode<'t>, value: Location) =
        Types.dependencyProperty x NumericUpDown.ButtonSpinnerLocationProperty value

    /// <summary>
    /// Sets if the value should be clipped if the minimum/maximum is reached
    /// </summary>
    [<CustomOperation("clipValueToMinMax")>]
    member _.clipValueToMinMax<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        let getter : ('t -> obj) = (fun control -> box control.ClipValueToMinMax)
        let setter : ('t * obj -> unit) = (fun (control, value) -> control.ClipValueToMinMax <- unbox<bool> value)

        Types.property x "ClipValueToMinMax" value getter setter (fun () -> box false)

    /// <summary>
    /// Sets the culture info used for formatting
    /// </summary>
    [<CustomOperation("cultureInfo")>]
    member _.cultureInfo<'t>(x: Types.AvaloniaNode<'t>, value: CultureInfo) =
        let getter : ('t -> obj) = (fun control -> box control.CultureInfo)
        let setter : ('t * obj -> unit) = (fun (control, value) -> control.CultureInfo <- unbox<CultureInfo> value)

        Types.property x "CultureInfo" value getter setter (fun () -> box CultureInfo.CurrentCulture)

    [<CustomOperation("formatString")>]
    member _.formatString<'t>(x: Types.AvaloniaNode<'t>, value: string) =
        Types.dependencyProperty x NumericUpDown.FormatStringProperty value

    [<CustomOperation("increment")>]
    member _.increment<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x NumericUpDown.IncrementProperty value

    [<CustomOperation("isReadOnly")>]
    member _.isReadOnly<'t>(x: Types.AvaloniaNode<'t>, value: bool) =
        Types.dependencyProperty x NumericUpDown.IsReadOnlyProperty value

    [<CustomOperation("minimum")>]
    member _.minimum<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x NumericUpDown.MinimumProperty value

    [<CustomOperation("maximum")>]
    member _.maximum<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        Types.dependencyProperty x NumericUpDown.MaximumProperty value

    [<CustomOperation("parsingNumberStyle")>]
    member _.parsingNumberStyle<'t>(x: Types.AvaloniaNode<'t>, value: NumberStyles) =
        let getter : ('t -> obj) = (fun control -> box control.ParsingNumberStyle)
        let setter : ('t * obj -> unit) = (fun (control, value) -> control.ParsingNumberStyle <- unbox<NumberStyles> value)

        Types.property x "ParsingNumberStyle" value getter setter (fun () -> box NumberStyles.Any)

    [<CustomOperation("text")>]
    member _.text<'t>(x: Types.AvaloniaNode<'t>, value: string) =
        let getter : ('t -> obj) = (fun control -> box control.Text)
        let setter : ('t * obj -> unit) = (fun (control, value) -> control.Text <- unbox<string> value)

        Types.property x "Text" value getter setter (fun () -> box "")

    [<CustomOperation("onTextChanged")>]
    member _.onTextChanged<'t>(x: Types.AvaloniaNode<'t>, func: string -> unit) =
        Types.dependencyPropertyEvent x NumericUpDown.TextProperty func

    [<CustomOperation("value")>]
    member _.value<'t>(x: Types.AvaloniaNode<'t>, value: double) =
        let getter : ('t -> obj) = (fun control -> box control.Value)
        let setter : ('t * obj -> unit) = (fun (control, value) -> control.Value <- unbox<double> value)

        Types.property x "Value" value getter setter

    [<CustomOperation("onValueChanged")>]
    member _.onValueChanged<'t>(x: Types.AvaloniaNode<'t>, func: double -> unit) =
        Types.dependencyPropertyEvent x NumericUpDown.ValueProperty func

    [<CustomOperation("watermark")>]
    member _.watermark<'t>(x: Types.AvaloniaNode<'t>, value: string) =
        Types.dependencyProperty x NumericUpDown.WatermarkProperty value