using back.DTOs;
using back.Models;
using back.Repositories.Interfaces;
using back.Services.Interfaces;

namespace back.Services.Implementations
{
    public class AlocacaoService: IAlocacaoService
    {
        private readonly IAlocacaoRepository _repository;

        public AlocacaoService(IAlocacaoRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(AlocacaoCreateDTO alocacaoDto)
        {
            var alocacao = new Alocacao
            {
                DataAlocacao = alocacaoDto.DataAlocacao,
                FuncionarioId = alocacaoDto.FuncionarioId,
                LaboratorioId = alocacaoDto.LaboratorioId,
                SalaId = alocacaoDto.SalaId,
                NotebookId = alocacaoDto.NotebookId,
                
            };

            await _repository.CreateAsync(alocacao);
        }
    }   
}