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
            new Funcionario { Id = 1, Matricula = "1234567", Nome = "João Silva", Cargo = "Programador Pleno", DataAdmissao = (DateTime.Parse("2022-01-15")).Date},
            new Funcionario { Id = 2, Matricula = "9876543", Nome = "Maria Souza", Cargo = "Analista", DataAdmissao = (DateTime.Parse("2022-06-10")).Date},
            new Funcionario { Id = 3, Matricula = "1111111", Nome = "Carlos Pereira", Cargo = "Estagiário", DataAdmissao = (DateTime.Parse("2023-02-20")).Date}
        );

          modelBuilder.Entity<Notebook>().HasData(
            new Notebook { Id = 1, NroPatrimonio = "1234567", DataAquisicao = (DateTime.Parse("2022-01-15")).Date, Descricao = "Dell Latitude 5420 - Intel i5, 16GB RAM, 512GB SSD" },
            new Notebook { Id = 2, NroPatrimonio = "9876543", DataAquisicao = (DateTime.Parse("2022-06-10")).Date, Descricao = "Lenovo ThinkPad T14 - AMD Ryzen 5, 8GB RAM, 256GB SSD" },
            new Notebook { Id = 3, NroPatrimonio = "1111111", DataAquisicao = (DateTime.Parse("2023-02-20")).Date, Descricao = "HP EliteBook 840 G7 - Intel i7, 16GB RAM, 1TB SSD" }
            );
          
          modelBuilder.Entity<Sala>().HasData(
              new Sala { Id = 1, Numero = 101, NumLugares = 30, Projetor = true },
              new Sala { Id = 2, Numero = 102, NumLugares = 25, Projetor = false },
              new Sala { Id = 3, Numero = 201, NumLugares = 50, Projetor = true },
              new Sala { Id = 4, Numero = 202, NumLugares = 40, Projetor = false }
              );
          
          modelBuilder.Entity<Laboratorio>().HasData(
              new Laboratorio { Id = 1, Nome = "Lab de Informática 1", NumComputadores = 20, Descricao = "20 PCs Dell Optiplex, Intel i5, 8GB RAM, 256GB SSD, Windows 10" },
              new Laboratorio { Id = 2, Nome = "Lab de Informática 2", NumComputadores = 25, Descricao = "25 PCs Lenovo ThinkCentre, Intel i7, 16GB RAM, 512GB SSD, Linux Ubuntu" },
              new Laboratorio { Id = 3, Nome = "Lab de Robótica", NumComputadores = 15, Descricao = "15 PCs HP ProDesk, Intel i5, 16GB RAM, 1TB SSD, Kits Arduino e Raspberry Pi" }
          ); 
        
            var alocacao = modelBuilder.Entity<Alocacao>();

            alocacao
                .Property(e => e.ResourceType)
                .HasConversion<string>();

            // Delete em cascata
            alocacao
                .HasOne(a => a.Funcionario)
                .WithMany(f => f.Alocacoes)
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
