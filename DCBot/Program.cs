using System;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;

namespace DCBot.BOT
{
    class Program
    {
        public static string onTime = DateTime.Now.ToString();
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] a) =>
            Host.CreateDefaultBuilder(a)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
