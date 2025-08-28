using back.DTOs;
using back.Models;
using back.Models.Enums;

namespace back.Services.Interfaces
{
    public interface IStatusService
    {
        Task<IEnumerable<object>> GetAvaiableResource(DateTime date, ResourceType resourceType);
        Task<IEnumerable<ResourcesByDateDto>> GetResourcesByDateRange(DateTime startDate, DateTime endDate);
        Task<IEnumerable<ResourcesCountDto>>  GetResourcesCountByDateRange(DateTime startDate, DateTime endDate);
    }    
}
