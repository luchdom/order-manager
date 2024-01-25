using FluentResults;
using MediatR;
using OrderManager.Api.Application.Models;

namespace OrderManager.Api.Application.Queries.GetProducts;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, Result<List<ProductItemDto>>>
{
    private readonly ILogger<GetProductsQueryHandler> _logger;

    public GetProductsQueryHandler(ILogger<GetProductsQueryHandler> logger)
    {
        _logger = logger;
    }
    public async Task<Result<List<ProductItemDto>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        //TODO - Add logic to filter based on "q"
        //TODO - Add repository
        var sampleList = new List<ProductItemDto>()
        {
            new() { Id = 1, Name = "X", Price = 12.90M },
            new() { Id = 2, Name = "Y", Price = 15.90M },
            new() { Id = 1, Name = "Z", Price = 18.90M }
        };

        return Result.Ok(sampleList);
    }
}
