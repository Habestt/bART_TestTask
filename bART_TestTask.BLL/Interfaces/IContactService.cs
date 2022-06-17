using bART_TestTask.BLL.DTOs;
using bART_TestTask.DAL.Models;

namespace bART_TestTask.BLL.Interfaces
{
    public interface IContactService
    {
        Task AddAsync(ContactDTO entity);
        Task CreateOrUpdateByEmailAsync(ContactForAccDTO entity, string contactEmail);
        Task<IEnumerable<Contact>> GetAllAsync();
        Task<Contact> GetByEmailAsync(string contactEmail);
    }
}