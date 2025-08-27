using back.Models;

namespace back.Services.Interfaces;

public interface INotebookService
{
    Task<IEnumerable<Notebook>> GetAllAsync();
    Task<Notebook> GetByIdAsync(int id);
    Task CreateAsync(Notebook notebook);
    Task UpdateAsync(int id, Notebook notebook);
    Task DeleteAsync(int id);
}