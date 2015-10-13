using System;
using System.Collections.Generic;
using System.Linq;

namespace _009AdditionalTaskDisposePattern
{
    class DisposedClass : IDisposable
    {
        private bool _disposed;
        private List<object> _objectList = new List<object>(1000000).Select(i => new object()).ToList(); 

        ~DisposedClass() { }

        private void CleanUp(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                // Managed resources clean up
                _objectList.Clear();
                _objectList = null;
            }

            // Unmanaged resources clean up

            // Disposed flag turn to true
            _disposed = true;
        }

        public void Dispose()
        {
            CleanUp(true);
            GC.SuppressFinalize(this);
        }
    }
    class Program
    {
        static void Main()
        {
            using (var disposedClass = new DisposedClass())
            {
                Console.WriteLine("Dipose method will be called in the end of this block");
            }

            Console.WriteLine("Dispose() called");
        }
    }
}
