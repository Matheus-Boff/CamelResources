using back.DTOs;
using back.Models;
using back.Repositories.Interfaces;
using back.Services.Interfaces;

namespace back.Services.Implementations;

public class NotebookService: INotebookService
{
    private readonly INotebookRepository _repository;

    public NotebookService(INotebookRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<NotebookReadDTO>> GetAllAsync()
    {
        var notebooks = await _repository.GetAllAsync();

        if (!notebooks.Any())
        {
            throw new KeyNotFoundException("Nenhum funcionário encontrado."); 
        }

        var notebooksDtos = notebooks.Select(n => new NotebookReadDTO
        {
            Id = n.Id,
            NroPatrimonio = n.NroPatrimonio,
            Descricao = n.Descricao,
            DataAquisicao = n.DataAquisicao,
        });
        
        return notebooksDtos;
    }

    public async Task<NotebookReadDTO> GetByIdAsync(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Id do notebook inválido."); 
        }
        
        var notebook = await _repository.GetByIdAsync(id);

        return new NotebookReadDTO
        {
            Id = notebook.Id,
            Descricao = notebook.Descricao,
            DataAquisicao = notebook.DataAquisicao,
            NroPatrimonio = notebook.NroPatrimonio,
        };
    }

    public async Task CreateAsync(NotebookCreateDTO notebookDto)
    {   
        var notebook = new Notebook
        {
            NroPatrimonio = notebookDto.NroPatrimonio,
            Descricao = notebookDto.Descricao,
            DataAquisicao = notebookDto.DataAquisicao,
        };
        
        await _repository.CreateAsync(notebook);
    }

    public async Task UpdateAsync(int id, NotebookUpdateDTO notebookDto)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Id do notebook inválido."); 
        }

        var notebook = new Notebook
        {
            NroPatrimonio = notebookDto.NroPatrimonio,
            Descricao = notebookDto.Descricao,
            DataAquisicao = notebookDto.DataAquisicao,
        };
        
        await _repository.UpdateAsync(id, notebook);
    }

    public async Task DeleteAsync(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Id do notebook inválido."); 
        }
        
        await _repository.DeleteAsync(id);
    }
}