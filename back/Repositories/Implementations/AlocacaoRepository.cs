using back.Data;
using back.Models;
using back.Repositories.Interfaces;

namespace back.Repositories.Implementations
{
    public class AlocacaoRepository: IAlocacaoRepository
    {
        private readonly AppDbContext _context;

        public AlocacaoRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task CreateAsync(Alocacao alocacao)
        {
            _context.Alocacoes.Add(alocacao);
            await _context.SaveChangesAsync();
        }
    }   
}