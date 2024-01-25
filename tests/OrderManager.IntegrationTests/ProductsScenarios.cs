using Azure;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using OrderManager.Api;
using OrderManager.Api.Application.Models;
using System.Collections.Generic;
using System.Net.Http.Json;

namespace OrderManager.IntegrationTests;

public class ProductsScenarios : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> _factory;

    public ProductsScenarios(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }
    public static class Get
    {
        public static string Products = "products";

        public static string ProductsBy(int id)
        {
            return $"products/{id}";
        }
    }

    [Fact]
    public async Task GetAllProducts()
    {
        //Arrange
        var client = _factory.CreateClient();

        //Act
        var response = await client.GetAsync(Get.Products);

        // Assert
        response.EnsureSuccessStatusCode();
        var products = await response.Content.ReadFromJsonAsync<List<ProductItemDto>>();
        products.Count.Should().Be(3);
    }
}