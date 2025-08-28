using back.Models;

namespace back.Repositories.Interfaces
{
    public interface ISalaRepository
    {
        Task<IEnumerable<Sala>> GetAllAsync();
        Task<Sala> GetByIdAsync(int id);
        Task UpdateAsync(int id, Sala sala);
    }
}