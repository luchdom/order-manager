
using OrderManager.Api.Infra;

namespace OrderManager.Api;

internal static partial class Startup
{
    public static IServiceCollection AddCustomHealthChecks(this IServiceCollection services, IConfiguration configuration)
    {
        var hcBuilder = services.AddHealthChecks();
        hcBuilder.AddDbContextCheck<AppDbContext>();
        return services;
    }
}
