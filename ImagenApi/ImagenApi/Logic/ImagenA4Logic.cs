using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ImagenApi.Logic
{
    public class ImagenA4Logic
    {

        public static MemoryStream CrearPDFA4(IFormFile files)
        {

            //string usuario = Environment.UserName;
            //string usuario = System.Security.Principal.WindowsIdentity.GetCurrent().Name; 

            string ruta = @"C:\ArchivosA4";

            if (!Directory.Exists(ruta))
            {
                DirectoryInfo di = Directory.CreateDirectory(ruta);
            }

            Document doc = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            byte[] data;
            using (var ms = new MemoryStream())
            {
                files.CopyTo(ms);
                data = ms.ToArray();
                //string s = Convert.ToBase64String(fileBytes);
                // act on the Base64 data
            }

            iTextSharp.text.Image imagen1 = iTextSharp.text.Image.GetInstance(data);
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
            doc.AddAuthor("JAC");
            doc.AddTitle("A4Imagen");
            doc.Open();

            imagen1.Alignment = Element.ALIGN_MIDDLE;
            doc.Add(imagen1);
            doc.Close();
            return file;

            //FileStream file = new FileStream(ruta + "//" +files.FileName + ".pdf", FileMode.Create);
            //PdfWriter writer = PdfWriter.GetInstance(doc, file);
            ////writer.Open();
            //doc.AddAuthor("CodeStack");
            //doc.AddTitle("Hola mundo");
            //doc.Open();

            //imagen1.Alignment = Element.ALIGN_MIDDLE;

            //doc.Add(imagen1);

            ////doc.Add(new Phrase("Pepito"));
            ////writer.Close();
            //doc.Close();
        }

    }
}
