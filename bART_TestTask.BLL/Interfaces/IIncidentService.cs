using bART_TestTask.BLL.DTOs;
using bART_TestTask.DAL.Models;

namespace bART_TestTask.BLL.Interfaces
{
    public interface IIncidentService
    {
        Task AddAsync(IncidentDTO entity);
        Task AddForAccAsync(IncidentForAccDTO entity);
        Task<IEnumerable<Incident>> GetAllAsync();
        Task<Incident> GetByIdAsync(int id);
        Task RemoveAsync(int id);
        Task UpdateAsync(IncidentDTO entity);
    }
}