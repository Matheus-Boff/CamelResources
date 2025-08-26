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
    }
}
