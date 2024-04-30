using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AharHighLevel.Common;
using AharHighLevel.Converters;
using AharHighLevel.ViewModel.MainModule;
using MaterialDesignThemes.Wpf;

namespace AharHighLevel.View.MainModule
{
    /// <summary>
    /// Interaction logic for OpOm.xaml
    /// </summary>
    public partial class OpOm : UserControl
    {
        public OpOm()
        {
            InitializeComponent();

            DataContext = new OpOmViewModel();
            Loaded += (sender, args) =>
            {
                var vm = DataContext as OpOmViewModel;
                if (vm == null)
                    return;
                vm.Loaded();
            };
            CreateForm();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            if (e.Text.Contains(' '))
            {
                e.Handled = false;
                return;
            }
            Regex regex = new Regex(@"^-?[0-9][0-9,\.]+$");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void BooleanValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(e.Text == "1" || e.Text == "0");
        }
        private void UG_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            var ug = sender as UniformGrid;
            if (ug == null) return;
            var width = ug.ActualWidth;
            ug.Columns = ((int)width) / 300;
        }

        private void CreateForm()
        {

            var vm = DataContext as OpOmViewModel;
            if (vm == null)
                return;
            var ItmCounter = 0;
            foreach (var itm in vm.AllParams)
            {
                if (itm is RealVariable RealItem)
                {
                    Grid grid = new Grid()
                    {
                        Margin = new Thickness(5),
                        //Width = 250
                    };
                    grid.ColumnDefinitions.Clear();
                    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(20) });
                    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
                    grid.ColumnDefinitions.Add(new ColumnDefinition());
                    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(20) });
                    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(20) });
                    var bindBackground = new Binding("AllParams[" + ItmCounter + "].Status")
                    {
                        Converter = new StatusToBrushConverter()
                    };
                    grid.SetBinding(Grid.BackgroundProperty, bindBackground);
                    // Value
                    var value = new TextBox()
                    {
                        Margin = new Thickness(5),
                        MinWidth = 100,
                        VerticalAlignment = VerticalAlignment.Center,
                        FontSize = 18,
                        Style = Application.Current.FindResource("MaterialDesignFloatingHintTextBox") as Style
                    };
                    //  => Value Binding
                    Binding bindUnit = new Binding("AllParams[" + ItmCounter + "].Unit");
                    var bindReadOnly = new Binding("AllParams[" + ItmCounter + "].ReadOnly");
                    var bindValue = new Binding("AllParams[" + ItmCounter + "].Value")
                    {
                        UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                    };
                    var bindName = new Binding("AllParams[" + ItmCounter + "].Label");
                    var bindLabel = new Binding("AllParams[" + ItmCounter + "].Label");
                    MaterialDesignThemes.Wpf.HintAssist.SetFloatingScale(value, .9);
                    value.PreviewTextInput += NumberValidationTextBox;
                    value.SetBinding(TextFieldAssist.SuffixTextProperty, bindUnit);
                    value.SetBinding(MaterialDesignThemes.Wpf.HintAssist.HintProperty, bindLabel);
                    MaterialDesignThemes.Wpf.HintAssist.SetHintOpacity(value, 1);
                    value.SetBinding(TextBox.NameProperty, bindName);
                    value.SetBinding(TextBox.TextProperty, bindValue);
                    value.SetBinding(TextBoxBase.IsReadOnlyProperty, bindReadOnly);
                    if (DataContext is IMouseEventHandler ms)
                    {
                        value.MouseEnter += ms.MouseEnterCommand;
                        value.MouseLeave += ms.MouseLeaveCommand;
                    }
                    //  => Add to Grid
                    Grid.SetColumn(value, 2);
                    grid.Children.Add(value);
                    // Invalid Mark
                    var InvalidMark = new Border()
                    {
                        Background = Application.Current.FindResource("DangerBrush") as Brush,
                        Width = 20,
                        Height = 20,
                        CornerRadius = new CornerRadius(20),
                        VerticalAlignment = VerticalAlignment.Center,
                        Child = new PackIcon()  // ICON
                        {
                            Kind = PackIconKind.ExclamationThick,
                            Width = 16,
                            Height = 16,
                            VerticalAlignment = VerticalAlignment.Center,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            Foreground = Application.Current.FindResource("WindowBackground") as Brush,
                        }
                    };
                    //  => Invalid Mark Binding
                    var bindVisibility = new Binding("AllParams[" + ItmCounter + "].HasError")
                    {
                        Converter = new Converters.BooleanToVisibilityConverter()
                    };
                    var bindTooltip = new Binding("AllParams[" + ItmCounter + "].Tooltip");
                    InvalidMark.SetBinding(Border.VisibilityProperty, bindVisibility);
                    InvalidMark.SetBinding(Border.ToolTipProperty, bindTooltip);
                    //  => Add to Grid
                    Grid.SetColumn(InvalidMark, 3);
                    grid.Children.Add(InvalidMark);

                    if (itm.FormId % 10 == 1)
                    {
                        Wrp1.Children.Add(grid);
                    }
                    else if (itm.FormId % 10 == 2)
                    {
                        Wrp2.Children.Add(grid);
                    }
                }
                else if (itm is BoolVariable)
                {
                    Grid grid = new Grid()
                    {
                        Margin = new Thickness(5),
                        //Width = 250
                    };
                    grid.ColumnDefinitions.Clear();
                    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(20) });
                    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
                    grid.ColumnDefinitions.Add(new ColumnDefinition());
                    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(20) });
                    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(20) });
                    var bindBackground = new Binding("AllParams[" + ItmCounter + "].Status")
                    {
                        Converter = new StatusToBrushConverter()
                    };
                    grid.SetBinding(Grid.BackgroundProperty, bindBackground);
                    // Value
                    var value = new TextBox()
                    {
                        Margin = new Thickness(5),
                        MinWidth = 100,
                        VerticalAlignment = VerticalAlignment.Center,
                        FontSize = 18,
                        Style = Application.Current.FindResource("MaterialDesignFloatingHintTextBox") as Style
                    };
                    //  => Value Binding
                    Binding bindUnit = new Binding("AllParams[" + ItmCounter + "].Unit");
                    var bindReadOnly = new Binding("AllParams[" + ItmCounter + "].ReadOnly");
                    var bindValue = new Binding("AllParams[" + ItmCounter + "].Value")
                    {
                        UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                        Converter = new NumberToBooleanConverter()
                    };
                    var bindName = new Binding("AllParams[" + ItmCounter + "].Label");
                    var bindLabel = new Binding("AllParams[" + ItmCounter + "].Label");
                    MaterialDesignThemes.Wpf.HintAssist.SetFloatingScale(value, .9);
                    MaterialDesignThemes.Wpf.HintAssist.SetHintOpacity(value, 1);
                    value.PreviewTextInput += BooleanValidationTextBox;
                    value.SetBinding(TextFieldAssist.SuffixTextProperty, bindUnit);
                    value.SetBinding(MaterialDesignThemes.Wpf.HintAssist.HintProperty, bindLabel);
                    value.SetBinding(TextBox.NameProperty, bindName);
                    value.SetBinding(TextBox.TextProperty, bindValue);
                    value.SetBinding(TextBoxBase.IsReadOnlyProperty, bindReadOnly);
                    if (DataContext is IMouseEventHandler ms)
                    {
                        value.MouseEnter += ms.MouseEnterCommand;
                        value.MouseLeave += ms.MouseLeaveCommand;
                    }
                    //  => Add to Grid
                    Grid.SetColumn(value, 2);
                    grid.Children.Add(value);

                    if (itm.FormId % 10 == 1)
                    {
                        Wrp1.Children.Add(grid);
                    }
                    else if (itm.FormId % 10 == 2)
                    {
                        Wrp2.Children.Add(grid);
                    }

                }
                else if (itm is EnumVariable enumItem)
                {
                    Grid grid = new Grid()
                    {
                        Margin = new Thickness(5),
                        //Width = 250
                    };
                    grid.ColumnDefinitions.Clear();
                    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(20) });
                    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
                    grid.ColumnDefinitions.Add(new ColumnDefinition());
                    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(20) });
                    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(20) });
                    var bindBackground = new Binding("AllParams[" + ItmCounter + "].Status")
                    {
                        Converter = new StatusToBrushConverter()
                    };
                    grid.SetBinding(Grid.BackgroundProperty, bindBackground);

                    // Value
                    var value = new ComboBox()
                    {
                        Margin = new Thickness(5),
                        MinWidth = 100,
                        VerticalAlignment = VerticalAlignment.Center,
                        FontSize = 18,
                        Style = Application.Current.FindResource("MyComboBox") as Style
                    };
                    //  => Value Binding
                    Binding bindUnit = new Binding("AllParams[" + ItmCounter + "].Unit");
                    var bindReadOnly = new Binding("AllParams[" + ItmCounter + "].ReadOnly")
                    {
                        
                    };
                    var bindValue = new Binding("AllParams[" + ItmCounter + "].Value")
                    {
                        UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                    };
                    var bindItems = new Binding("AllParams[" + ItmCounter + "].Items");
                    var bindName = new Binding("AllParams[" + ItmCounter + "].Label");
                    var bindLabel = new Binding("AllParams[" + ItmCounter + "].Label");
                    MaterialDesignThemes.Wpf.HintAssist.SetFloatingScale(value, .9);
                    value.PreviewTextInput += NumberValidationTextBox;
                    value.SetBinding(TextFieldAssist.SuffixTextProperty, bindUnit);
                    value.SetBinding(MaterialDesignThemes.Wpf.HintAssist.HintProperty, bindLabel);
                    MaterialDesignThemes.Wpf.HintAssist.SetHintOpacity(value, 1);
                    value.SetBinding(ComboBox.NameProperty, bindName);
                    value.SetBinding(Selector.SelectedIndexProperty, bindValue);
                    value.SetBinding(ComboBox.IsReadOnlyProperty, bindReadOnly);
                    value.SetBinding(ItemsControl.ItemsSourceProperty, bindItems);
                    if (DataContext is IMouseEventHandler ms)
                    {
                        value.MouseEnter += ms.MouseEnterCommand;
                        value.MouseLeave += ms.MouseLeaveCommand;
                    }
                    //  => Add to Grid
                    Grid.SetColumn(value, 2);
                    grid.Children.Add(value);
                    if (itm.FormId % 10 == 1)
                    {
                        Wrp1.Children.Add(grid);
                    }
                    else if (itm.FormId % 10 == 2)
                    {
                        Wrp2.Children.Add(grid);
                    }

                }
                ItmCounter++;
            }
        }

    }
}
