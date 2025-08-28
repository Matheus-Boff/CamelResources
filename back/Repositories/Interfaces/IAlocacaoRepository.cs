using back.DTOs;
using back.Models;

namespace back.Repositories.Interfaces;

public interface IAlocacaoRepository
{
    Task<IEnumerable<Alocacao>> GetAllAsync();
    Task<Alocacao> GetByIdAsync(int id);
    Task CreateAsync(Alocacao alocacao);
    Task<bool> FindRegister(AlocacaoCreateDTO alocacao);
    Task<IEnumerable<Alocacao>> FindByDateAsync(DateTime date);
    Task<IEnumerable<Alocacao>> FindByDateRange(DateTime startDate, DateTime endDate);
    Task<IEnumerable<Alocacao>> OrderByResource();
}