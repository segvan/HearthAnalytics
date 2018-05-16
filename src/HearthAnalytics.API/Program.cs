using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using HearthAnalytics.API.Extensions;

namespace HearthAnalytics.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            host.SetupDatabase();
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
