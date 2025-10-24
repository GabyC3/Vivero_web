using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivero.Shared.Enum;

namespace Vivero.Shared.DTO
{
    public class CrearGestionDTO
    {

        public Accion Accion { get; set; } = Accion.Crear;
        public DateTime Fecha { get; set; } = DateTime.Now;

    }
}

