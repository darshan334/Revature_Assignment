using System;
using System.IO;

namespace Day5
{
    public class FileManager : IDisposable
    {
        private FileStream? _fileStream;
        private bool _disposed = false;

        public void OpenFile(string path)
        {
            _fileStream = new FileStream(path, FileMode.OpenOrCreate);
            Console.WriteLine("File opened");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                _fileStream?.Dispose();
                Console.WriteLine("File disposed");
            }

            _disposed = true;
        }

        ~FileManager()
        {
            Dispose(false);
        }
    }
}
