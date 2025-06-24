using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vivero.BD.Datos.Entity
{
    //[Index(nameof(ProductoId),Name = "Producto_IdProducto_UQ", IsUnique = true)]
    public class Producto
    {

        public required int ProductoId { get; set; }

        public byte[] Imagen { get; set; }

        [Required(ErrorMessage = "Es necesario ingresar el nombre del producto")]
        public required string Nombre { get; set; }
        public int Maceta { get; set; }

        //public string Descripcion { get; set; }

        [Required(ErrorMessage = "Es necesario ingresar un precio")]
        public required double Precio { get; set; }
        public int Stock { get; set; }
        public DateTime FechaCreacion { get; set; }

        // Relación muchos a muchos
        public ICollection<gestionProducto> gestionProductos { get; set; }
    }
}
