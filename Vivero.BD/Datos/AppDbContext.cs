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
        public DbSet<AdminProducto> AdminProductos { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AdminProducto>()
            .HasKey(x => new { x.IdAdministrador, x.IdProducto });

            modelBuilder.Entity<AdminProducto>()
                .HasOne(x => x.Administrador)
              .WithMany(a => a.AdminProductos)
              .HasForeignKey(b => b.IdAdministrador);

            modelBuilder.Entity<AdminProducto>()
              .HasOne(x => x.Producto)
              .WithMany(a => a.AdminProductos)
              .HasForeignKey(b => b.IdProducto);
        }
    }
}
