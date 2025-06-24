using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivero.BD.Datos.Entity;

namespace Vivero.BD.Datos
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<gestionProducto> gestionProductos { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<gestionProducto>()
            .HasKey(x => new { x.IdAdministrador, x.IdProducto });

            modelBuilder.Entity<gestionProducto>()
                .HasOne(x => x.Administrador)
              .WithMany(a => a.gestionProductos)
              .HasForeignKey(b => b.IdAdministrador);

            modelBuilder.Entity<gestionProducto>()
              .HasOne(x => x.Producto)
              .WithMany(a => a.gestionProductos)
              .HasForeignKey(b => b.IdProducto);
        }
    }
}
