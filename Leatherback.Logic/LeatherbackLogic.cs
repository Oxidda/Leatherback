using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Leatherback.Core.Entity;
using Leatherback.DataAccess;

namespace Leatherback.Logic
{
    public class LeatherbackLogic<TEntity, TSearchCriteria> : ILogic<TEntity, TSearchCriteria>
    where TEntity : class, ILeatherbackEntity
    where TSearchCriteria : class, ILeatherbackEntity
    {
        private readonly IRepository<TEntity, TSearchCriteria> _repository;

        public LeatherbackLogic(IRepository<TEntity, TSearchCriteria> repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<IEnumerable<TEntity>> SearchAsync(TSearchCriteria entity)
        {
            return _repository.SearchAsync(entity);
        }

        public Task<TEntity> AddAsync(TEntity entity)
        {
            return _repository.AddAsync(entity);
        }

        public Task<bool> UpdateAsync(TEntity update)
        {
            return _repository.UpdateAsync(update);
        }

        public Task<bool> DeleteAsync(Guid entity)
        {
            return _repository.DeleteAsync(entity);
        }
    }
}
