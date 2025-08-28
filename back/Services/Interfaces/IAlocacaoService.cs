using back.DTOs;
using back.Models;

namespace back.Services.Interfaces
{
    public interface IAlocacaoService
    {
        Task<IEnumerable<AlocacaoReadDTO>> GetAllAsync();
        Task<AlocacaoReadDTO> GetByIdAsync(int id);
        Task CreateAsync(AlocacaoCreateDTO alocacaoDto);
        Task <IEnumerable<AlocacaoReadDTO>> GetAlocacoesByUserIdAsync(int id);

    }   
}