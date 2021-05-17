﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ionic.Zip;
using iTextSharp.text;
using iTextSharp.text.pdf;
using PruebaProteccion.Logic;

namespace PruebaProteccion.Controllers
{
    public class ImagenController : Controller
    {

        
        // GET: Imagen
        public ActionResult Index()
        {
            return this.View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult GuardarPDF(HttpPostedFileBase files, float ancho, float largo)

        {
            try
            {

                //Response.ContentType = "\".pdf\",\"application/pdf\"";
                //Response.AddHeader("Content-disposition", "attachment; filename=documento.pdf");
                //Response.BinaryWrite(ImageLogic.ImagenA4(files, ancho, largo).ToArray());
                //Response.Flush();
                //Response.End();

                return this.File(ImageLogic.ImagenA4(files, ancho, largo).ToArray(), "application/pdf");

                //return this.RedirectToAction("Index", "Imagen");

            }
            catch 
            {
                return this.RedirectToAction("Index", "Imagen");
            }

        }

      



    }
}