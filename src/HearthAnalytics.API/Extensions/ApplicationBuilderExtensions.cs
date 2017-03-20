using AutoMapper;
using HearthAnalytics.Repositories.EF.Seed;
using HearthAnalytics.Infrastructure;
using HearthAnalytics.Repositories.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace HearthAnalytics.API.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void SetupDatabase(this IApplicationBuilder app)
        {
            // For more details on creating database during deployment see http://go.microsoft.com/fwlink/?LinkID=615859
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                ApplyMigrations(serviceScope);
                SeedInitialData(serviceScope);
            }
        }

        public static void UseAutoMapper(this IApplicationBuilder app)
        {
            Mapper.Initialize(cfg => SearchMappingProfiles(cfg));
        }

        private static void ApplyMigrations(IServiceScope serviceScope)
        {
            var dbContext = serviceScope.ServiceProvider.GetService<HearthAnalyticsDBContext>();            
            dbContext.Database.Migrate();
        }
       
        private static void SeedInitialData(IServiceScope serviceScope)
        {
            var dbcontext = serviceScope.ServiceProvider.GetService<HearthAnalyticsDBContext>();
            var unitOfWork = serviceScope.ServiceProvider.GetService<IUnitOfWork>();

            ISeed classTypeSeed = new ClassTypeSeed(dbcontext.ClassTypes);
            classTypeSeed.Apply();

            ISeed matchResultSeed = new MatchResultSeed(dbcontext.MatchResults);
            matchResultSeed.Apply();

            ISeed userSeed = new UserSeed(dbcontext.Users);
            userSeed.Apply();

            unitOfWork.Complete();
        }
        
        private static void SearchMappingProfiles(IMapperConfigurationExpression configuration)
        {
            var profiles = typeof(Startup).GetTypeInfo().Assembly.GetTypes()
                .Where(x => typeof(Profile).IsAssignableFrom(x));

            foreach (var profile in profiles)
            {
                configuration.AddProfile(Activator.CreateInstance(profile) as Profile);
            }
        }
    }
}
