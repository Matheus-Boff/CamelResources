using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using back.Models;
using back.Services.Interfaces;
using back.Data;
using back.Repositories.Interfaces;

namespace back.Services.Implementations
{
    public class SalaService : ISalaService
    {
        private readonly ISalaRepository _repository;
        public SalaService(ISalaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Sala>> GetAllAsync()
        {
            var salas = await _repository.GetAllAsync();

            if (!salas.Any())
            {
                throw new KeyNotFoundException("Nenhuma sala encontrada.");
            }

            return salas;
        }

        public async Task<Sala> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id da sala inválido.");
            }

            return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(int id, Sala sala)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id da sala inválido."); 
            }
        
            await _repository.UpdateAsync(id, sala);
        }
    }
}