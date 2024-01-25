
namespace OrderManager.Api;

internal static partial class Startup
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(Startup).Assembly));
        return services;
    }
}
