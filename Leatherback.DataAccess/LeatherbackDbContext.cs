using Microsoft.EntityFrameworkCore;

namespace Leatherback.DataAccess
{
    public abstract class LeatherbackDbContext : DbContext
    {
        public LeatherbackDbContext()
        {

        }


        public LeatherbackDbContext(DbContextOptions options) :base(options)
        {
        }
    }
}
