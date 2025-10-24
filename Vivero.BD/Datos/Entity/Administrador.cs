using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vivero.BD.Datos.Entity
{
    [Index(nameof(Email), Name = "Usuario_Email_UQ", IsUnique = true)]
    public class Administrador : EntityBase
    {

        [Required(ErrorMessage = "Es necesario ingresar un nombre")]
        [MaxLength(50, ErrorMessage = "El maximo de caracteres es de {50}")]
        public required string Nombre { get; set; }

        [Required(ErrorMessage = "Es necesario ingresar una dirección e-mail")]
        [MaxLength(50, ErrorMessage = "El maximo de caracteres es de {50}")]
        public required string Email { get; set; }

        [MaxLength(15, ErrorMessage = "El maximo de caracteres es de {15}")]
        public string? Telefono { get; set; }

        [Required(ErrorMessage = "Se necesita ingresar una contraseña")]
        public required string Contraseña { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;


    }
}

