﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using _005Task4Admin;

namespace _005Task4Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var configMap = new ExeConfigurationFileMap
            {
                ExeConfigFilename = "App.config"
            };
            var config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
            var animalItems = ((AnimalsSection) config.GetSection("Animals")).AnimalItems;

            foreach (AnimalElement item in animalItems)
            {
                StackPanel.Children.Add(new Label
                {
                    Content = String.Format("Name - {0} , Type -  {1}", item.Name, item.Type)
                });
            }
        }
    }
}
