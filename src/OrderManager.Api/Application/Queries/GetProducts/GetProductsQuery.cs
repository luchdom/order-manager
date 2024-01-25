using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderManager.Api.Application.Models;

namespace OrderManager.Api.Application.Queries.GetProducts;

public class GetProductsQuery : IRequest<Result<List<ProductItemDto>>>
{
    [FromQuery(Name = "q")]
    public string? Query { get; set; }
}
