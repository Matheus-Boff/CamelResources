using back.DTOs;
using back.Models;

namespace back.Services.Interfaces
{
    public interface IAlocacaoService
    {
        Task CreateAsync(AlocacaoCreateDTO alocacaoDto);
    }   
}