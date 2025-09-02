using System.Collections.Generic;
using System.Threading.Tasks;
using back.DTOs;
using back.Models;

namespace back.Services.Interfaces
{
    public interface ILaboratorioService
    {
        Task<IEnumerable<LaboratorioReadDTO>> GetAllAsync();
        Task<LaboratorioReadDTO> GetByIdAsync(int id);
        Task UpdateAsync(int id, LaboratorioUpdateDTO labDto);
    }
}