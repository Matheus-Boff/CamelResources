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
        public async Task<IEnumerable<AlocacaoReadDTO>> GetAllAsync()
        {
            var alocacoes = await _repository.GetAllAsync();

            if (!alocacoes.Any())
            {
                throw new KeyNotFoundException("Nenhuma alocação encontrada."); 
            }

            var alocacoesDto = alocacoes.Select(a => new AlocacaoReadDTO
            {
                Id = a.Id,
                FuncionarioId = a.FuncionarioId,
                LaboratorioId = a.LaboratorioId,
                SalaId = a.SalaId,
                NotebookId = a.NotebookId,
                DataAlocacao = a.DataAlocacao,
            });
            
            return alocacoesDto;
        }

        public async Task<AlocacaoReadDTO> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id da alocação inválido."); 
            }
            
            var alocacoes = await _repository.GetByIdAsync(id);

            return new AlocacaoReadDTO
            {
                Id = alocacoes.Id,
                FuncionarioId = alocacoes.FuncionarioId,
                LaboratorioId = alocacoes.LaboratorioId,
                SalaId = alocacoes.SalaId,
                NotebookId = alocacoes.NotebookId,
                DataAlocacao = alocacoes.DataAlocacao,
            };
        }
        
        public async Task CreateAsync(AlocacaoCreateDTO alocacaoDto)
        {
            if (!ValidateAlocacao(alocacaoDto))
            {
                throw new ArgumentException("Combinações de alocação inválidas");
            }

            if (await _repository.FindRegister(alocacaoDto))
            {
                throw new InvalidOperationException("Já existe uma alocação para este recurso nesta data.");
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
    }   
}