using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Windows.Forms;
using System.IO;
using PruebaProteccion.Logic;

namespace PruebaProteccion.Controllers
{
    public class ImagenController : Controller
    {

        
        // GET: Imagen
        public ActionResult Index()
        {
            return View();
        }


        //public ActionResult SubirArchivo()
        //{
        //    return View();
        //}

        //[HttpPost]
        // public ActionResult Index(HttpPostedFileBase file)
        // {
        //     if(file != null)
        //     {
        //         string ruta = Server.MapPath("~/Temp/");
        //         ruta += file.FileName;
        //         file.SaveAs(ruta);
        //     }
        //     return View();
        // }


        [AcceptVerbs(HttpVerbs.Post)]
        //[HttpPost]
        public ActionResult GuardarPDF(HttpPostedFileBase files, float ancho, float largo)
        //public ActionResult GuardarPDF(IEnumerable<HttpPostedFileBase> files)

        {
            try
            {

                //return File(ImageLogic.ImagenA4(files, 845, 595).ToArray(), "application/pdf");
                return File(ImageLogic.ImagenA4(files, ancho, largo).ToArray(), "application/pdf");



                //return View();


            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Imagen");
                //return new HttpStatusCodeResult(550, "Some error" + ex.Message);
            }

        }

        //[AcceptVerbs(HttpVerbs.Post)]
        ////[HttpPost]
        //public ActionResult GuardarPDF(IEnumerable<HttpPostedFileBase> files)
        ////public ActionResult GuardarPDF(IEnumerable<HttpPostedFileBase> files)

        //{
        //    try
        //    {

        //        foreach (var file in files)
        //        {
        //             File(ImageLogic.ImagenA4(file).ToArray(), "application/pdf", file.FileName + ".pdf");
        //        }


        //        return View();


        //    }
        //    catch (Exception ex)
        //    {
        //        return new HttpStatusCodeResult(550, "Some error" + ex.Message);
        //    }

        //}

        //public ActionResult Async_Save(IEnumerable<HttpPostedFileBase> files)
        //{
        //    // The Name of the Upload component is "files"
        //    if (files != null)
        //    {
        //        foreach (var file in files)
        //        {
        //            // Some browsers send file names with full path.
        //            // We are only interested in the file name.
        //            var fileName = Path.GetFileName(file.FileName);
        //            var physicalPath = Path.Combine(Server.MapPath("~/App_Data"), fileName);

        //            // The files are not actually saved in this demo
        //            // file.SaveAs(physicalPath);
        //        }
        //    }

        //    // Return an empty string to signify success
        //    return Content("");
        //}




    }
}