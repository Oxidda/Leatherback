using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leatherback.Core.Entity;

namespace Leatherback.DataAccess
{
    public class SearchQuery<TEntity, TSearchCriteria> : ISearchQuery<TEntity, TSearchCriteria>
        where TEntity : class, ILeatherbackEntity
        where TSearchCriteria : class, ILeatherbackEntity
    {
        public Task<IEnumerable<TEntity>> SearchAsync(LeatherbackDbContext dbContext, TSearchCriteria criteria)
        {
            return Task.Run<IEnumerable<TEntity>>(() =>
                dbContext.Set<TEntity>().Where(x => x.Id == criteria.Id).ToList());
        }
    }
}
