using Microsoft.EntityFrameworkCore;
using PlantasOrnamentales.Domain.Entities;

namespace PlantasOrnamentales.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Categoria> Categorias => Set<Categoria>();
        public DbSet<Planta> Plantas => Set<Planta>();
        public DbSet<Cuidados> Cuidados => Set<Cuidados>();
        public DbSet<CalendarioSiembra> Calendarios => Set<CalendarioSiembra>();
        public DbSet<Plaga> Plagas => Set<Plaga>();
        public DbSet<ClimaRecomendado> Climas => Set<ClimaRecomendado>();
        public DbSet<Uso> Usos => Set<Uso>();
        public DbSet<FotoPlanta> FotosPlantas => Set<FotoPlanta>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 🔹 Nombres exactos de las tablas
            modelBuilder.Entity<Categoria>().ToTable("Categoria");
            modelBuilder.Entity<Planta>().ToTable("Planta");
            modelBuilder.Entity<Cuidados>().ToTable("Cuidados");
            modelBuilder.Entity<CalendarioSiembra>().ToTable("CalendarioSiembra");
            modelBuilder.Entity<Plaga>().ToTable("Plagas");
            modelBuilder.Entity<ClimaRecomendado>().ToTable("ClimaRecomendado");
            modelBuilder.Entity<Uso>().ToTable("Usos");
            modelBuilder.Entity<FotoPlanta>().ToTable("FotosPlantas");

            // 🔹 Relación 1–N: Categoria -> Plantas
            modelBuilder.Entity<Planta>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Plantas)
                .HasForeignKey(p => p.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict);

            // 🔹 Relación 1–1: Planta -> Cuidados
            modelBuilder.Entity<Cuidados>()
                .HasIndex(c => c.PlantaId) // índice único
                .IsUnique();

            modelBuilder.Entity<Cuidados>()
                .HasOne(c => c.Planta)
                .WithOne(p => p.Cuidados)
                .HasForeignKey<Cuidados>(c => c.PlantaId)
                .OnDelete(DeleteBehavior.Cascade);

            // 🔹 Relación 1–N: Planta -> CalendarioSiembra
            modelBuilder.Entity<CalendarioSiembra>()
                .HasOne(c => c.Planta)
                .WithMany(p => p.Calendario)
                .HasForeignKey(c => c.PlantaId)
                .OnDelete(DeleteBehavior.Cascade);

            // 🔹 Relación 1–N: Planta -> Plagas
            modelBuilder.Entity<Plaga>()
                .HasOne(pl => pl.Planta)
                .WithMany(p => p.Plagas)
                .HasForeignKey(pl => pl.PlantaId)
                .OnDelete(DeleteBehavior.Cascade);

            // 🔹 Relación 1–N: Planta -> Climas
            modelBuilder.Entity<ClimaRecomendado>()
                .HasOne(cl => cl.Planta)
                .WithMany(p => p.Climas)
                .HasForeignKey(cl => cl.PlantaId)
                .OnDelete(DeleteBehavior.Cascade);

            // 🔹 Relación 1–N: Planta -> Usos
            modelBuilder.Entity<Uso>()
                .HasOne(u => u.Planta)
                .WithMany(p => p.Usos)
                .HasForeignKey(u => u.PlantaId)
                .OnDelete(DeleteBehavior.Cascade);

            // 🔹 Relación 1–N: Planta -> Fotos
            modelBuilder.Entity<FotoPlanta>()
                .HasOne(f => f.Planta)
                .WithMany(p => p.Fotos)
                .HasForeignKey(f => f.PlantaId)
                .OnDelete(DeleteBehavior.Cascade);

            // 🔹 Configuración extra de columnas
            modelBuilder.Entity<Categoria>()
                .Property(c => c.Nombre)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Planta>()
                .Property(p => p.Nombre)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Planta>()
                .Property(p => p.NombreCientifico)
                .HasMaxLength(150);

            modelBuilder.Entity<Planta>()
                .Property(p => p.TemporadaSiembra)
                .HasMaxLength(100);
        }
    }
}
