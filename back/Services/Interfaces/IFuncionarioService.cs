using System.Collections.Generic;
using System.Threading.Tasks;
using back.Models;

namespace back.Services.Interfaces
{
    public interface IFuncionarioService
    {
        Task<IEnumerable<Funcionario>> GetAllAsync();
        Task<Funcionario> GetByIdAsync(int id);
    }
}