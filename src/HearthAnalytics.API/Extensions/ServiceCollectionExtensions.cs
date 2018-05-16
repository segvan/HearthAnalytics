using HearthAnalytics.Infrastructure;
using HearthAnalytics.Model.Repositories;
using HearthAnalytics.Repositories.EF;
using HearthAnalytics.Repositories.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HearthAnalytics.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddHearthAnalytics(this IServiceCollection services, IConfiguration configuration)
        {
            // DI
            services.AddScoped<IArchyTypesRepository, ArchyTypesRepository>();
            services.AddScoped<IDecksRepository, DecksRepository>();
            services.AddScoped<IMatchesRepository, MatchesRepository>();
            services.AddScoped<IClassTypesRepository, ClassTypesRepository>();
            services.AddScoped<IMatchResultsRepository, MatchResultsRepository>();
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();

            services.AddDbContext<HearthAnalyticsDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
