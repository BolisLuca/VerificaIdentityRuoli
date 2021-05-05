using Bolis.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace Bolis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope()) //.Create scope inzialmente non lo consiglia perchè manca una using, quella della dependency injection
            {
                var services = scope.ServiceProvider;
                try
                {
                    SeedData.Initzialize(services).Wait();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger>(); //Anche ILogger non lo consiglia inizialmemte, manca sempre una using, questa volta quella del logging
                    logger.LogError(ex, "error seeding the db.");
                }
            }
            

                host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
