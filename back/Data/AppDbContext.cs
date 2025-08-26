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

            modelBuilder.Entity<Funcionario>().HasData(
            new Funcionario { Id = 1, Matricula = "1234567", Nome = "João Silva", Cargo = "Programador Pleno" },
            new Funcionario { Id = 2, Matricula = "9876543", Nome = "Maria Souza", Cargo = "Analista" },
            new Funcionario { Id = 3, Matricula = "1111111", Nome = "Carlos Pereira", Cargo = "Estagiário" }
        );

            var alocacao = modelBuilder.Entity<Alocacao>();

            // Delete em cascata
            alocacao
                .HasOne(a => a.Funcionario)
                .WithMany()
                .HasForeignKey(a => a.FuncionarioId)
                .OnDelete(DeleteBehavior.Cascade);

            alocacao
                .HasOne(a => a.Notebook)
                .WithMany()
                .HasForeignKey(a => a.NotebookId)
                .OnDelete(DeleteBehavior.Cascade);

            alocacao
                .HasOne(a => a.Sala)
                .WithMany()
                .HasForeignKey(a => a.SalaId)
                .OnDelete(DeleteBehavior.Cascade);

            alocacao
                .HasOne(a => a.Laboratorio)
                .WithMany()
                .HasForeignKey(a => a.LaboratorioId)
                .OnDelete(DeleteBehavior.Cascade);

            // Restrição: um recurso por dia
            alocacao
                .HasIndex(a => new { a.NotebookId, a.DataAlocacao })
                .IsUnique()
                .HasFilter("[NotebookId] IS NOT NULL");

            alocacao
                .HasIndex(a => new { a.SalaId, a.DataAlocacao })
                .IsUnique()
                .HasFilter("[SalaId] IS NOT NULL");

            alocacao
                .HasIndex(a => new { a.LaboratorioId, a.DataAlocacao })
                .IsUnique()
                .HasFilter("[LaboratorioId] IS NOT NULL");
        }
    }
}
