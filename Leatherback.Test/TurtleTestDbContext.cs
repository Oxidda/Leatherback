using Leatherback.DataAccess;
using Microsoft.EntityFrameworkCore;
using Turtle.Test;

namespace Leatherback.Test
{
    public class LeatherbackTestDbContext : LeatherbackDbContext
    {
        public LeatherbackTestDbContext(DbContextOptions<LeatherbackTestDbContext> options) : base(options)
        {
            
        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

    }
}
