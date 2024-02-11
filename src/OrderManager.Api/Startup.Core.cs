
using Asp.Versioning;
using FluentValidation;
using Microsoft.OpenApi.Models;
using OrderManager.Api.Application.Behaviors;

namespace OrderManager.Api;

internal static partial class Startup
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services
            .AddEndpointsApiExplorer()
            .AddCustomSwagger()
            .AddProblemDetails()
            .AddProblemDetailsConventions();
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ReportApiVersions = true;
        })
        .AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });
        services.AddValidatorsFromAssembly(typeof(Startup).Assembly);
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(Startup).Assembly);
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
            cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
        });
        return services;
    }

    public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(option =>
        {
             option.SwaggerDoc("v1", new OpenApiInfo { Title = "OrderManagement API", Version = "v1" });
             option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
             {
                 In = ParameterLocation.Header,
                 Description = "Please enter a valid token",
                 Name = "Authorization",
                 Type = SecuritySchemeType.Http,
                 BearerFormat = "JWT",
                 Scheme = "Bearer"
             });
             option.AddSecurityRequirement(new OpenApiSecurityRequirement
             {
                 {
                     new OpenApiSecurityScheme
                     {
                         Reference = new OpenApiReference
                         {
                             Type=ReferenceType.SecurityScheme,
                             Id="Bearer"
                         }
                     },
                     Array.Empty<string>()
                 }
             });
        });
        return services;
    }
}
