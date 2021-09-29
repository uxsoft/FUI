module FUI.Avalonia.NumericUpDown

open System.Globalization

open Avalonia.Controls
open FUI.UiBuilder
open FUI.Avalonia.TemplatedControl
open Avalonia.FuncUI.Builder

type NumericUpDownBuilder<'t when 't :> NumericUpDown>() =
    inherit TemplatedControlBuilder<'t>()

    /// <summary>
    /// Sets a value indicating whether the <see cref="NumericUpDown"/> should allow to spin.
    /// </summary>
    [<CustomOperation("allowSpin")>]
    member _.allowSpin<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(NumericUpDown.AllowSpinProperty, value, ValueNone) ]

    /// <summary>
    /// Sets a value indicating whether the up and down buttons should be shown.
    /// </summary>
    [<CustomOperation("showButtonSpinner")>]
    member _.showButtonSpinner<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(NumericUpDown.ShowButtonSpinnerProperty, value, ValueNone) ]

    /// <summary>
    /// Sets current location of the <see cref="NumericUpDown"/>.
    /// </summary>
    [<CustomOperation("buttonSpinnerLocation")>]
    member _.buttonSpinnerLocation<'t>(x: Node<_, _>, value: Location) =
        Types.dependencyProperty<Location>(NumericUpDown.ButtonSpinnerLocationProperty, value, ValueNone) ]

    /// <summary>
    /// Sets if the value should be clipped if the minimum/maximum is reached
    /// </summary>
    [<CustomOperation("clipValueToMinMax")>]
    member _.clipValueToMinMax<'t>(x: Node<_, _>, value: bool) =
        let getter : ('t -> bool) = (fun control -> control.ClipValueToMinMax)
        let setter : ('t * bool -> unit) = (fun (control, value) -> control.ClipValueToMinMax <- value)

        Types.dependencyProperty<bool>("ClipValueToMinMax", value, ValueSome getter, ValueSome setter, ValueNone) ]

    /// <summary>
    /// Sets the culture info used for formatting
    /// </summary>
    [<CustomOperation("cultureInfo")>]
    member _.cultureInfo<'t>(x: Node<_, _>, value: CultureInfo) =
        let getter : ('t -> CultureInfo) = (fun control -> control.CultureInfo)
        let setter : ('t * CultureInfo -> unit) = (fun (control, value) -> control.CultureInfo <- value)

        Types.dependencyProperty<CultureInfo>("CultureInfo", value, ValueSome getter, ValueSome setter, ValueNone) ]

    [<CustomOperation("formatString")>]
    member _.formatString<'t>(x: Node<_, _>, value: string) =
        Types.dependencyProperty<string>(NumericUpDown.FormatStringProperty, value, ValueNone) ]

    [<CustomOperation("increment")>]
    member _.increment<'t>(x: Node<_, _>, value: double) =
        Types.dependencyProperty<double>(NumericUpDown.IncrementProperty, value, ValueNone) ]

    [<CustomOperation("isReadOnly")>]
    member _.isReadOnly<'t>(x: Node<_, _>, value: bool) =
        Types.dependencyProperty<bool>(NumericUpDown.IsReadOnlyProperty, value, ValueNone) ]

    [<CustomOperation("minimum")>]
    member _.minimum<'t>(x: Node<_, _>, value: double) =
        Types.dependencyProperty<double>(NumericUpDown.MinimumProperty, value, ValueNone) ]

    [<CustomOperation("maximum")>]
    member _.maximum<'t>(x: Node<_, _>, value: double) =
        Types.dependencyProperty<double>(NumericUpDown.MaximumProperty, value, ValueNone) ]

    [<CustomOperation("parsingNumberStyle")>]
    member _.parsingNumberStyle<'t>(x: Node<_, _>, value: NumberStyles) =
        let getter : ('t -> NumberStyles) = (fun control -> control.ParsingNumberStyle)
        let setter : ('t * NumberStyles -> unit) = (fun (control, value) -> control.ParsingNumberStyle <- value)

        Types.dependencyProperty<NumberStyles>("ParsingNumberStyle", value, ValueSome getter, ValueSome setter, ValueNone) ]

    [<CustomOperation("text")>]
    member _.text<'t>(x: Node<_, _>, value: string) =
        let getter : ('t -> string) = (fun control -> control.Text)
        let setter : ('t * string -> unit) = (fun (control, value) -> control.Text <- value)

        Types.dependencyProperty<string>("Text", value, ValueSome getter, ValueSome setter, ValueNone) ]

    [<CustomOperation("onTextChanged")>]
    member _.onTextChanged<'t>(x: Node<_, _>, func: string -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<string>(NumericUpDown.TextProperty, func) ]

    [<CustomOperation("value")>]
    member _.value<'t>(x: Node<_, _>, value: double) =
        let getter : ('t -> double) = (fun control -> control.Value)
        let setter : ('t * double -> unit) = (fun (control, value) -> control.Value <- value)

        Types.dependencyProperty<double>("Value", value, ValueSome getter, ValueSome setter, ValueNone) ]

    [<CustomOperation("onValueChanged")>]
    member _.onValueChanged<'t>(x: Node<_, _>, func: double -> unit) =
        x @@ [ AttrBuilder<'t>.CreateSubscription<double>(NumericUpDown.ValueProperty, func) ]

    [<CustomOperation("watermark")>]
    member _.watermark<'t>(x: Node<_, _>, value: string) =
        Types.dependencyProperty<string>(NumericUpDown.WatermarkProperty, value, ValueNone) ]