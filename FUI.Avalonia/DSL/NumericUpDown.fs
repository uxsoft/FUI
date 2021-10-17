module FUI.Avalonia.NumericUpDown

open System.Globalization

open Avalonia.Controls
open FUI.Avalonia.TemplatedControl

type NumericUpDownBuilder<'t when 't :> NumericUpDown and 't : equality>() =
    inherit TemplatedControlBuilder<'t>()

    /// bool | ObservableValue<bool>
    [<CustomOperation("allowSpin")>]
    member _.allowSpin<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x NumericUpDown.AllowSpinProperty value

    /// bool | ObservableValue<bool>
    [<CustomOperation("showButtonSpinner")>]
    member _.showButtonSpinner<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x NumericUpDown.ShowButtonSpinnerProperty value

    /// Location | ObservableValue<Location>
    [<CustomOperation("buttonSpinnerLocation")>]
    member _.buttonSpinnerLocation<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x NumericUpDown.ButtonSpinnerLocationProperty value

    /// bool | ObservableValue<bool>
    [<CustomOperation("clipValueToMinMax")>]
    member _.clipValueToMinMax<'t, 'v>(x, value: 'v) =
        let setter : ('t * obj -> unit) = (fun (control, value) -> control.ClipValueToMinMax <- unbox<bool> value)
        let factory() = box false
        Types.property x "ClipValueToMinMax" value setter factory

    /// CultureInfo | ObservableValue<CultureInfo>
    [<CustomOperation("cultureInfo")>]
    member _.cultureInfo<'t, 'v>(x, value: 'v) =
        let getter : ('t -> obj) = (fun control -> box control.CultureInfo)
        let setter : ('t * obj -> unit) = (fun (control, value) -> control.CultureInfo <- unbox<CultureInfo> value)
        let factory() = box CultureInfo.CurrentCulture
        Types.property x "CultureInfo" value setter factory

    /// string | ObservableValue<string>
    [<CustomOperation("formatString")>]
    member _.formatString<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x NumericUpDown.FormatStringProperty value

    /// double | ObservableValue<double>
    [<CustomOperation("increment")>]
    member _.increment<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x NumericUpDown.IncrementProperty value

    /// bool | ObservableValue<bool>
    [<CustomOperation("isReadOnly")>]
    member _.isReadOnly<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x NumericUpDown.IsReadOnlyProperty value

    /// double | ObservableValue<double>
    [<CustomOperation("minimum")>]
    member _.minimum<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x NumericUpDown.MinimumProperty value

    /// double | ObservableValue<double>
    [<CustomOperation("maximum")>]
    member _.maximum<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x NumericUpDown.MaximumProperty value

    /// NumberStyles | ObservableValue<NumberStyles>
    [<CustomOperation("parsingNumberStyle")>]
    member _.parsingNumberStyle<'t, 'v>(x, value: 'v) =
        let setter : ('t * obj -> unit) = (fun (control, value) -> control.ParsingNumberStyle <- unbox<NumberStyles> value)
        let factory() = box NumberStyles.Any
        Types.property x "ParsingNumberStyle" value setter factory

    /// string | ObservableValue<string>
    [<CustomOperation("text")>]
    member _.text<'t, 'v>(x, value: 'v) =
        let setter : ('t * obj -> unit) = (fun (control, value) -> control.Text <- unbox<string> value)
        let factory() = box ""
        Types.property x "Text" value setter factory

    [<CustomOperation("onTextChanged")>]
    member _.onTextChanged<'t, 'v>(x, func: string -> unit) =
        Types.dependencyPropertyEvent x NumericUpDown.TextProperty func

    /// double | ObservableValue<double>
    [<CustomOperation("value")>]
    member _.value<'t, 'v>(x, value: 'v) =
        let setter : ('t * obj -> unit) = (fun (control, value) -> control.Value <- unbox<double> value)
        let factory() = box 0.
        Types.property x "Value" value setter factory

    [<CustomOperation("onValueChanged")>]
    member _.onValueChanged<'t, 'v>(x, func: double -> unit) =
        Types.dependencyPropertyEvent x NumericUpDown.ValueProperty func

    /// string | ObservableValue<string>
    [<CustomOperation("watermark")>]
    member _.watermark<'t, 'v>(x, value: 'v) =
        Types.dependencyProperty x NumericUpDown.WatermarkProperty value