using System.IO.IsolatedStorage;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace _003Task4WPFIsolatedStorage
{
    public partial class MainWindow : Window
    {
        private IsolatedStorageFile isolatedStorage;

        public MainWindow()
        {
            InitializeComponent();
            isolatedStorage = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly, null, null);
            Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            isolatedStorage.Close();
            isolatedStorage.Dispose();
        }

        private void btn_add_file_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddFileWindow(isolatedStorage);
            if(window.ShowDialog() == true)
            {
                lv_files_Loaded(lv_files, null);
            }
        }

        private void btn_del_file_Click(object sender, RoutedEventArgs e)
        {
            var selectedFiles = lv_files.SelectedItems.Cast<string>().ToArray();
            foreach (var file in selectedFiles)
            {
                isolatedStorage.DeleteFile(file);
            }

            lv_files_Loaded(lv_files, null);
        }

        private void lv_files_Loaded(object sender, RoutedEventArgs e)
        {
            var listView = sender as ListView;
            listView.Items.Clear();
            foreach (var dir in isolatedStorage.GetFileNames())
            {
                listView.Items.Add(dir);
            }
        }
    }
}
