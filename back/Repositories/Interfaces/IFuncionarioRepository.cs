using back.Models;

namespace back.Repositories.Interfaces
{
    public interface IFuncionarioRepository
    {
        Task<IEnumerable<Funcionario>> GetAllAsync();
        Task<Funcionario> GetByIdAsync(int id);
    }
}