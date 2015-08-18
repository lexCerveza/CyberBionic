using System;
using System.Linq;
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

            var filePath = String.Empty;
            if (dialog.ShowDialog() == true)
            {
                filePath = dialog.FileName;
            }
            else
            {
                return;
            }

            _assembly = Assembly.LoadFrom(filePath);

            var info = new StringBuilder();
            info.AppendFormat("Assembly : {0}.\n", filePath);

            foreach (var type in _assembly.GetTypes())
            {
                if (type.IsEnum)
                {
                    info.AppendFormat("Enum : {0}\n", type.Name);
                    foreach (var enumValue in Enum.GetValues(type))
                    {
                        info.AppendLine(enumValue.ToString());
                    }
                }

                if (type.IsClass)
                {
                    info.AppendFormat("Class : {0}\n", type.Name);
                    info.AppendLine("Methods : ");
                    foreach (var methodInfo in type.GetMethods())
                    {
                        var returnType = methodInfo.GetBaseDefinition().ReturnType.Name;
                        info.AppendFormat("public {0} {1} (", returnType, methodInfo.GetBaseDefinition().Name);
                        foreach (var param in methodInfo.GetParameters())
                        {
                            info.AppendFormat("{0} {1}", param.ParameterType.Name, param.Name);
                            if (param != methodInfo.GetParameters().Last())
                            {
                                info.Append(", ");
                            }
                        }
                        info.AppendFormat(");\n");
                    }
                }
            }

            TextBox.Text = info.ToString();
        }

        private void MenuItemClose_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
