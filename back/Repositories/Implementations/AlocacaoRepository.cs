using back.Data;
using back.DTOs;
using back.Models;
using back.Models.Enums;
using back.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace back.Repositories.Implementations
{
    public class AlocacaoRepository : IAlocacaoRepository
    {
        private readonly AppDbContext _context;

        public AlocacaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Alocacao>> GetAllAsync()
        {
            return await _context.Alocacoes.ToListAsync();
        }

        public async Task<Alocacao> GetByIdAsync(int id)
        {
            var alocacao = await _context.Alocacoes.FindAsync(id);

            if (alocacao == null)
            {
                throw new KeyNotFoundException($"Alocação com id {id} não encontrada.");
            }

            return alocacao;
        }

        public async Task<IEnumerable<Alocacao>> FindByDateAsync(DateTime date)
        {
            return await _context.Alocacoes.Where(a => a.DataAlocacao == date).ToListAsync();
        }

        public async Task<IEnumerable<Alocacao>> FindByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Alocacoes
                .Where(a => a.DataAlocacao.Date >= startDate.Date
                && a.DataAlocacao.Date <= endDate.Date)
                .ToListAsync();
        }

        public async Task CreateAsync(Alocacao alocacao)
        {
            _context.Alocacoes.Add(alocacao);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> FindRegisterAsync(AlocacaoCreateDTO alocacaoDto)
        {
            return await _context.Alocacoes.AnyAsync(a => a.DataAlocacao == alocacaoDto.DataAlocacao
            && (alocacaoDto.LaboratorioId != null && a.LaboratorioId == alocacaoDto.LaboratorioId
               || alocacaoDto.NotebookId != null && a.NotebookId == alocacaoDto.NotebookId
                || alocacaoDto.SalaId != null && a.SalaId == alocacaoDto.SalaId));
        }

        public async Task<IEnumerable<Alocacao>> GetAlocacoesByUserIdAsync(int id)
        {
            return await _context.Alocacoes.Where(a => a.FuncionarioId == id).ToListAsync();
        }
        
        public async Task DeleteAsync(int id)
        {
            var alocacao = await _context.Alocacoes.FindAsync(id);
            if (alocacao == null)
            {
                throw new KeyNotFoundException($"Alocação com id {id} não encontrada.");
            }
            _context.Alocacoes.Remove(alocacao);
            await _context.SaveChangesAsync();
        }
    }   
}