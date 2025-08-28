﻿using back.DTOs;
using back.Models;
using back.Models.Enums;
using back.Repositories.Interfaces;
using back.Services.Interfaces;

namespace back.Services.Implementations
{
    public class StatusService : IStatusService
    {
        private readonly IAlocacaoRepository _alocacaoRepository;
        private readonly INotebookRepository _notebookRepository;
        private readonly ISalaRepository _salaRepository;
        private readonly ILaboratorioRepository _laboratorioRepository;

        private readonly Dictionary<DayOfWeek, string> weekDayMapper = new Dictionary<DayOfWeek, string>() {
            { DayOfWeek.Sunday, "Domingo" },
            { DayOfWeek.Monday, "Segunda-feira" },
            { DayOfWeek.Tuesday, "Terça-feira" },
            { DayOfWeek.Wednesday, "Quarta-feira" },
            { DayOfWeek.Thursday, "Quinta-feira" },
            { DayOfWeek.Friday, "Sexta-feira" },
            { DayOfWeek.Saturday, "Sábado" }
        };

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

            var allocationsInRange = await _alocacaoRepository.FindByDateRangeAsync(startDate, endDate);

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

            if (!resourcesByDateList.Any()) throw new KeyNotFoundException("Nenhum valor encontrado");

            return resourcesByDateList;
        }

        private async Task<ResourcesCountDto> GetResourceDetails(ResourcesCountDto resourcesDto)
        {
            switch (resourcesDto.ResourceType)
            {
                case ResourceType.Notebook:
                    var notebook = await _notebookRepository.GetByIdAsync(resourcesDto.Id);
                    resourcesDto.Notebook = new NotebookReadDTO
                    {
                        Descricao = notebook.Descricao,
                        Id = notebook.Id,
                        NroPatrimonio = notebook.NroPatrimonio,
                        DataAquisicao = notebook.DataAquisicao
                    };
                    break;
                case ResourceType.Sala:
                    var sala = await _salaRepository.GetByIdAsync(resourcesDto.Id);
                    resourcesDto.Sala = new SalaReadDTO
                    {
                        Id = sala.Id,
                        Numero = sala.Numero,
                        NumLugares = sala.NumLugares,
                        Projetor = sala.Projetor,
                    };
                    break;
                case ResourceType.Laboratorio:
                    var laboratorio = await _laboratorioRepository.GetByIdAsync(resourcesDto.Id);
                    resourcesDto.Laboratorio = new LaboratorioReadDTO
                    {
                        Id = laboratorio.Id,
                        Nome = laboratorio.Nome,
                        Descricao = laboratorio.Descricao,
                        NumComputadores = laboratorio.NumComputadores,
                    };
                    break;
                default:
                    throw new ArgumentException("Tipo de recurso não suportado");
            }

            return resourcesDto;
        }

        public async Task<IEnumerable<ResourcesCountDto>> GetResourcesCountByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var alocacoes = await _alocacaoRepository.FindByDateRangeAsync(startDate, endDate);

            var resourcesCountDto = alocacoes
                .GroupBy(a => new
                {
                    a.NotebookId,
                    a.LaboratorioId,
                    a.SalaId
                })
                .Select(g => new ResourcesCountDto
                {
                    Id = g.Key.NotebookId ?? g.Key.LaboratorioId ?? g.Key.SalaId ?? 0,
                    Count = g.Count(),
                    ResourceType = g.Key.NotebookId != null ? ResourceType.Notebook :
                        g.Key.LaboratorioId != null ? ResourceType.Laboratorio :
                        g.Key.SalaId != null ? ResourceType.Sala : ResourceType.Unknown
                });

            return resourcesCountDto;
        }


        public async Task<IEnumerable<ResourcesPerWeekDayDto>> GetResourcesPerWeekDayByDateRangeAsync(
        DateTime startDate, DateTime endDate)
        {
            var alocacoes = await _alocacaoRepository.FindByDateRangeAsync(startDate, endDate);

            var weekDaysDto = alocacoes
            .GroupBy(a => a.DataAlocacao.Date)
            .Select(g => new ResourcesPerWeekDayDto
            {
                DayOfWeek = g.Key.DayOfWeek,
                WeekDay = weekDayMapper[g.Key.DayOfWeek],
                AllocationsAvg = g.Count() * 1.0 / g.Select(x => x.DataAlocacao.Date).Distinct().Count()
            }).ToList();

            return weekDaysDto;
        }
    }    
}
