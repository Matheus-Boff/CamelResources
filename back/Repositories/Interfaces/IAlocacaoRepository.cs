using back.DTOs;
using back.Models;

namespace back.Repositories.Interfaces;

public interface IAlocacaoRepository
{
    Task CreateAsync(Alocacao alocacao);
}