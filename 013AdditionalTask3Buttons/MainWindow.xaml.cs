using System;
using System.Threading;
using System.Windows;

namespace _013AdditionalTask3Buttons
{
    public partial class MainWindow : Window
    {
        private readonly Func<int, int, int> _addDelegate;
        private const int X = 1;
        private const int Y = 1;

        public MainWindow()
        {
            InitializeComponent();
            _addDelegate = ((x, y) => x + y);
        }


        private void CompleteOnClick(object sender, RoutedEventArgs e)
        {
            var asyncResult = _addDelegate.BeginInvoke(X, Y, null, _addDelegate);

            while (!asyncResult.IsCompleted)
            {
                Thread.Sleep(1);
            }
            MessageBox.Show("Result - " + _addDelegate.EndInvoke(asyncResult));
        }

        private void EndOnClick(object sender, RoutedEventArgs e)
        {
            var asyncResult = _addDelegate.BeginInvoke(X, Y, null, _addDelegate);

            var result = _addDelegate.EndInvoke(asyncResult);
            MessageBox.Show("Result - " + result);
        }

        private void CallBackOnClick(object sender, RoutedEventArgs e)
        {
            _addDelegate.BeginInvoke(X, Y,
                                       (asyncResult) =>
                                       {
                                           var asyncState = asyncResult.AsyncState as Func<int, int, int>;
                                           if (asyncState != null)
                                           {
                                               var result = asyncState.EndInvoke(asyncResult);
                                               MessageBox.Show("Result - " + result);
                                           }
                                       }
                                       , _addDelegate);
        }
    }
}
