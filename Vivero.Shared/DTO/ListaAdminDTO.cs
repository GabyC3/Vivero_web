using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vivero.Shared.DTO
{
    public class ListaAdminDTO
    {
        [Required(ErrorMessage = "Es necesario ingresar el id del administrador")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Es necesario ingresar un nombre")]
        [MaxLength(50, ErrorMessage = "El maximo de caracteres es de 50")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Es necesario ingresar una dirección e-mail")]
        [MaxLength(50, ErrorMessage = "El maximo de caracteres es de 50")]
        public string? Email { get; set; }

        [MaxLength(15, ErrorMessage = "El maximo de caracteres es de 15")]
        public string? Telefono { get; set; }

        [Required(ErrorMessage = "Se necesita ingresar una contraseña")]
        public string? Contraseña { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}

