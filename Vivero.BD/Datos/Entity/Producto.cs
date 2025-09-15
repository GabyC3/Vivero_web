using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vivero.BD.Datos.Entity
{
    
    public class Producto : EntityBase
    {
        public string? Imagen { get; set; }  //var imagenBytes = Convert.FromBase64String(productoDto.Imagen);

        [Required(ErrorMessage = "Es necesario ingresar el nombre del producto")]
        [MaxLength(50, ErrorMessage = "La cantidad maxima de caracteres es de {50}")]
        public required string Nombre { get; set; }
        public int Maceta { get; set; }
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "Es necesario ingresar un precio")]
        public required double Precio { get; set; }
        public int Stock { get; set; }
        public bool Activo { get; set; } = true;
        public DateTime FechaCreacion { get; set; }

    }
}
