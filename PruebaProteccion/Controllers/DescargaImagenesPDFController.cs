using Ionic.Zip;
using PruebaProteccion.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaProteccion.Controllers
{
    public class DescargaImagenesPDFController : Controller
    {
        // GET: DescargaImagenesPDF
        public ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult GuardarListaPDF(IEnumerable<HttpPostedFileBase> files, float ancho, float largo)
        {
            try
            {
                ZipFile zip = new ZipFile();

                if (files.Count() > 0)
                {


                    foreach (var file in files)
                    {
                        zip.AddEntry(file.FileName.Replace(".jpg", ".pdf"), ImageLogic.ImagenA4(file, ancho, largo).ToArray());
                    }

                }
                using (MemoryStream output = new MemoryStream())
                {
                    zip.Save(output);
                    zip.Dispose();
                    return this.File(output.ToArray(), "application/zip", "ImagenesA4.zip");
                }

            }
            catch 
            {
                return this.RedirectToAction("Index", "Imagen");
            }

        }
    }
}