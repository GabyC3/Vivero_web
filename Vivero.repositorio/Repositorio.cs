using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivero.BD.Datos;

namespace Vivero.Repositorio
{
    public class Repositorio<E> : IRepositorio<E> where E : class, IEntityBase
    {
        public readonly AppDbContext context;
        public Repositorio(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Existe(int id)
        {
            bool existe = await context.Set<E>().AnyAsync(x => x.Id == id);
            return existe;
        }

        public async Task<List<E>> Select()
        {
            return await context.Set<E>().ToListAsync();
        }
        public async Task<E?> SelectById(int id)
        {
            return await context.Set<E>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> Insert(E entidad)
        {
            try
            {
                await context.Set<E>().AddAsync(entidad);
                await context.SaveChangesAsync();
                return (entidad.Id);

            }
            catch (Exception e) { throw new Exception("Error al crear la entidad. ", e); }
        }


        public async Task<bool> Update(int id, E entidad)
        {
            if (id != entidad.Id) return false;
            bool existe = await Existe(id);
            if (!existe) return false;

            try
            {
                context.Set<E>().Update(entidad);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Error al actualizar la entidad.", e);
            }


        }
    }
}

