using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Gnios.CashBack.Api
{
    public static class WebHostExtensions
    {
        public static IWebHost SeedData(this IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<DbInitializer>();

                // now we have the DbContext. Run migrations
                context.Seed();
            }
            return host;    
        }
    }
}
