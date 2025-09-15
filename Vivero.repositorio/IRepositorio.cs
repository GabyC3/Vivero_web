using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivero.BD.Datos;
using Vivero.Shared.DTO;

namespace Vivero.Repositorio
{
    public interface IRepositorio<E> where E : class, IEntityBase
    {
        Task<List<E>> Select();
        Task<int> Insert(E entidad);
        Task<E?> SelectById(int id);
        Task<bool> Update(int id, E entidad);

    }
}
