using bART_TestTask.BLL.DTOs;
using bART_TestTask.DAL.Models;

namespace bART_TestTask.BLL.Interfaces
{
    public interface IAccountService
    {
        Task AddAsync(AccountDTO entity);
        Task<IEnumerable<Account>> GetAllAsync();
        Task<Account> GetByNameAsync(string accountName);
    }
}