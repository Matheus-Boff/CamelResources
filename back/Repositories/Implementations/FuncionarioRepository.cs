using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using back.Data;

namespace back.Repositories.Implementations
{
    public class FuncionarioRepository : IFuncionarioRespository
    {
        private readonly AppDbContext _context;

        public FuncionarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumberable<Funcionario>> GetAllAsync()
        {
            return await _context.Funcionarios.ToListAsync();
        }

        public async Task<Funcionario> GetByIdAsync(int id)
        {
            return await _context.Funcionarios.FindAsync(id);
        } 
    }
}