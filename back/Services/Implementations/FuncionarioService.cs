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
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _repository;
        public FuncionarioService(IFuncionarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FuncionarioCreateDTO>> GetAllAsync()
        {
            var funcionarios = await _repository.GetAllAsync();

            if (!funcionarios.Any())
            {
                throw new KeyNotFoundException("Nenhum funcionário encontrado.");
            }

            var funcionarioDto = funcionarios.Select(f => new FuncionarioCreateDTO
            {
                Id = f.Id,
                Nome = f.Nome,
                Cargo = f.Cargo,
                DataAdmissao = f.DataAdmissao,
                Matricula = f.Matricula,
            });
            
            return funcionarioDto;
        }

        public async Task<FuncionarioCreateDTO> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id do funcionário inválido.");
            }
            
            var funcionario = await _repository.GetByIdAsync(id);

            return new FuncionarioCreateDTO
            {
                Id = funcionario.Id,
                Nome = funcionario.Nome,
                Cargo = funcionario.Cargo,
                DataAdmissao = funcionario.DataAdmissao,
            };
        }

    }
}