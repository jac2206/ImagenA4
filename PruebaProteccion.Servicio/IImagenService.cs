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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IImagenService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IImagenService
    {
        [OperationContract]
        MemoryStream ImagenA4(byte[] files);
    }
}
