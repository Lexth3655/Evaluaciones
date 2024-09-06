using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Parcial_1.Models
{
    public partial class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Roles> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Marca>(entity => entity.ToTable("Marcas"));
            modelBuilder.Entity<Vehiculo>(entity => entity.ToTable("Vehiculos"));
            modelBuilder.Entity<Venta>(entity => entity.ToTable("Ventas"));
            modelBuilder.Entity<Usuario>(entity => entity.ToTable("Usuarios"));
            modelBuilder.Entity<Roles>(entity => entity.ToTable("Roles"));
        }
    }
}
