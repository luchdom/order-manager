using OrderManager.Api.Settings;

namespace OrderManager.Api;

internal static partial class Startup
{
    public static IServiceCollection AddCustomSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<OrderManagerApiSettings>()
            .Bind(configuration.GetSection(OrderManagerApiSettings.Settings))
            .ValidateDataAnnotations();
        services.AddOptions<JwtTokenSettings>()
           .Bind(configuration.GetSection(JwtTokenSettings.Settings))
           .ValidateDataAnnotations();
        return services;
    }
}
