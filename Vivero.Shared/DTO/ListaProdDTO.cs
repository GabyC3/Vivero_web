using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vivero.Shared.DTO
{
    public class ListaProdDTO
    {
        [Required(ErrorMessage = "Es necesario ingresar el id del producto")]
        public int Id { get; set; }
        public string? Imagen { get; set; }

        [Required(ErrorMessage = "Es necesario ingresar el nombre del producto")]
        [MaxLength(50, ErrorMessage = "La cantidad maxima de caracteres es de {50}")]
        public string? Nombre { get; set; }
        public int Maceta { get; set; }

        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "Es necesario ingresar un precio")]
        public double Precio { get; set; }
        public int Stock { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}

