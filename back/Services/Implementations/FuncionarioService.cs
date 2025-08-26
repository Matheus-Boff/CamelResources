using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using back.Models;
using back.Services.Interfaces;
using back.Data;
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

        public async Task<IEnumerable<Funcionario>> GetAllAsync()
        {
            var funcionarios = await _repository.GetAllAsync();

            if (!funcionarios.Any())
            {
                throw new KeyNotFoundException("Nenhum funcionário encontrado.");
            }

            return funcionarios;
        }

        public async Task<Funcionario> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id do funcionário inválido.");
            }

            return await _repository.GetByIdAsync(id);
        }

    }
}