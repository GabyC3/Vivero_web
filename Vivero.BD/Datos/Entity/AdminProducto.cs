using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vivero.BD.Datos.Entity
{
    public class gestionProducto
    {
        public  int IdAdministrador { get; set; }
        public  Administrador Administrador  { get; set; }

        public int IdProducto { get; set; }
        public  Producto Producto { get; set; }

        public DateTime FechaAsignacion { get; set; }
        
    }
}
