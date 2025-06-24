using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vivero.BD.Datos.Entity
{
    //[Index(nameof(AdministradorId),Name = "Administrador_IdAdministrador_UQ", IsUnique = true)]
    public class Administrador
    {

        public required int AdministradorId { get; set; }

        [Required(ErrorMessage = "Es necesario ingresar un nombre")]
        public required string Nombre { get; set; }

        [Required(ErrorMessage = "Es necesario ingresar una contraseña")]
        public required string Contraseña { get; set; }
        public DateTime FechaRegistro { get; set; }

        // Relación muchos a muchos
        public ICollection<gestionProducto> gestionProductos { get; set; }
    }
}
