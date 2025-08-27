using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using back.Data;
using back.Models;
using back.Repositories.Interfaces;

namespace back.Repositories.Implementations
{
    public class SalaRepository : ISalaRepository
    {
        private readonly AppDbContext _context;

        public SalaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sala>> GetAllAsync()
        {
            return await _context.Salas.ToListAsync();
        }

        public async Task<Sala> GetByIdAsync(int id)
        {
            var sala = await _context.Salas.FindAsync(id);

            if (sala == null)
            {
                throw new KeyNotFoundException($"Sala com id {id} não encontrada."); 
            }

            return sala;
        }

        public async Task UpdateAsync(int id, Sala sala)
        {
            var salaToUpdate = await _context.Salas.FindAsync(id);

            if (sala == null)
            {
                throw new KeyNotFoundException($"Sala com id {id} não encontrada.");  
            }

            salaToUpdate.Numero = sala.Numero;
            salaToUpdate.NumLugares = sala.NumLugares;
            salaToUpdate.Projetor = sala.Projetor;
        
            await _context.SaveChangesAsync();
        }
    }
}