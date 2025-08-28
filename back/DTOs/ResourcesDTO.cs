using back.Models.Enums;

namespace back.DTOs
{
    public class ResourcesAllocationsCountDTO
    {
        public ResourceType ResourceType { get; set; }
        public int ResourceId { get; set; }
        public int TotalAllocations { get; set; }
    }

    public class ResourcesByDateDto
    {
        public DateTime Data { get; set; }
        public IEnumerable<AlocacaoReadDTO> Alocacao { get; set; }
    }
}