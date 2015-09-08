using System;
using System.Configuration;
using System.Reflection;
using System.Windows;
using System.Xml;

namespace _005Task4Admin
{
    public partial class MainWindow : Window
    {
        private const string ClientConfigPath = @"C:\Users\user\Documents\GitHub\CyberBionic\005Task4Client\bin\Debug\App.config";
        private Configuration configuration;

        public MainWindow()
        {
            InitializeComponent();

            var configMap = new ExeConfigurationFileMap
            {
                ExeConfigFilename = "App.config"
            };
            configuration = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var name = NameTextBox.Text;
            var type = TypeTextBox.Text;

            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(type))
            {
                MessageBox.Show("Enter valid values");
            }
            else
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.Load(configuration.FilePath);

                var nodeRegion = xmlDoc.CreateElement("Animal");
                nodeRegion.SetAttribute("Name", name);
                nodeRegion.SetAttribute("Type", type);

                var selectSingleNode = xmlDoc.SelectSingleNode(@"//Animals");
                if (selectSingleNode != null)
                {
                    selectSingleNode.AppendChild(nodeRegion);
                }
                    
                xmlDoc.Save(ClientConfigPath);
                ConfigurationManager.RefreshSection("Animals");

                NameTextBox.Text = String.Empty;
                TypeTextBox.Text = String.Empty;
            }
        }

        private void MenuItemClose_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
