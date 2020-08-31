using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChessBoard.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ChessBoard
{
    public class Program
    {
        public static void Main(string[] args)
        {
            System.Diagnostics.Debug.WriteLine("test console");
            var host = CreateHostBuilder(args).Build();
            
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    DbInitializer.Initialize(context);

                    //var factions = context.Factions.ToList();
                    //foreach(var f in factions)
                    //{
                    //    f.Pax = f.Civilization.ToString().Substring(0, 3);
                    //}
                    //context.SaveChanges();
                }
                catch (Exception e)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(e, "An error occured while seeding the database");
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseStartup<Startup>()
                        .UseDefaultServiceProvider(options => options.ValidateScopes = false);
                });
    }
}
