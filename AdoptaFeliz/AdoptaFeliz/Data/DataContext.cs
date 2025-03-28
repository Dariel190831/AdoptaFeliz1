using AdoptaFeliz.Models;
using Microsoft.EntityFrameworkCore;


namespace AdoptaFeliz.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Registro> registro { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>().ToTable("usuarios");

            modelBuilder.Entity<Usuario>().Property(u => u.Nombre).HasColumnName("nombre");
            modelBuilder.Entity<Usuario>().Property(u => u.Correo).HasColumnName("correo");
            modelBuilder.Entity<Usuario>().Property(u => u.Contrasena).HasColumnName("contrasena");
            modelBuilder.Entity<Usuario>().Property(u => u.CreatedAt).HasColumnName("created_at");

            modelBuilder.Entity<Registro>().ToTable("registro");

            modelBuilder.Entity<Registro>().Property(r => r.Nombre).HasColumnName("nombre");
            modelBuilder.Entity<Registro>().Property(r => r.Raza).HasColumnName("raza");
            modelBuilder.Entity<Registro>().Property(r => r.Edad).HasColumnName("edad");
            modelBuilder.Entity<Registro>().Property(r => r.Categoria).HasColumnName("categoria");
            modelBuilder.Entity<Registro>().Property(r => r.CreatedAt).HasColumnName("created_at");
        }
    }
}
