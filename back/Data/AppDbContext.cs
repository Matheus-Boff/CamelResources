using Microsoft.EntityFrameworkCore;
using back.Models;

namespace back.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Notebook> Notebooks { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Laboratorio> Laboratorios { get; set; }
        public DbSet<Alocacao> Alocacoes { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Constraint: um Notebook por dia
            modelBuilder.Entity<Alocacao>()
                .HasIndex(a => new { a.NotebookId, a.DataAlocacao })
                .IsUnique()
                .HasFilter("[NotebookId] IS NOT NULL"); // pode ser NULL

            // Constraint: uma Sala por dia
            modelBuilder.Entity<Alocacao>()
                .HasIndex(a => new { a.SalaId, a.DataAlocacao })
                .IsUnique()
                .HasFilter("[RoomId] IS NOT NULL");

            // Constraint: um Laboratório por dia
            modelBuilder.Entity<Alocacao>()
                .HasIndex(a => new { a.LaboratorioId, a.DataAlocacao })
                .IsUnique()
                .HasFilter("[LabId] IS NOT NULL");
        }
    }
}
