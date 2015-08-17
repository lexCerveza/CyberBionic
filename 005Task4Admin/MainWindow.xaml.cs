using System;
using System.Windows;
using System.Xml;

namespace _005Task4Admin
{
    public partial class MainWindow : Window
    {
        private const string ClientConfigPath = @"C:\Users\user\Documents\Visual Studio 2013\Projects\CyberBionic-master\005Task4Client\App.config";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            int buttonNumber;
            if (!int.TryParse(ButtonNumberTextBox.Text, out buttonNumber))
            {
                MessageBox.Show("Invalid value of number of buttons");
            }
            else
            {
                var xmlConfig = new XmlDocument();
                xmlConfig.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

                var buttonCountElementAttr = (XmlAttribute)xmlConfig.SelectSingleNode("//configuration/appSettings/add[1]/@value");
                if (buttonCountElementAttr != null)
                {
                    buttonCountElementAttr.Value = buttonNumber.ToString();
                }

                var textElementAttr = (XmlAttribute)xmlConfig.SelectSingleNode("//configuration/appSettings/add[2]/@value");
                if (textElementAttr != null)
                {
                    textElementAttr.Value = TextTextBox.Text;
                }

                xmlConfig.Save(ClientConfigPath);
                Close();
            }
        }
    }
}
