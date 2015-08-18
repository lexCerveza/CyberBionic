using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace _003Task3TextWindowFileViewerAndCompression
{
    public partial class MainWindow : Window
    {
        private readonly List<string> _filePathList;

        public MainWindow()
        {
            _filePathList = new List<string>();
            GetFile(@"C:\Users\" + Environment.UserName + @"\Documents", @"*the_shining.txt");
            InitializeComponent();
        }

        private void FrameworkElement_OnLoaded(object sender, RoutedEventArgs e)
        {
            var block = sender as TextBlock;
            if (block != null)
                block.Text = ReadFileFromStream(_filePathList[0]);
        }

        public void GetFile(string root, string filePattern)
        {
            foreach (var dir in Directory.GetDirectories(root))
            {
                try
                {
                    foreach (var file in Directory.GetFiles(dir, filePattern))
                    {
                        _filePathList.Add(file);
                    }

                    GetFile(dir, filePattern);
                }
                catch (UnauthorizedAccessException exception) { }
            }
        }

        public string ReadFileFromStream(string filePath)
        {
            byte[] buf;
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                var length = (int) fileStream.Length;  
                buf = new byte[length];
                int count;
                var sum = 0;                          

                while ((count = fileStream.Read(buf, sum, length - sum)) > 0)
                    sum += count;  
            }
            finally
            {
                fileStream.Close();
            }
            return Encoding.UTF8.GetString(buf);
        }

        public void CompressFile(string filePath)
        {
            var sourceFile = File.Open(filePath, FileMode.Open);
            var compressedFile = File.Create(String.Format("{0}.zip", sourceFile));

            var gZipStream = new GZipStream(compressedFile, CompressionMode.Compress);

            var b = sourceFile.ReadByte();
            while (b != -1)
            {
                gZipStream.WriteByte((byte) b);
                b = sourceFile.ReadByte();
            }

            gZipStream.Close();

            sourceFile.Close();
            compressedFile.Close();
        }
    }
}
