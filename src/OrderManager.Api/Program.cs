

using System.Text.Json.Serialization;

namespace OrderManager.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services
            .AddControllers()
            .AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
        builder.Services
            .AddRouting(options => options.LowercaseUrls = true)
            .AddCustomSettings(builder.Configuration)
            .AddCustomDbContext(builder.Configuration)
            .AddCustomIdentity()
            .AddAuth(builder.Configuration)
            .AddCustomHealthChecks(builder.Configuration)
            .AddCustomServices();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.MapHealthChecks("/health");

        //app.UseHttpsRedirection();
        app.UseStatusCodePages();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }

    private static IConfiguration GetConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

        //var config = builder.Build();

        //if (config.GetValue<bool>("UseVault", false))
        //{
        //    builder.AddAzureKeyVault(
        //        $"https://{config["Vault:Name"]}.vault.azure.net/",
        //        config["Vault:ClientId"],
        //        config["Vault:ClientSecret"]);
        //}

        return builder.Build();
    }
}
