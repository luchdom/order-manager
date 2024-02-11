
using Asp.Versioning;
using FluentValidation;
using OrderManager.Api.Application.Behaviors;
using OrderManager.Api.Application.Services;

namespace OrderManager.Api;

internal static partial class Startup
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
       

        services.AddTransient<ITokenService, TokenService>();
        return services;
    }
}
