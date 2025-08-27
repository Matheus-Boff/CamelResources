using System.Collections.Generic;
using System.Threading.Tasks;
using back.DTOs;
using back.Models;

namespace back.Services.Interfaces
{
    public interface IFuncionarioService
    {
        Task<IEnumerable<FuncionarioCreateDTO>> GetAllAsync();
        Task<FuncionarioCreateDTO> GetByIdAsync(int id);
    }
}