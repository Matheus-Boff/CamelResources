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

        private bool ValidateAlocacao(AlocacaoCreateDTO alocacaoDto)
        {
            int count = 0;
            if (alocacaoDto.LaboratorioId.HasValue) count++;
            if (alocacaoDto.NotebookId.HasValue) count++;
            if (alocacaoDto.SalaId.HasValue) count++;
            
            Console.WriteLine(count);

            if (alocacaoDto.LaboratorioId.HasValue && count > 1)
            {
                return false;
            }

            if (count == 2)
            {
                if (!(alocacaoDto.NotebookId.HasValue && alocacaoDto.SalaId.HasValue))
                {
                    return false;
                }
            }

            if (count > 2) return false;

            return count > 0;
        }

        public async Task CreateAsync(AlocacaoCreateDTO alocacaoDto)
        {
            Console.WriteLine("lalalala");
            if (!ValidateAlocacao(alocacaoDto))
            {
                throw new ArgumentException("Combinações de alocação inválidas");
            }
            
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