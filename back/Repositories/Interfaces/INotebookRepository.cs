using back.Models;

namespace back.Repositories.Interfaces;

public interface INotebookRepository
{
    Task<IEnumerable<Notebook>> GetAllAsync();
    Task<Notebook> GetByIdAsync(int id);
    Task CreateAsync(Notebook notebook);
    Task UpdateAsync(int id, Notebook notebook);
    Task DeleteAsync(int id);
}