module Avalonia.FuncUI.Experiments.DSL.DSL

open Avalonia.Controls
open Avalonia.Controls
open Avalonia.Controls.Primitives
open Avalonia.Controls.Shapes
open Avalonia.FuncUI.Experiments.DSL
open Avalonia.FuncUI.Experiments.DSL.ProgressBar

let Panel = Panel.PanelBuilder<Panel>()
let Canvas = Canvas.CanvasBuilder<Canvas>()
let DockPanel = DockPanel.DockPanelBuilder<DockPanel>()
let Grid = Grid.GridBuilder<Grid>()
let StackPanel = StackPanel.StackPanelBuilder<StackPanel>()
let WrapPanel = WrapPanel.WrapPanelBuilder<WrapPanel>()
let ItemsRepeater = ItemsRepeater.ItemsRepeaterBuilder<ItemsRepeater>()
let UniformGrid = UniformGrid.UniformGridBuilder<UniformGrid>()

let Rectangle = Rectangle.RectangleBuilder<Rectangle>()
let Ellipse = Ellipse.EllipseBuilder<Ellipse>()
let Line = Line.LineBuilder<Line>()
let Polyline = Polyline.PolylineBuilder<Polyline>()
let Polygon = Polygon.PolygonBuilder<Polygon>()
let Path = Path.PathBuilder<Path>()

let LayoutTransform = LayoutTransformControl.LayoutTransformControlBuilder<LayoutTransformControl>()
let ViewBox = ViewBox.ViewBoxBuilder<Viewbox>()
let Border = Border.BorderBuilder<Border>()
let AcrylicBorder = AcrylicBorder.AcrylicBorderBuilder<ExperimentalAcrylicBorder>()

let ListBox = ListBox.ListBoxBuilder<ListBox>()
let ListBoxItem = ListBoxItem.ListBoxItemBuilder<ListBoxItem>()
let TabStrip = TabStrip.TabStripBuilder<TabStrip>()
let TabStripItem = TabStripItem.TabStripItemBuilder<TabStripItem>()
let ComboBox = ComboBox.ComboBoxBuilder<ComboBox>()
let ComboBoxItem = ComboBoxItem.ComboBoxItemBuilder<ComboBoxItem>()
let Carousel = Carousel.CarouselBuilder<Carousel>()
let TabControl = TabControl.TabControlBuilder<TabControl>()
let TabItem = TabItem.TabItemBuilder<TabItem>()
let TreeView = TreeView.TreeViewBuilder<TreeView>()
let TreeViewItem = TreeViewItem.TreeViewItemBuilder<TreeViewItem>()
let Menu = Menu.MenuBuilder<Menu>()
let MenuItem = MenuItem.MenuItemBuilder<MenuItem>()
let ContextMenu = ContextMenu.ContextMenuBuilder<ContextMenu>()

let Slider = Slider.SliderBuilder<Slider>()
let ProgressBar = ProgressBar.ProgressBarBuilder<ProgressBar>()

let Calendar = Calendar.CalendarBuilder<Calendar>()
let CalendarInput = CalendarDatePicker.CalendarDatePickerBuilder<CalendarDatePicker>()

let DateInput = DatePicker.DatePickerBuilder<DatePicker>()
let TimeInput = TimePicker.TimePickerBuilder<TimePicker>()
let TickBar = TickBar.TickBarBuilder<TickBar>()
let AutoComplete = AutoCompleteBox.AutoCompleteBoxBuilder<AutoCompleteBox>()
let Button = Button.ButtonBuilder<Button>()
let ToggleButton = ToggleButton.ToggleButtonBuilder<ToggleButton>()
let Switch = ToggleSwitch.ToggleSwitchBuilder<ToggleSwitch>()
let Spinner = Spinner.SpinnerBuilder<Spinner>()
let ButtonSpinner = ButtonSpinner.ButtonSpinnerBuilder<ButtonSpinner>()
let NumberInput = NumericUpDown.NumericUpDownBuilder<NumericUpDown>()
let CheckBox = CheckBox.CheckBoxBuilder<CheckBox>()
let Image = Image.ImageBuilder<Image>()
let GridSplitter = GridSplitter.GridSplitterBuilder<GridSplitter>()
let RadioButton = RadioButton.RadioButtonBuilder<RadioButton>()
let RepeatButton = RepeatButton.RepeatButtonBuilder<RepeatButton>()
let ScrollView = ScrollViewer.ScrollViewerBuilder<ScrollViewer>()
let Separator = Separator.SeparatorBuilder<Separator>()
let SplitView = SplitView.SplitViewBuilder<SplitView>()
let Expand = Expander.ExpanderBuilder<Expander>()
let Label = TextBlock.TextBlockBuilder<TextBlock>()
let TextInput = TextBox.TextBoxBuilder<TextBox>()
let AccessText = AccessText.AccessTextBuilder<AccessText>()
let ToolTip = ToolTip.ToolTipBuilder<ToolTip>()

let Chart = Microcharts.Chart.ChartBuilder<Microcharts.ChartView.ChartView>()