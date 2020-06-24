using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Leatherback.DataAccess;
using Leatherback.Logic;

namespace Leatherback.Service.Extensions
{
    public static class TurtleServiceCollectionExtensions
    {
        public static IServiceCollection UseLeatherback<TDbContext>(this IServiceCollection services, string connectionString)
        where TDbContext : DbContext
        {
            services.
                    AddMvc(o => o.Conventions.Add(
                            new GenericControllerRouteConvention()
                  )).
                    ConfigureApplicationPartManager(m =>
                        m.FeatureProviders.Add(new TurtleControllerProvider(services)
                  ));
            services.AddTransient(typeof(ILogic<,>), typeof(LeatherbackLogic<,>));
            services.AddTransient(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddTransient(typeof(ILogic<,>), typeof(LeatherbackLogic<,>));
            services.AddTransient(typeof(ISearchQuery<,>), typeof(SearchQuery<,>));


            services.AddTransient(typeof(LeatherbackDbContext), typeof(TDbContext));
            services.AddDbContext<TDbContext>(options => options.UseSqlServer(connectionString));
            return services;
        }
    }
}
