namespace OrderManager.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen()
            .AddCustomSettings(builder.Configuration)
            .AddCustomDbContext(builder.Configuration)
            .AddCustomHealthChecks(builder.Configuration)
            .AddCustomServices();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.MapHealthChecks("/health");

        //app.UseHttpsRedirection();

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
