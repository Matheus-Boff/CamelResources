using System.Collections.Generic;
using System.Threading.Tasks;
using back.Models;

namespace back.Services.Interfaces
{
    public interface ILaboratorioService
    {
        Task<IEnumerable<Laboratorio>> GetAllAsync();
        Task<Laboratorio> GetByIdAsync(int id);
        Task UpdateAsync(int id, Laboratorio lab);
    }
}