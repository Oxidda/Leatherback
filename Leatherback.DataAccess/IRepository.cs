using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Leatherback.Core.Entity;

namespace Leatherback.DataAccess
{
    public interface IRepository<TEntity, TSearchCriteria>
        where TEntity : ILeatherbackEntity
        where TSearchCriteria : ILeatherbackEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> SearchAsync(TSearchCriteria criteria);
        Task<TEntity> AddAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity update);
        Task<bool> DeleteAsync(Guid entity);
    }
}
