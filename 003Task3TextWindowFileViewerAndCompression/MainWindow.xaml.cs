using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace _003Task3TextWindowFileViewerAndCompression
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string FilePath = @"C:\Users\user\Documents\Visual Studio 2013\Projects\001AdditionalTaskYield\003Task2FileCreateRead\";
        private const string FileName = "the_shining.txt";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void FrameworkElement_OnLoaded(object sender, RoutedEventArgs e)
        {
            var block = sender as TextBlock;
            if (block != null) 
                block.Text = FileContents(FilePath);
        }

        private static string FileContents(string filePath)
        {
            var fileNames = Directory.GetFiles(filePath, FileName, SearchOption.AllDirectories);
            foreach (var fileName in fileNames)
            {
                return File.ReadAllText(fileName);
            }

            return null;
        }
    }
}
