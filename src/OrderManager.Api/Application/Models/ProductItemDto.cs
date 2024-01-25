namespace OrderManager.Api.Application.Models;

public struct ProductItemDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
