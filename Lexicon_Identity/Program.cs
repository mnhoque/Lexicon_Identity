using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lexicon_Identity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Lexicon_Identity
{
    public class Program
    {
        public static void Main(string[] args)
        {


            CreateHostBuilder(args).Build().Run();
        }

        //public static async Task Main(string[] args)
        //{
        //    var host = CreateHostBuilder(args).Build();
        //    using (var scope = host.Services.CreateScope())
        //    {
        //        await DbInitializer.Initialize(scope.ServiceProvider);
        //    }
        //    host.Run();
        //}

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
