using back.Models.Enums;

namespace back.DTOs
{
    public class ResourcesByDateDto
    {
        public DateTime Data { get; set; }
        public IEnumerable<AlocacaoReadDTO> Alocacao { get; set; }
    }

    public class ResourcesCountDto
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public ResourceType ResourceType { get; set; }
        public NotebookReadDTO? Notebook { get; set; }
        public LaboratorioReadDTO? Laboratorio { get; set; }
        public SalaReadDTO? Sala { get; set; }
    }

    public class ResourcesPerWeekDayDto
    {
        public DayOfWeek DayOfWeek { get; set; }
        public double AllocationsAvg { get; set; }

        public string? WeekDay { get; set; }
    }

}