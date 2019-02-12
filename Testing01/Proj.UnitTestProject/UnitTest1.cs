using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proj.MathLibrary;

namespace Proj.UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Math_Ekle()
        {
            var result = MathIslemleri.Ekle(3, 4);
            Assert.AreEqual<int>(7, result);
        }
    }
}
