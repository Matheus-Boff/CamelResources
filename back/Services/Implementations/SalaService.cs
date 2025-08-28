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
    public class SalaService : ISalaService
    {
        private readonly ISalaRepository _repository;
        public SalaService(ISalaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<SalaReadDTO>> GetAllAsync()
        {
            var salas = await _repository.GetAllAsync();

            if (!salas.Any())
            {
                throw new KeyNotFoundException("Nenhuma sala encontrada.");
            }

            var salasDTO = salas.Select(s => new SalaReadDTO
            {
                Id = s.Id,
                NumLugares = s.NumLugares,
                Projetor = s.Projetor,
                Numero = s.Numero,
            });
            
            return salasDTO;
        }

        public async Task<SalaReadDTO> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id da sala inválido.");
            }

            var sala = await _repository.GetByIdAsync(id);

            return new SalaReadDTO
            {
                Id = sala.Id,
                NumLugares = sala.NumLugares,
                Projetor = sala.Projetor,
                Numero = sala.Numero,
            };
        }

        public async Task UpdateAsync(int id, SalaUpdateDTO salaDto)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id da sala inválido."); 
            }

            var sala = new Sala
            {
                Numero = salaDto.Numero,
                NumLugares = salaDto.NumLugares,
                Projetor = salaDto.Projetor,
            };
        
            await _repository.UpdateAsync(id, sala);
        }
    }
}