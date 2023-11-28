using Clase7.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clase7.Repository
{
    public class DatabaseContext : DbContext
    {
       
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(stringConnection);

        //    base.OnConfiguring(optionsBuilder);
        //}


        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Persona> Persona { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>(entity => 
            {
                entity.ToTable("Personas");

                entity.Property(p => p.Nombre)
                       .HasColumnName("nombre_persona");

                entity.Property(p => p.Domicilio)
                      .HasColumnName("domicilio_persona");
            
            });


            base.OnModelCreating(modelBuilder);
        }

    }
}
