using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC_Testing.Controllers;
using System.Web.Mvc;

namespace MVC_Testing.Tests
{
    [TestClass]
    public class UnitControllerTest
    {
        [TestMethod]
        public void TesForViewZero()
        {
            //UnitControllerdaki MetodIsmim metodu parametresi 0 ise 'View0' a  değil ise View1 ' e gitmesi gerek.
            UnitController cont = new UnitController();
            //Burada 0 a goturup ViewResult değişkenine atadık.
            ViewResult r = (ViewResult)cont.MetodIsmim(0);
            Assert.AreEqual("View0", r.ViewName);

        }

        [TestMethod]
        public void TestForViewOther()
        {
            UnitController cont = new UnitController();
            ViewResult sa = (ViewResult)cont.MetodIsmim(4);
            Assert.AreEqual("View1", sa.ViewName);
        }

        //Bir controllerin içindeki ViewData ozelligini Test Etmek.
        [TestMethod]
        public void TestForViewData()
        {
            UnitController cont = new UnitController();
            //**********
            ViewResult vr = (ViewResult)cont.ViewDataOzelligi();

            Assert.AreEqual("baki", vr.ViewData["isim"]);

        }

        //------------

        [TestMethod]
        public void TestForRedirect()
        {
            UnitController cont = new UnitController();
            var result =(RedirectToRouteResult) cont.Details(-1);
            //UnitControllerindaki Details metoduna -1 degeri verildiğinde 
            //Unit>Salla yoluna gitmesi gerek.
            //Bende bunu kontrol edıcem buara.
            Assert.AreEqual("Salla", result.RouteValues["action"]);
            Assert.AreEqual("Unit", result.RouteValues["controller"]);

        }
        //RedirectToRouteResult ile cont ve action ozelliklerini alabılıyoruz bır yolun.Bunu dictionary ile alıyoruz.
    }
}
