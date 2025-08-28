using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using back.Data;
using back.Models;
using back.Repositories.Interfaces;

namespace back.Repositories.Implementations
{
    public class LaboratorioRepository : ILaboratorioRepository
    {
        private readonly AppDbContext _context;

        public LaboratorioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Laboratorio>> GetAllAsync()
        {
            return await _context.Laboratorios.ToListAsync();
        }

        public async Task<Laboratorio> GetByIdAsync(int id)
        {
            var lab = await _context.Laboratorios.FindAsync(id);

            if (lab == null)
            {
                throw new KeyNotFoundException($"Laboratório com id {id} não encontrado."); 
            }

            return lab;
        }

        public async Task UpdateAsync(int id, Laboratorio lab)
        {
            var labToUpdate = await _context.Laboratorios.FindAsync(id);

            if (labToUpdate == null)
            {
                throw new KeyNotFoundException($"Laboratório com id {id} não encontrado.");  
            }

            labToUpdate.Descricao = lab.Descricao;
            labToUpdate.Nome = lab.Nome;
            labToUpdate.NumComputadores = lab.NumComputadores;
        
            await _context.SaveChangesAsync();
        }
    }
}