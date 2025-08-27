using back.Models;

namespace back.Repositories.Interfaces
{
    public interface ILaboratorioRepository
    {
        Task<IEnumerable<Laboratorio>> GetAllAsync();
        Task<Laboratorio> GetByIdAsync(int id);
        Task UpdateAsync(int id, Laboratorio lab);
    }
}