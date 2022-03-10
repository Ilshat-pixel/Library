using Library.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Persistence
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
         services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<WebDbContext>(options =>
            {
                options.UseNpgsql(connectionString);

            });
            services.AddScoped<IWebDbContext>(provider =>
                provider.GetService<WebDbContext>());
            return services;
        }
    }
}
