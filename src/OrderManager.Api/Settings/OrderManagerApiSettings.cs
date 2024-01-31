using System.ComponentModel.DataAnnotations;

namespace OrderManager.Api.Settings;

public class OrderManagerApiSettings
{
    public const string Settings = "Settings";

    [Required]
    public string ConnectionString { get; set; }
}
