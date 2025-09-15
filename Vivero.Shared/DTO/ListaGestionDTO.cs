using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivero.Shared.Enum;

namespace Vivero.Shared.DTO
{
    public class ListaGestionDTO
    {
        [Required(ErrorMessage = "Es necesario ingresar el id del administrador")]
        public int Id { get; set; }
        public int AdministradorId { get; set; }
        public int ProductoId { get; set; }

        public Accion Accion { get; set; }
        public DateTime Fecha { get; set; }
    }
}
