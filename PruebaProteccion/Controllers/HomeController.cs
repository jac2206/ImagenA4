using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaProteccion.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return this.View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contacto";

            return this.View();
        }
    }
}