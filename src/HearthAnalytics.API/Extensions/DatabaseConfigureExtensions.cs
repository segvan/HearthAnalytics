using HearthAnalytics.Repositories.EF.Seed;
using HearthAnalytics.Infrastructure;
using HearthAnalytics.Repositories.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using System;

namespace HearthAnalytics.API.Extensions
{
    public static class DatabaseConfigureExtensions
    {
        public static void SetupDatabase(this IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                ApplyMigrations(services);
                SeedInitialData(services);
            }
        }
        
        private static void ApplyMigrations(IServiceProvider services)
        {
            var dbContext = services.GetService<HearthAnalyticsDBContext>();            
            dbContext.Database.Migrate();
        }
       
        private static void SeedInitialData(IServiceProvider services)
        {
            var dbcontext = services.GetService<HearthAnalyticsDBContext>();
            var unitOfWork = services.GetService<IUnitOfWork>();

            ISeed classTypeSeed = new ClassTypeSeed(dbcontext.ClassTypes);
            classTypeSeed.Apply();

            ISeed matchResultSeed = new MatchResultSeed(dbcontext.MatchResults);
            matchResultSeed.Apply();

            ISeed userSeed = new UserSeed(dbcontext.Users);
            userSeed.Apply();

            unitOfWork.Complete();
        }
    }
}