using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using back.Models;
using back.Services.Interfaces;
using back.Data;
using back.DTOs;
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

        public async Task<IEnumerable<LaboratorioReadDTO>> GetAllAsync()
        {
            var labs = await _repository.GetAllAsync();

            if (!labs.Any())
            {
                throw new KeyNotFoundException("Nenhuma sala encontrada.");
            }

            var labsDto = labs.Select(l => new LaboratorioReadDTO
            {
                Id = l.Id,
                Nome = l.Nome,
                NumComputadores = l.NumComputadores,
                Descricao = l.Descricao
            });
            
            return labsDto;
        }

        public async Task<LaboratorioReadDTO> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id do laboratório inválido.");
            }

            var lab = await _repository.GetByIdAsync(id);

            return new LaboratorioReadDTO
            {
                Id = lab.Id,
                Nome = lab.Nome,
                NumComputadores = lab.NumComputadores,
                Descricao = lab.Descricao
            };
        }

        public async Task UpdateAsync(int id, LaboratorioUpdateDTO labDto)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id do laboratório inválido."); 
            }

            var lab = new Laboratorio
            {
                Descricao = labDto.Descricao,
                Nome = labDto.Nome,
                NumComputadores = labDto.NumComputadores,
            };
            
            await _repository.UpdateAsync(id, lab);
        }
    }
}