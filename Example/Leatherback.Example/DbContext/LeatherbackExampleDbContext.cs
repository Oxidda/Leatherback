using Leatherback.Example.Models;
using Microsoft.EntityFrameworkCore;

namespace Leatherback.Example.DbContext
{
    public class LeatherbackExampleDbContext : DataAccess.LeatherbackDbContext
    {
        public LeatherbackExampleDbContext(DbContextOptions options) :base(options){ }

        public DbSet<Person> Persons { get; set; }
    }
}
