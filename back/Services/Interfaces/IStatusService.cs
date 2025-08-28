using back.DTOs;
using back.Models;
using back.Models.Enums;

namespace back.Services.Interfaces
{
    public interface IStatusService
    {
        Task<IEnumerable<object>> GetAvaiableResource(DateTime date, ResourceType resourceType);
    }    
}
