using AutoMapper;
using Microsoft.AspNetCore.Builder;
using System;
using System.Linq;
using System.Reflection;

namespace HearthAnalytics.API.Extensions
{
    public static class AutoMapperConfigureExtension
    {
        public static void UseAutoMapper(this IApplicationBuilder app)
        {
            Mapper.Initialize(cfg => SearchMappingProfiles(cfg));
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
