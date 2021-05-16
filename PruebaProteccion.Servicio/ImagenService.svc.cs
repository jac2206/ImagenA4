using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;

namespace PruebaProteccion.Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ImagenService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ImagenService.svc o ImagenService.svc.cs en el Explorador de soluciones e inicie la depuración.

    [Serializable]
    [DataContract]
    
    public class ImagenService : IImagenService
    {

       

        public MemoryStream ImagenA4(byte[] files)
        {
            try
            {
               

                Document doc = new Document(PageSize.A4, 0f, 0f, 0f, 0f);

                var tamañaPagina = doc.PageSize;

                iTextSharp.text.Image imagen1 = iTextSharp.text.Image.GetInstance(files);


                if (imagen1.Width > imagen1.Height)
                {
                    doc.SetPageSize(PageSize.A4.Rotate());
                }
                if (imagen1.Width > doc.PageSize.Width)
                {
                    //float nuevoAncho = doc.PageSize.Width;
                    imagen1.ScaleAbsoluteWidth(doc.PageSize.Width);

                }
                if (imagen1.Height > doc.PageSize.Height)
                {
                    //float nuevoAlto = doc.PageSize.Height;
                    imagen1.ScaleAbsoluteHeight(doc.PageSize.Height);

                }



                MemoryStream file = new MemoryStream();
                PdfWriter writer = PdfWriter.GetInstance(doc, file);
                //writer.Open();
                doc.AddAuthor("JAC");
                doc.AddTitle("A4Imagen");
                doc.Open();

                imagen1.Alignment = Element.ALIGN_MIDDLE;
                doc.Add(imagen1);
                doc.Close();

                return file;
            }

            catch(Exception ex)
            {
                return null;
            }

        }
    }
}
