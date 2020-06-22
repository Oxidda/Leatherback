using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leatherback.DataAccess
{
    public interface ISearchQuery<TEntity, TSearchCriteria>
     where TEntity : class
    {
        Task<IEnumerable<TEntity>> SearchAsync(LeatherbackDbContext dbContext, TSearchCriteria criteria);
    }
}
