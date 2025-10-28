using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vivero.Servicio.ServicioHttp
{
    public interface IHttpServicio
    {
        Task<HttpRespuesta<T>> Get<T>(string url);

        Task<HttpRespuesta<TResp>> Post<T, TResp>(string url, T entidad);

        Task<HttpRespuesta<TResp>> Put<T, TResp>(string url, T entidad);

        Task<T?> DesSerializar<T>(HttpResponseMessage response);

        Task<HttpRespuesta<object>> Delete(string url);
    }
}
