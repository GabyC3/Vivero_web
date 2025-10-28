using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivero.Shared.Enum;

namespace Vivero.BD.Datos.Entity
{
    public class GestionProducto : EntityBase
    {
        public required int AdministradorId { get; set; }
        public Administrador? Administrador { get; set; }

        public required int ProductoId { get; set; }
        public Producto? Producto { get; set; }

        public Accion Accion { get; set; }
        public DateTime Fecha { get; set; }

    }
}

