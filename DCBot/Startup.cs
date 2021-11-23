using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using DCBot.DAL;
using Microsoft.EntityFrameworkCore;

namespace DCBot.BOT
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ECOctx>(options =>
            {
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ECOctx;Trusted_Connection=True;MultipleActiveResultSets=true",
                    x => x.MigrationsAssembly("DCBot.DAL.Migrations"));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            var serviceProvider = services.BuildServiceProvider();

            var bot = new Bot(serviceProvider);
            services.AddSingleton(bot);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

        }
    }
}
