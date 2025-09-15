using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vivero.BD.Datos
{
    public class EntityBase : IEntityBase
    {
        [Required(ErrorMessage = "Es necesario ingresar el id del producto")]
        public required int Id { get; set; }
    
    }
}
