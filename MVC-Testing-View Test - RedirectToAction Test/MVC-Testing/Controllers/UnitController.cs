using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Testing.Controllers
{
    public class UnitController : Controller
    {
        // GET: Unit
        //Bunun parametresine 4 koyduğumuzda View1 adlı view gelmeli ve 0 koyduğumuzda View0 gelmeli gerçekten öyle mi diye test yapalım

        public ActionResult MetodIsmim(int id)
        {
            return id == 0 ? View("View0") : View("View1");
        }

        //ViewData sı gerçekten böyle mi diye bakıyoruz Test ile arkada.
        public ActionResult ViewDataOzelligi()
        {
            ViewData["isim"] = "baki";
            return View();
        }

        //Bu metodda mantık arama !.
        public ActionResult Details(int id)
        {
            if (id<0)
            {
                return RedirectToAction("Salla", "Unit");
            }
            else
            {
                return View("Details");
            }
        }
    }
}