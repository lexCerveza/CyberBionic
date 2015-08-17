using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Windows;

namespace _003Task4WPFIsolatedStorage
{
    public partial class AddFileWindow : Window
    {
        private static IsolatedStorageFile _isolatedStorage;

        public AddFileWindow(IsolatedStorageFile isolatedStorageFile)
        {
            _isolatedStorage = isolatedStorageFile;
            InitializeComponent();
        }

        private void BtnCreate_OnClick(object sender, RoutedEventArgs e)
        {
            if (TbFileName.Text == String.Empty)
            {
                MessageBox.Show("File name is empty");
            }
            else
            {
                using (var isolatedStorageFileStream = new IsolatedStorageFileStream(TbFileName.Text, FileMode.Create, _isolatedStorage))
                {
                    using (var writer = new StreamWriter(isolatedStorageFileStream))
                    {
                        writer.Write(TbFileContents.Text);
                        writer.Close();
                    }
                }

                DialogResult = true;
                Close();
            }
        }
    }
}
