using System;
using System.Reflection;
using System.Text;
using System.Windows;
using Microsoft.Win32;

namespace _006AdditionalTaskReflector
{
    public partial class MainWindow : Window
    {
        private Assembly _assembly;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItemOpen_OnClick(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog()
            {
                Filter = "dll Files (*.dll)|*.dll"
            };

            string filePath;
            if (dialog.ShowDialog() == true)
            {
                filePath = dialog.FileName;
            }
            else
            {
                return;
            }

            _assembly = Assembly.LoadFrom(filePath);
            StackPanel.Visibility = Visibility.Visible;

            AttrCheckBox.Checked += AttrCheckBoxOnCheckedUnchecked;
            AttrCheckBox.Unchecked += AttrCheckBoxOnCheckedUnchecked;

            PrFieldsCheckBox.Checked += AttrCheckBoxOnCheckedUnchecked;
            PrFieldsCheckBox.Unchecked += AttrCheckBoxOnCheckedUnchecked;

            PbFieldsCheckBox.Checked += AttrCheckBoxOnCheckedUnchecked;
            PbFieldsCheckBox.Unchecked += AttrCheckBoxOnCheckedUnchecked;

            PropCheckBox.Checked += AttrCheckBoxOnCheckedUnchecked;
            PropCheckBox.Unchecked += AttrCheckBoxOnCheckedUnchecked;

            MethodsCheckBox.Checked += AttrCheckBoxOnCheckedUnchecked;
            MethodsCheckBox.Unchecked += AttrCheckBoxOnCheckedUnchecked;
        }

        private void AttrCheckBoxOnCheckedUnchecked(object sender, RoutedEventArgs routedEventArgs)
        {
            var assemblyInfo = new StringBuilder();

            foreach (var type in _assembly.GetTypes())
            {
                if (type.IsEnum)
                {
                    assemblyInfo.AppendFormat("Enum : {0}\n", type.Name);
                    foreach (var enumValue in Enum.GetValues(type))
                    {
                        assemblyInfo.AppendLine(enumValue.ToString());
                    }
                }

                if (type.IsClass)
                {
                    if (AttrCheckBox.IsChecked == true)
                    {
                        assemblyInfo.Append(Utils.GetAttributes(type));
                    }

                    assemblyInfo.AppendLine(Utils.GetClass(type));
                    
                    if (PrFieldsCheckBox.IsChecked == true)
                    {
                        assemblyInfo.AppendLine("Private Fields : ");
                        assemblyInfo.Append(Utils.GetPrivateFields(type));
                    }

                    if (PbFieldsCheckBox.IsChecked == true)
                    {
                        assemblyInfo.AppendLine("Public Fields : ");
                        assemblyInfo.Append(Utils.GetPublicFields(type));
                    }

                    if (PropCheckBox.IsChecked == true)
                    {
                        assemblyInfo.AppendLine("Properties : ");
                        assemblyInfo.Append(Utils.GetProperties(type));
                    }

                    if (MethodsCheckBox.IsChecked == true)
                    {
                        assemblyInfo.AppendLine("Methods : ");
                        assemblyInfo.Append(Utils.GetMethods(type));
                    }
                }
            }

            TextBlock.Text = assemblyInfo.ToString();
        }

        private void MenuItemClose_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
