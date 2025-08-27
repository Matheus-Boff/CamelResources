using back.Data;
using back.Models;
using back.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace back.Repositories.Implementations;

public class NotebookRepository: INotebookRepository
{
    private readonly AppDbContext _context;

    public NotebookRepository(AppDbContext context)
    {
        this._context = context;
    }
    
    public async Task<IEnumerable<Notebook>> GetAllAsync()
    {
        return await _context.Notebooks.ToListAsync();
    }

    public async Task<Notebook> GetByIdAsync(int id)
    {
        var notebook = await _context.Notebooks.FindAsync(id);

        if (notebook == null)
        {
            throw new KeyNotFoundException($"Notebook com id {id} não encontrado.");
        }

        return notebook;
    }

    public async Task CreateAsync(Notebook notebook)
    {
        await _context.Notebooks.AddAsync(notebook); 
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(int id, Notebook notebook)
    {
        var notebookToUpdate = await _context.Notebooks.FindAsync(id);

        if (notebook == null)
        {
            throw new KeyNotFoundException($"Notebook com id {id} não encontrado.");  
        }
        
        notebookToUpdate.Descricao = notebook.Descricao;
        notebookToUpdate.DataAquisicao = notebook.DataAquisicao;
        notebookToUpdate.NroPatrimonio = notebook.NroPatrimonio;
        
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var notebook = await _context.Notebooks.FindAsync(id);

        if (notebook == null)
        {
            throw new KeyNotFoundException($"Notebook com id {id} não encontrado."); 
        }
        
        _context.Notebooks.Remove(notebook);
        await _context.SaveChangesAsync();

    }
}