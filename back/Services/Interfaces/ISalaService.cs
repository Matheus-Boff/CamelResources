using System.Collections.Generic;
using System.Threading.Tasks;
using back.DTOs;
using back.Models;

namespace back.Services.Interfaces
{
    public interface ISalaService
    {
        Task<IEnumerable<SalaReadDTO>> GetAllAsync();
        Task<SalaReadDTO> GetByIdAsync(int id);
        Task UpdateAsync(int id, SalaUpdateDTO salaDto);
    }
}