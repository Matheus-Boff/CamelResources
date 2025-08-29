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
            // Buscar alocações existentes do usuário para a data
            var existingAllocations = await _repository.GetAlocacoesByUserIdAsync(alocacaoDto.FuncionarioId);
            var allocationsOnDate = existingAllocations.Where(a => a.DataAlocacao.Date == alocacaoDto.DataAlocacao.Date);

            if (!ValidateAlocacao(alocacaoDto, allocationsOnDate))
            {
                throw new ArgumentException("Combinações de alocação inválidas");
            }

            if (await _repository.FindRegisterAsync(alocacaoDto))
            {
                throw new InvalidOperationException("Já existe uma alocação para este recurso nesta data.");
            }

            var alocacao = new Alocacao
            {
                DataAlocacao = alocacaoDto.DataAlocacao.Date,
                FuncionarioId = alocacaoDto.FuncionarioId,
                LaboratorioId = alocacaoDto.LaboratorioId,
                SalaId = alocacaoDto.SalaId,
                NotebookId = alocacaoDto.NotebookId,
            };

            await _repository.CreateAsync(alocacao);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
        private bool ValidateAlocacao(AlocacaoCreateDTO alocacaoDto, IEnumerable<Alocacao> existingAllocations)
        {
            int count = 0;
            if (alocacaoDto.LaboratorioId.HasValue) count++;
            if (alocacaoDto.NotebookId.HasValue) count++;
            if (alocacaoDto.SalaId.HasValue) count++;

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

            if (count == 0) return false;

            
            var hasLab = existingAllocations.Any(a => a.LaboratorioId.HasValue);
            var hasSala = existingAllocations.Any(a => a.SalaId.HasValue);
            var hasNotebook = existingAllocations.Any(a => a.NotebookId.HasValue);

            if (alocacaoDto.LaboratorioId.HasValue)
            {
                if (hasSala || hasNotebook)
                {
                    return false;
                }
            }
            else if (alocacaoDto.SalaId.HasValue)
            {
                if (hasLab)
                {
                    return false;
                }
            }
            else if (alocacaoDto.NotebookId.HasValue)
            {
                if (hasLab)
                {
                    return false;
                }
            }

            return true;
        }
        
        public async Task<IEnumerable<AlocacaoReadDTO>> GetAlocacoesByUserIdAsync(int id)
        {
            var alocacoes = await _repository.GetAlocacoesByUserIdAsync(id);
            
            if (!alocacoes.Any()) throw new KeyNotFoundException("Nenhuma alocação encontrada.");

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

    }   
}