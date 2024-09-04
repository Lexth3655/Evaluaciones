using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Parcial_1.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Empleado> Empleados { get; set; }

        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tipo_Empleado> TipoEmpleados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Empleado>(entity => entity.ToTable("Empleados"));
            modelBuilder.Entity<Tipo_Empleado>(entity => entity.ToTable("TipoEmpleado"));
            modelBuilder.Entity<Marca>(entity => entity.ToTable("Marcas"));
            modelBuilder.Entity<Vehiculo>(entity => entity.ToTable("Vehiculos"));
            modelBuilder.Entity<Venta>(entity => entity.ToTable("Ventas"));
            modelBuilder.Entity<Usuario>(entity => entity.ToTable("Usuarios"));
        }
    }
}
