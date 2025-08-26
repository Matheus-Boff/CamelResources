using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using back.Models;
using back.Services.Interfaces;
using back.Data;

namespace back.Services.Implementations
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _repository;
        FuncionarioService(IFuncionarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Funcionario>> GetAllAsync() { }

        public async Task<Funcionario> GetById(int id) {}

    }
}