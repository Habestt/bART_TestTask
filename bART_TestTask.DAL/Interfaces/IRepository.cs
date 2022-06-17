using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace bART_TestTask.DAL.Interfaces
{
    public interface IRepository<TEntity>
    {        
        Task<TEntity> GetByIdAsync(int id);
        
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        Task RemoveAsync(TEntity entity);
        
        Task UpdateAsync(TEntity entity);
        
        Task SaveChangesAsync();
    }
}
