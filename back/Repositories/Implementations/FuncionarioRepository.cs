using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using back.Data;
using back.Models;
using back.Repositories.Interfaces;

namespace back.Repositories.Implementations
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly AppDbContext _context;

        public FuncionarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Funcionario>> GetAllAsync()
        {
            return await _context.Funcionarios.ToListAsync();
        }

        public async Task<Funcionario> GetByIdAsync(int id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);

            if (funcionario == null)
            {
                throw new KeyNotFoundException($"Funcionário com id {id} não encontrado."); 
            }

            return funcionario;
        } 
    }
}