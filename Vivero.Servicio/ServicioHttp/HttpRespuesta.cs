using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Vivero.Servicio.ServicioHttp
{
    public class HttpRespuesta<T>
    {
        public T? Respuesta { get; }
        public bool Error { get; }
        public HttpResponseMessage HttpResponseMessage { get; set; }

        public HttpRespuesta(T? respuesta, bool error, HttpResponseMessage httpResponseMessage)
        {   
            Respuesta = respuesta;
            Error = error;
            HttpResponseMessage = httpResponseMessage;
        }
        public string ObtenerError()
        {
            if (!Error){
                return string.Empty;
            } else {
                var statuscode = HttpResponseMessage.StatusCode;
                switch (statuscode)
                {
                    case HttpStatusCode.NotFound:
                        return "Recurso no encontrado";
                    case HttpStatusCode.Unauthorized:
                        return "No esta logueado";
                    case HttpStatusCode.Forbidden:
                        return "No tiene autorizacion para ejecutar el proceso";
                    case HttpStatusCode.InternalServerError:
                        return "No se pudo procesar la informacion";
                    default:
                        return $"Error en la llamada HTTP.Codigo de estado: { statuscode} ";
                }
            }
        }

    }
}
