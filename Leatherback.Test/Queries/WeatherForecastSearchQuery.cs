using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leatherback.DataAccess;

namespace Turtle.Test.Queries
{
    public class WeatherForecastSearchQuery : ISearchQuery<WeatherForecast, WeatherForecastSearchCriteria>
    {
        public Task<IEnumerable<WeatherForecast>> SearchAsync(LeatherbackDbContext dbContext, WeatherForecastSearchCriteria criteria)
        {
            return Task.Run(() => Search(dbContext, criteria));
        }

        private IEnumerable<WeatherForecast> Search(LeatherbackDbContext dbContext, WeatherForecastSearchCriteria criteria)
        {
            return dbContext.Set<WeatherForecast>().Where(x => x.Id == criteria.Id).ToList();
        }
    }
}
