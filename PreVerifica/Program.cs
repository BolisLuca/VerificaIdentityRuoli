using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using PreVerifica.Data;

namespace PreVerifica
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
         

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                
                try
                {
                    SeedData.Initzialize(services).Wait();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger>();
                    logger.LogError(ex, "There was an error seeding the DB");
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
