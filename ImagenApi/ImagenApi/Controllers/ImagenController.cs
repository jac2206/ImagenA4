using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ImagenApi.Common;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using ImagenApi.Logic;

namespace ImagenApi.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ImagenController : ControllerBase
    {

        [Route("api/Imagen/ObtenerImagen")]
        [HttpPost]
        public IActionResult CargarProductosBodega([FromForm] IFormFile files)
        {
            try
            {


                ImagenA4Logic.CrearPDFA4(files);

                //return this.File(ImagenA4Logic.CrearPDFA4(files).ToArray(), "application/pdf", "EjemploPDF.pdf");

                return Ok();
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }


        [Route("api/Imagen/ObtenerImagenLista")]
        [HttpPost]
        public IActionResult CargarProductosBodega([FromForm] List<IFormFile> filesList)
        {
            try
            {         
                if (filesList.Count > 0)
                {
                    foreach (var files in filesList)
                    {
                        ImagenA4Logic.CrearPDFA4(files);

                    }
                }

               
                return Ok();
                //return (context.CargarProductoBodega(productoBodega));
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //return (ex.ToString());

            }
        }


    }
}