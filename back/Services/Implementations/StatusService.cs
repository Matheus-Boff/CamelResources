using back.DTOs;
using back.Models;
using back.Models.Enums;
using back.Repositories.Interfaces;
using back.Services.Interfaces;

namespace back.Services.Implementations
{
    public class StatusService: IStatusService
    {
        private readonly IAlocacaoRepository _alocacaoRepository;
        private readonly INotebookRepository _notebookRepository;
        private readonly ISalaRepository _salaRepository;
        private readonly ILaboratorioRepository _laboratorioRepository;

        public StatusService(IAlocacaoRepository alocacaoRepository, INotebookRepository notebookRepository,
            ISalaRepository salaRepository, ILaboratorioRepository laboratorioRepository)
        {
            _alocacaoRepository = alocacaoRepository;
            _notebookRepository = notebookRepository;
            _salaRepository = salaRepository;
            _laboratorioRepository = laboratorioRepository;
        }

        private async Task<IEnumerable<NotebookReadDTO>> GetAllNotebooks(IEnumerable<Alocacao> allocations)
        {
            var notebooks = await _notebookRepository.GetAllAsync();
            
            var allocatedNotebookIds = allocations
                .Where(a => a.NotebookId.HasValue)
                .Select(a => a.NotebookId.Value)
                .ToHashSet();
            
            var availableNotebooks = notebooks
                .Where(n => !allocatedNotebookIds.Contains(n.Id))
                .Select(n => new NotebookReadDTO
                {
                    Id = n.Id,
                    NroPatrimonio = n.NroPatrimonio,
                    Descricao = n.Descricao,
                    DataAquisicao = n.DataAquisicao
                });

            return availableNotebooks;
        }
        
        private async Task<IEnumerable<LaboratorioReadDTO>> GetAllLabs(IEnumerable<Alocacao> allocations)
        {
            var labs = await _laboratorioRepository.GetAllAsync();
            
            var allocatedLabsIds = allocations
                .Where(a => a.LaboratorioId.HasValue)
                .Select(a => a.LaboratorioId.Value)
                .ToHashSet();
            
            var avaiableLabs = labs
                .Where(l => !allocatedLabsIds.Contains(l.Id))
                .Select(l => new LaboratorioReadDTO
                {
                    Id = l.Id,
                    Descricao = l.Descricao,
                    Nome = l.Nome,
                    NumComputadores = l.NumComputadores
                });

            return avaiableLabs;
        }

        private async Task<IEnumerable<SalaReadDTO>> GetAllSalas(IEnumerable<Alocacao> allocations)
        {
            var salas = await _salaRepository.GetAllAsync();
            
            var allocatedSalasIds = allocations
                .Where(a => a.SalaId.HasValue)
                .Select(a => a.SalaId.Value)
                .ToHashSet();
            
            var avaiableSalas = salas
                .Where(s => !allocatedSalasIds.Contains(s.Id))
                .Select(s => new SalaReadDTO
                {
                    Id = s.Id,
                    Numero = s.Numero,
                    NumLugares = s.NumLugares,
                    Projetor = s.Projetor
                });

            return avaiableSalas;
        }
        
        public async Task<IEnumerable<object>> GetAvaiableResource(DateTime date, ResourceType resourceType)
        {
            var allocations = await _alocacaoRepository.FindByDateAsync(date);
            Console.WriteLine(allocations.ToString());

            switch (resourceType)
            {
                case ResourceType.Notebook:
                    return await GetAllNotebooks(allocations);
                case ResourceType.Laboratorio:
                    return await GetAllLabs(allocations);
                case ResourceType.Sala:
                    return await GetAllSalas(allocations);
                default:
                    throw new ArgumentException("Tipo de recurso não suportado");
            }
        }

        public async Task<IEnumerable<ResourcesByDateDto>> GetResourcesByDateRange(
            DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate) throw new ArgumentException("A data final não pode ser menor que a data inicial.");
            
            var allocationsInRange = await _alocacaoRepository.FindByDateRange(startDate, endDate);

            var resourcesByDateList = new List<ResourcesByDateDto>();

            for (var date = startDate.Date; date <= endDate.Date; date = date.AddDays(1))
            {
                var dailyAllocations = allocationsInRange
                    .Where(a => a.DataAlocacao.Date == date)
                    .ToList();

                var allocationsDto = dailyAllocations.Select(d => new AlocacaoReadDTO
                {
                    Id = d.Id,
                    DataAlocacao = d.DataAlocacao,
                    LaboratorioId = d.LaboratorioId,
                    SalaId = d.SalaId,
                    FuncionarioId = d.FuncionarioId,
                    NotebookId = d.NotebookId
                }).ToList();

                if (allocationsDto.Any())
                {
                    resourcesByDateList.Add(new ResourcesByDateDto
                    {
                        Data = date,
                        Alocacao = allocationsDto
                    });
                }
            }

            if (resourcesByDateList.Count == 0) throw new KeyNotFoundException("Nenhum valor encontrado");

            return  resourcesByDateList;
        }
    }    
}
