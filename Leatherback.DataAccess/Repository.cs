using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leatherback.Core.Entity;

namespace Leatherback.DataAccess
{
    public class Repository<TEntity, TSearchCriteria> : IRepository<TEntity, TSearchCriteria>
    where TEntity : class, ILeatherbackEntity
    where TSearchCriteria : class, ILeatherbackEntity
    {
        private readonly LeatherbackDbContext _dbContext;
        private readonly ISearchQuery<TEntity, TSearchCriteria> _searchLogic;

        public Repository(LeatherbackDbContext dbContext, ISearchQuery<TEntity, TSearchCriteria> searchLogic)
        { 
            _dbContext = dbContext;
            _searchLogic = searchLogic;
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return Task.Run(GetAll);
        }

        private IEnumerable<TEntity> GetAll()
        {
            
            return _dbContext.Set<TEntity>().ToList();
        }

        public Task<IEnumerable<TEntity>> SearchAsync(TSearchCriteria entity)
        {
            return _searchLogic.SearchAsync(_dbContext, entity);
        }

        public Task<TEntity> AddAsync(TEntity entity)
        {
            return Task.Run(() => Add(entity));
        }

        private TEntity Add(TEntity entity)
        {
            var v = _dbContext.Add(entity);
            _dbContext.SaveChanges();
            return v.Entity;
        }

        public Task<bool> UpdateAsync(TEntity update)
        {
            return Task.Run(() => Update(update));
        }

        private bool Update(TEntity update)
        {
            try
            {
                _dbContext.Set<TEntity>().Update(update);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public Task<bool> DeleteAsync(Guid entity)
        {
            return Task.Run(() => Delete(entity));
        }

        private bool Delete(Guid delete)
        {
            try
            {
                var entityToDelete = _dbContext.Set<TEntity>().FirstOrDefault(x=>x.Id == delete);
                if (entityToDelete == null)
                {
                    return false;
                }
                _dbContext.Set<TEntity>().Remove(entityToDelete);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
