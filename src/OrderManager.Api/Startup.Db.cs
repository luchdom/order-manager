using System.Reflection;
using Microsoft.EntityFrameworkCore;
using OrderManager.Api.Infra;

namespace OrderManager.Api;

internal static partial class Startup
{
    public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddEntityFrameworkSqlServer()
            .AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionString"],
                           sqlServerOptionsAction: sqlOptions =>
                           {
                               sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                               sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                           });
            },
            ServiceLifetime.Scoped);
    }
}
