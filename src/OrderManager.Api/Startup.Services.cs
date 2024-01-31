
using FluentValidation;
using OrderManager.Api.Application.Behaviors;
using OrderManager.Api.Application.Services;

namespace OrderManager.Api;

internal static partial class Startup
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        services.AddApiVersioning();
        services.AddValidatorsFromAssembly(typeof(Startup).Assembly);
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(Startup).Assembly);
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddTransient<ITokenService, TokenService>();
        return services;
    }
}
