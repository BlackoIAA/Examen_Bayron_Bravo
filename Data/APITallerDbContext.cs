using Api_Taller_Mecanicos.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Taller_Mecanicos.Data
{
    public class APITallerDbContext : DbContext
    {
        public APITallerDbContext(DbContextOptions options) : base(options)
        {
            // Constructor que toma las opciones del contexto proporcionada al instanciar el contexto
        }

        public DbSet<Mecanicos> Mecanico { get; set; }
        // DbSet que representa la entidad Mecanicos en la base de datos.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la construcción del modelo de base de datos.

            modelBuilder.Entity<Mecanicos>().ToTable("mecanicos");
            // Se especifica el nombre de la tabla en la base de datos para la entidad Mecanicos.
            // En este caso, se utiliza "mecanicos" como nombre de tabla.
        }
    }
}