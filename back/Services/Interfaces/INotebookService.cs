using back.DTOs;
using back.Models;

namespace back.Services.Interfaces;

public interface INotebookService
{
    Task<IEnumerable<NotebookReadDTO>> GetAllAsync();
    Task<NotebookReadDTO> GetByIdAsync(int id);
    Task CreateAsync(NotebookCreateDTO notebookDto);
    Task UpdateAsync(int id, NotebookUpdateDTO notebookDto);
    Task DeleteAsync(int id);
}