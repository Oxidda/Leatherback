using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Leatherback.Core.Entity;

namespace Leatherback.Logic
{
    public interface ILogic<TEntity, TSearchCriteria>
        where TEntity : ILeatherbackEntity
        where TSearchCriteria : ILeatherbackEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> SearchAsync(TSearchCriteria entity);
        Task<TEntity> AddAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity update);
        Task<bool> DeleteAsync(Guid entity);
    }
}