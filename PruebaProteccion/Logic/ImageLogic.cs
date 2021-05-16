using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PruebaProteccion.Logic
{
    public class ImageLogic
    {

        public static MemoryStream ImagenA4(HttpPostedFileBase files, float ancho, float largo)
        {
            byte[] data;
            using (Stream inputStream = files.InputStream)
            {
                MemoryStream memoryStream = inputStream as MemoryStream;
                if (memoryStream == null)
                {
                    memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                }
                data = memoryStream.ToArray();
            }

            //Document doc = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            Document doc = new Document(new Rectangle(ancho, largo), 0f, 0f, 0f, 0f);


            //var tamañaPagina = doc.PageSize;

            iTextSharp.text.Image imagen1 = iTextSharp.text.Image.GetInstance(data);


            if (imagen1.Width > imagen1.Height)
            {
                //doc.SetPageSize(PageSize.A4.Rotate());
                doc.SetPageSize(new Rectangle(ancho, largo).Rotate());

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


    }
}