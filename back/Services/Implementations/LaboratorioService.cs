using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using back.Models;
using back.Services.Interfaces;
using back.Data;
using back.Repositories.Interfaces;

namespace back.Services.Implementations
{
    public class LaboratorioService : ILaboratorioService
    {
        private readonly ILaboratorioRepository _repository;
        public LaboratorioService(ILaboratorioRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Laboratorio>> GetAllAsync()
        {
            var labs = await _repository.GetAllAsync();

            if (!labs.Any())
            {
                throw new KeyNotFoundException("Nenhuma sala encontrada.");
            }

            return labs;
        }

        public async Task<Laboratorio> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id do laboratório inválido.");
            }

            return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(int id, Laboratorio lab)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id do laboratório inválido."); 
            }
        
            await _repository.UpdateAsync(id, lab);
        }
    }
}