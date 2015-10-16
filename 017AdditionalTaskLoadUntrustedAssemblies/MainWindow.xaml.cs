using System;
using System.Reflection;
using System.Security;
using System.Security.Permissions;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace _017AdditionalTaskLoadUntrustedAssemblies
{
    public partial class MainWindow : Window
    {
        private const string Path = @"";
        private const string Filter = @"(*.exe)|*.exe|(*.dll)|*.dll";

        private PermissionState _state;

        public MainWindow()
        {
            InitializeComponent();

            ExitMenuItem.Click += (sender, args) =>
            {
                Close();
            };

            AssemblyChooseButton.Click += (sender, args) =>
            {
                _state = (((ComboBoxItem) ComboBox.SelectedValue).Content.ToString() == "None") ? 
                      PermissionState.None
                    : PermissionState.Unrestricted;

                var openFileDialog = new OpenFileDialog
                {
                    InitialDirectory = Path,
                    Filter = Filter
                };

                if (openFileDialog.ShowDialog() == true)
                {
                    var asmPath = openFileDialog.SafeFileName.Split('.')[0];

                    var newDomain = AppDomain.CreateDomain(asmPath);
                    var permissionSet = new PermissionSet(_state);
                    permissionSet.AddPermission(new SecurityPermission(SecurityPermissionFlag.AllFlags));

                    newDomain.Load(new AssemblyName(asmPath));

                    MessageBox.Show(string.Format("{0} loaded", asmPath));
                }
            };
        }
    }
}
