using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Proj.FileReader;
using System;

namespace Proj.Test
{
    [TestClass]
    public class FileReaderComponentTest
    {
        [TestMethod]
        public void ReadAndAppendHelloTest()
        {
            //Bir dosya oluştur ve aç.
            //Var ise aç.
            //Kriteri isteğimize göre yapıyoruz.
            var path = @"D:\selam.txt";
            //var file = File.CreateText(path);

            //file.Write("Deneme");
            //file.Dispose();
            //var fileReaderComponent = new FileReaderComponent();
            //var deger = fileReaderComponent.ReadAndAppendHello(path);

            //Assert.AreEqual("Deneme Hello", deger);


            //€€€  MOCK OLAYI asagıdakı Stub zımbırtılarını yapmaya gerek bırakmıyor.
            var fileReaderMock = new Mock<IFileReader>();
            fileReaderMock.Setup(x => x.Exists(path)).Returns(true);
            fileReaderMock.Setup(x => x.ReadAllText(path)).Returns("Deneme");




            //var fileReaderComponent = new FileReaderComponent(new FileReaderStub());
            var fileReaderComponent = new FileReaderComponent(fileReaderMock.Object);
            
            var content = fileReaderComponent.ReadAndAppendHello(path);
            Assert.AreEqual("Deneme Hello", content);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ReadAndAppendHelloNOT()
        {
            var path = @"D:\olmayantext.txt";
            var fileReaderComponent = new FileReaderComponent(new FileReaderStubNOT());
            fileReaderComponent.ReadAndAppendHello(path);

        }
    }

    class FileReaderStub : IFileReader
    {
        public bool Exists(string path)
        {
            return true;
        }

        public string ReadAllText(string path)
        {
            return "Deneme";
        }
    }

    //--------------------------

    class FileReaderStubNOT : IFileReader
    {
        public bool Exists(string path)
        {
            return false;
        }

        public string ReadAllText(string path)
        {
            return "Deneme Ne old onemlı degıl bunun cunku arkadan exceptıon alcaz";
        }
    }
}
