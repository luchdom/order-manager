using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OrderManager.Api.Infra;
using OrderManager.Api.Settings;

namespace OrderManager.Api;

internal static partial class Startup
{
    public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var apiSettings = services.BuildServiceProvider().GetService<IOptions<OrderManagerApiSettings>>()?.Value;
        return services
            .AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(apiSettings.ConnectionString,
                           sqlServerOptionsAction: sqlOptions =>
                           {
                               sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                               sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                           });
            },
            ServiceLifetime.Scoped);
    }
}
