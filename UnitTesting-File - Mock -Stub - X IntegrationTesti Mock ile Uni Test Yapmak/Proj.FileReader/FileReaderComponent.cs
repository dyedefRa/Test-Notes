using System;
using System.IO;

namespace Proj.FileReader
{
    public class FileReaderComponent
    {
        private readonly IFileReader _fileReader;

        public FileReaderComponent(IFileReader fileReader)
        {
            this._fileReader = fileReader;
        }

        public string ReadAndAppendHello(string yol)
        {
            if (_fileReader.Exists(yol))
            {
                var sonuc = _fileReader.ReadAllText(yol);
                return sonuc + " Hello";
                //Verilen yoldaki textin içini oku ve sonunda  Hello ekle.

            }
            throw new ArgumentException($"{nameof(yol)} is invalid.");
        }
    }

    public interface IFileReader
    {
        bool Exists(string path);
        string ReadAllText(string path);
    }
    public class FileReader : IFileReader
    {
        public bool Exists(string path)
        {
            return File.Exists(path);
        }

        public string ReadAllText(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
