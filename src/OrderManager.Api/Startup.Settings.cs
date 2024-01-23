using OrderManager.Api.Infra;

namespace OrderManager.Api;

internal static partial class Startup
{
    public static IServiceCollection AddCustomSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<OrderManagerApiSettings>()
            .Bind(configuration.GetSection(OrderManagerApiSettings.Settings))
            .ValidateDataAnnotations();
        return services;
    }
}
